using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Threading;
using System.Web.UI.WebControls;

namespace oneceagain
{
    public partial class Default : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["UserLogin"] == "YES")
            {
                Response.Redirect("UserHome.aspx?UserLogin=YES");
            }

            if (Session["user_name"] != null)
            {

                if (!this.IsPostBack)
                {
                    BindProductRepeater();
                    btnSignUP.Visible = false;
                    btnSignIN.Visible = false;
                    btnlogout.Visible = true;
                }

                BindCartNumber();
            }
            else
            {
                BindProductRepeater();
                btnSignUP.Visible = true;
                btnSignIN.Visible = true;
                btnlogout.Visible = false;
                Response.Write("<script type='text/javascript'>alert('Login please..')</script>");

            }
        }

        public void BindCartNumber()
        {
            if (Request.Cookies["CartPID"] != null)
            {
                string CookiePID = Request.Cookies["CartPID"].Value.Split('=')[1];
                string[] ProductArray = CookiePID.Split(',');
                int ProductCount = ProductArray.Length;
                pCount.InnerText = ProductCount.ToString();
            }
            else
            {
                pCount.InnerText = 0.ToString();
            }
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
                            pCount.InnerHtml = "0";
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
                string qr = "select A.*,B.*,c.Name as BrandName from tblproducts as A inner join tblbrands as c on A.PBrandID = c.BrandID inner join tblproductimages as B on A.PID = B.PID where  A.PName = '" + txtFilterGrid1Record.Text + "' OR c.Name = '" + txtFilterGrid1Record.Text + "' order by A.PID desc";
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
        protected override void InitializeCulture()
        {
            CultureInfo ci = new CultureInfo("en-IN");
            ci.NumberFormat.CurrencySymbol = "₹";
            Thread.CurrentThread.CurrentCulture = ci;

            base.InitializeCulture();
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session["user_name"] = null;
            Session.RemoveAll();
            Response.Redirect("Default.aspx");
        }
    }
}