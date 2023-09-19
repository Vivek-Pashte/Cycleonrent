using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace oneceagain
{
    public partial class User : System.Web.UI.MasterPage
    {
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                btnsingup.Visible = false;
                btnlogout.Visible = true;
                btnlogIn.Visible = false;
                BindCartNumber22();
                Button1.Text = "Welcome: " + Session["user_name"].ToString().ToUpper();
            }
            else
            {
                btnsingup.Visible = true;
                btnlogout.Visible = false;
                btnlogIn.Visible = true;
            }
        }
        private void BindCartNumber22()
        {
            if (Session["USERID"] != null)
            {
                string UserIDD = Session["USERID"].ToString();
                DataTable dt = new DataTable();
                using (MySqlConnection con = new MySqlConnection(CS))
                {
                    MySqlCommand cmd = new MySqlCommand("SP_BindCartNumberz", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@UserID", UserIDD);
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        sda.Fill(dt);
                        if (dt.Rows.Count > 0)
                        {
                            string CartQuantity = dt.Compute("Sum(Qty)", "").ToString();
                            pCount.InnerText = CartQuantity;
                        }
                        else
                        {
                            pCount.InnerText = 0.ToString();
                        }
                    }
                }                
            }
            else
            {
                pCount.InnerText = "";
            }
        }
        private void BindCartNumber()
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
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Session["user_name"] = null;
            Response.Redirect("~/Default.aspx");
        }
        protected void btnlogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/SignIn.aspx");
        }
    }
}