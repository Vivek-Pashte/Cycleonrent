using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;

namespace oneceagain
{
    public partial class ProductView : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["PID"] != null)
            {
                if (!IsPostBack)
                {
                    divSuccess.Visible = false;
                    BindProductImage2();
                    BindProductDetails();
                }
            }
            else
            {
                Response.Redirect("~/Products.aspx");
            }
        }        
        private void BindProductDetails()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (MySqlConnection con = new MySqlConnection(CS))
            {                
                MySqlCommand cmd = new MySqlCommand("select * from tblProducts where PID='"+PID+"'" , con)
                {
                    CommandType = CommandType.Text,
                };
                using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    rptrProductDetails.DataSource = dt;
                    rptrProductDetails.DataBind();
                    Session["CartPID"] = Convert.ToInt32(dt.Rows[0]["PID"].ToString());
                    Session["myPName"] = dt.Rows[0]["PName"].ToString();
                    Session["myPPrice"] = dt.Rows[0]["PPrice"].ToString();
                    Session["myPSelPrice"] = dt.Rows[0]["PSelPrice"].ToString();
                }
            }
        }
        private void BindProductImage2()
        {
            Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tblProductImages where PID='" + PID + "'", con))
                {
                    cmd.CommandType = CommandType.Text;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrImage.DataSource = dt;
                        rptrImage.DataBind();
                    }
                }
            }
        }
        protected void btnAddtoCart_Click(object sender, EventArgs e)
        {
            string SelectedSize = string.Empty;
            foreach (RepeaterItem item in rptrProductDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var rbList = item.FindControl("rblSize") as RadioButtonList;
                    SelectedSize = rbList.SelectedValue;
                    var lblError = item.FindControl("lblError") as Label;
                    lblError.Text = "";
                }
            }
            if (Session["user_name"] != null)
            {             
                if (SelectedSize != "")
                {
                    Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                    AddToCartProduction();
                    Response.Redirect("ProductView.aspx?PID=" + PID);
                }
                else
                {
                    foreach (RepeaterItem item in rptrProductDetails.Items)
                    {
                        if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                        {
                            var lblError = item.FindControl("lblError") as Label;
                            lblError.Text = "Please select a size";
                        }
                    }
                }
            }
            else
            {                
                    Response.Redirect("SignIn.aspx");               
            }            
        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;
            base.InitializeCulture();
        }
        private void AddToCartProduction()
        {
            if (Session["user_name"] != null)
            {
                Int32 UserID = Convert.ToInt32(Session["USERID"].ToString());
                Int64 PID = Convert.ToInt64(Request.QueryString["PID"]);
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tblCart where PID = @PID and UID = @UserID", con)
                    {
                        CommandType = CommandType.Text
                    };
                    cmd.Parameters.AddWithValue("@UserID", UserID);
                    cmd.Parameters.AddWithValue("@PID", PID);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if(dt.Rows.Count > 0)
                        {
                            Int32 updateQty = Convert.ToInt32(dt.Rows[0]["Qty"].ToString());
                            MySqlCommand myCmd = new MySqlCommand("UPDATE tblCart SET Qty = @Quantity WHERE PID = @CartPID AND UID = @UserID", con)
                            {
                                CommandType = CommandType.Text
                            };
                            myCmd.Parameters.AddWithValue("@Quantity", updateQty + 1);
                            myCmd.Parameters.AddWithValue("@CartPID", PID);
                            myCmd.Parameters.AddWithValue("@UserID", UserID);
                            Int64 CartID = Convert.ToInt64(myCmd.ExecuteScalar());                            
                        }
                        else
                        {
                            MySqlCommand incmd = new MySqlCommand("INSERT INTO tblCart(UID,PID,PName,PPrice,PSelPrice,Qty) VALUES(@UID,@PID,@PName,@PPrice,@PSelPrice,@Qty)", con)
                            {
                                CommandType = CommandType.Text
                            };
                            incmd.Parameters.AddWithValue("@UID", UserID);
                            incmd.Parameters.AddWithValue("@PID", PID);
                            incmd.Parameters.AddWithValue("@Qty", 1);
                            incmd.Parameters.AddWithValue("@PName", Session["myPName"]);
                            incmd.Parameters.AddWithValue("@PPrice", Session["myPPrice"]);
                            incmd.Parameters.AddWithValue("@PSelPrice", Session["myPSelPrice"]);                            
                            incmd.ExecuteNonQuery();
                            long LIID = incmd.LastInsertedId;
                            int CartID = (int)LIID;
                        }                       
                    }
                }
            }
        }
        protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                string BrandID = (e.Item.FindControl("hfBrandID") as HiddenField).Value;
                string CatID = (e.Item.FindControl("hfCatID") as HiddenField).Value;
                RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    using (MySqlCommand cmd = new MySqlCommand("select * from tblSize where BrandID='" + BrandID + "' and CartID=" + CatID + "", con))
                    {
                        cmd.CommandType = CommandType.Text;
                        using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            sda.Fill(dt);
                            rblSize.DataSource = dt;
                            rblSize.DataTextField = "sizename";
                            rblSize.DataValueField = "sizeid";
                            rblSize.DataBind();
                        }
                    }
                }
            }
        }
    }
}