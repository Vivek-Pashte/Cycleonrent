using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace oneceagain
{
    public partial class Payment : System.Web.UI.Page
    {
        string defpid = "";
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;
        public static Int32 OrderNumber = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                if (!IsPostBack)
                {
                    BindPriceData2();
                    genAutoNum();
                    BindOrderProducts();
                }
            }
            else
            {
                Response.Redirect("SignIn.aspx");
            }
        }
        private void BindOrderProducts()
        {
            string UserIDD = Session["USERID"].ToString();
            DataTable dt = new DataTable();
            using (MySqlConnection con0 = new MySqlConnection(CS))
            {
                MySqlCommand cmd0 = new MySqlCommand("SP_BindCartProducts", con0)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd0.Parameters.AddWithValue("@id", UserIDD);
                using (MySqlDataAdapter sda0 = new MySqlDataAdapter(cmd0))
                {
                    sda0.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataColumn PID in dt.Columns)
                        {                          
                            using (MySqlConnection con = new MySqlConnection(CS))
                            {
                                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblCart  AND UID ='" + UserIDD + "'", con))
                                {                                  
                                    cmd.CommandType = CommandType.Text;
                                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                                    {
                                        GridView1.DataSource = dt;
                                        GridView1.DataBind();
                                        string abc = dt.Rows[0]["Qty"].ToString();
                                        hdQty.Value = abc.ToString();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        private void genAutoNum()
        {
            Random r = new Random();
            int num = r.Next(Convert.ToInt32("231965"),Convert.ToInt32("987654"));
            string ChkOrderNum = num.ToString();
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                MySqlCommand cmd = new MySqlCommand("SP_FindOrderNumber", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@FindOrderNumber", ChkOrderNum);
                if (con.State == ConnectionState.Closed) 
                {
                    con.Open(); 
                }
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    con.Close();
                    if (dt.Rows.Count > 0)
                    {
                        genAutoNum();
                    }
                    else
                    {
                        OrderNumber = Convert.ToInt32(num.ToString());
                    }
                }
            }
        }
        private void BindPriceData2()
        {
            string UserIDD = Session["USERID"].ToString();
            DataTable dt = new DataTable();
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                MySqlCommand cmd = new MySqlCommand("SP_BindUserCart", con)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("UserID", UserIDD);
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        string Total = dt.Compute("Sum(SubSelPrice)", "").ToString();
                        string CartTotal = dt.Compute("Sum(SubPrice)", "").ToString();
                        string TDiposite = dt.Compute("Sum(TDiposite)", "").ToString();
                        string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();                        
                        spanTotal.InnerText = string.Format("{0:c}", double.Parse(Total));
                        spanCartTotal.InnerText = string.Format("{0:c}", double.Parse(CartTotal));
                        spanDiposite.InnerText = string.Format("{0:c}", double.Parse(TDiposite));
                        Session["myCartAmount"] = string.Format("{0:####}", double.Parse(Total));
                        Session["TotalAmount"] = spanTotal.InnerText;
                        hdCartAmount.Value = CartTotal.ToString();
                        hdCartDiscount.Value = TDiposite.ToString() + ".00";
                        hdTotalPayed.Value = Total.ToString();                       
                    }
                    else
                    {
                        Response.Redirect("Products.aspx");
                    }
                }
            }
        }
        protected void btnplaceorder_Click(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                Int32 UserID = Convert.ToInt32(Session["USERID"].ToString());
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                string PaymentType = "COD";
                string PaymentStatus = "NotPaid";
                string OrderStatus = "Packaging";
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    con.Open();
                    MySqlCommand incmd = new MySqlCommand("SP_InsertOrder", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    incmd.Parameters.AddWithValue("@UserID", UserID);
                    incmd.Parameters.AddWithValue("@CartAmount", hdCartAmount.Value);
                    incmd.Parameters.AddWithValue("@CartDiposit", hdCartDiscount.Value);
                    incmd.Parameters.AddWithValue("@TotalPaid", hdTotalPayed.Value);
                    incmd.Parameters.AddWithValue("@PaymentType", PaymentType);
                    incmd.Parameters.AddWithValue("@PaymentStatus", PaymentStatus);
                    incmd.Parameters.AddWithValue("@Name", txtName.Text);
                    incmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                    incmd.Parameters.AddWithValue("@MobileNumber",Convert.ToInt32( txtMobileNumber.Text));
                    incmd.Parameters.AddWithValue("@OrderStatus", OrderStatus);
                    incmd.Parameters.AddWithValue("@OrderNumber", OrderNumber);
                    incmd.ExecuteNonQuery();
                    long LIID = incmd.LastInsertedId;
                    int OrderID = (int)LIID;
                    MySqlDataReader reader;
                    using (MySqlConnection cnn = new MySqlConnection(CS))
                    {
                        cnn.Open();
                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblCart  where UID ='" + UserID + "'", cnn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            MySqlCommand pcmd = new MySqlCommand("SP_InsertOrderProducts", con)
                            {
                                CommandType = CommandType.StoredProcedure
                            };
                            pcmd.Parameters.AddWithValue("@OrderID", OrderID);
                            pcmd.Parameters.AddWithValue("@UserID", UserID);
                            pcmd.Parameters.AddWithValue("@PID", reader.GetValue(2));
                            pcmd.Parameters.AddWithValue("@Quantity", reader.GetValue(6));
                            pcmd.ExecuteNonQuery();
                        }
                        reader.Close();
                        cmd.Dispose();
                        cnn.Close();
                    }
                    MySqlCommand myCmd = new MySqlCommand("DELETE FROM `cycleonrent`.`tblcart` WHERE UID = @UserID ;", con)
                    {
                        CommandType = CommandType.Text
                    };
                    myCmd.Parameters.AddWithValue("@UserID", UserID);
                    myCmd.ExecuteNonQuery();
                    con.Close();
                }                                                   
                Response.Redirect("Success.aspx");
            }
            else
            {
                Response.Redirect("SignIn.aspx");
            }
        }      
    }
}