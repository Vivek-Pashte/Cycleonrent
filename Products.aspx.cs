using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;

namespace oneceagain
{
    public partial class Products : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                if (!IsPostBack)    
                {
                    if (Request.QueryString["BuyNow"] == "YES")
                    {
                    }
                    BindProductRepeater();
                }
            }
            else
            {
                if (Request.QueryString["BuyNow"] == "YES")
                {
                    Response.Redirect("SignIn.aspx");
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;
            base.InitializeCulture();
        }       
        private void BindProductRepeater()
        {
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                using (MySqlCommand cmd = new MySqlCommand("procBindAllProducts", con)) 
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrProducts.DataSource = dt;
                        rptrProducts.DataBind();
                        if (dt.Rows.Count <= 0)
                        {
                            Label1.Text = "Sorry! Currently no products in this category.";
                        }
                        else
                        {
                            Label1.Text = "Showing All Products";
                        }
                    }
                }
            }
        }
        protected void txtFilterGrid1Record_TextChanged(object sender, EventArgs e)
        {
            if (txtFilterGrid1Record.Text != string.Empty)
            {
                MySqlConnection con = new MySqlConnection(CS);
                con.Open();
                string qr = "select A.*,B.*,c.Name as BrandName from tblproducts as A inner join tblbrands as c on A.PBrandID = c.BrandID inner join tblproductimages as B on A.PID = B.PID where  A.PName like '" + txtFilterGrid1Record.Text + "' OR c.Name like'" + txtFilterGrid1Record.Text + "' order by A.PID desc";
                MySqlDataAdapter da = new MySqlDataAdapter(qr, con);
                string text = ((TextBox)sender).Text;
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    rptrProducts.DataSource = ds.Tables[0];
                    rptrProducts.DataBind();
                }
                else
                {

                }
            }
            else
            {
                BindProductRepeater();
            }
        }
    }
}