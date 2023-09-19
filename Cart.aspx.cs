using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;

namespace oneceagain
{
    public partial class Cart : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;      
        protected void Page_Load(object sender, EventArgs e)
        {
            divQtyError.Visible = false;
            if (!IsPostBack)
            {
                if (Session["user_name"] != null)
                {
                    BindProductCart();
                }
                else
                {
                    Response.Redirect("Signin.aspx");
                }
            }
        }      
        private void BindProductCart()
        {           
            string UserIDD = Session["USERID"].ToString();
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                MySqlCommand cmd = new MySqlCommand("SP_BindUserCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@UserID", UserIDD);
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    RptrCartProducts.DataSource = dt;
                    RptrCartProducts.DataBind();
                    if (dt.Rows.Count > 0)
                    {
                        string Total = dt.Compute("Sum(SubSelPrice)", "").ToString();
                        string CartTotal = dt.Compute("Sum(SubPrice)", "").ToString();
                        string TDiposite = dt.Compute("Sum(TDiposite)", "").ToString();
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                        h4NoItems.InnerText = "My Cart ( " + CartQuantity + " Item(s) )";
                        spanTotal.InnerText = string.Format("{0:c}",double.Parse(Total));
                        spanCartTotal.InnerText =  string.Format("{0:c}", double.Parse(CartTotal)) ;
                        spanDiposite.InnerText = string.Format("{0:c}", double.Parse(TDiposite));
                    }
                    else
                    {
                        h4NoItems.InnerText = "Your Shopping Cart is Empty.";
                        divAmountSect.Visible = false;
                    }
                }
            }
        }
        protected void RptrCartProducts_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            Int32 UserID = Convert.ToInt32(Session["USERID"].ToString());
            //This will add +1 to current quantity using PID
            if (e.CommandName == "DoPlus")
            {
                string PID = (e.CommandArgument.ToString());
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_getUserCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        con.Open();
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            int myQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            int PQuantity = Convert.ToInt32(dt.Rows[0]["Quantity"].ToString());                                                                                                                                
                            if (myQty <= PQuantity)
                            {
                                MySqlConnection con1 = new MySqlConnection(CS);
                                Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                                MySqlCommand myCmd = new MySqlCommand("SP_UpdateCart", con)
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                                myCmd.Parameters.AddWithValue("@CartPID", PID);
                                myCmd.Parameters.AddWithValue("@UserID", UserID);
                                con1.Open();
                                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                                con1.Close();
                                BindProductCart();
                            }
                            else if (myQty > PQuantity)
                            {
                                Response.Write("<script>alert('Please choose quantity less than stated!');</script>");
                            }
                        }
                        con.Close();
                    }
                }
            }
            else if (e.CommandName == "DoMinus")
            {
                string PID = e.CommandArgument.ToString();
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_getUserCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@PID", PID);
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            Int32 myQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            if (myQty <= 1)
                            {
                                divQtyError.Visible = true;
                            }
                            else
                            {
                                MySqlCommand myCmd = new MySqlCommand("SP_UpdateCart", con)
                                {
                                    CommandType = CommandType.StoredProcedure
                                };
                                myCmd.Parameters.AddWithValue("@Quantity", myQty - 1);
                                myCmd.Parameters.AddWithValue("@CartPID", PID);
                                myCmd.Parameters.AddWithValue("@UserID", UserID);
                                con.Open();
                                Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());
                                con.Close();
                                BindProductCart();
                            }
                        }
                    }
                }
            }
            else if (e.CommandName == "RemoveThisCart")
            {
                int CartPID = Convert.ToInt32(e.CommandArgument.ToString().Trim());
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    MySqlCommand myCmd = new MySqlCommand("SP_DeleteThisCartItem", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    myCmd.Parameters.AddWithValue("@CartID", CartPID);
                    con.Open();
                    myCmd.ExecuteNonQuery();
                    con.Close();
                    BindProductCart();
                }
            }
        }        
        protected void btnBuyNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("Payment.aspx");
        }
        protected void btnCart2_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("Cart.aspx");
        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;
            base.InitializeCulture();
        }
    }
}