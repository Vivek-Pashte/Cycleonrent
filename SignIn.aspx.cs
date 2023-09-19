using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace oneceagain
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UNAME"] != null && Request.Cookies["UPWD"] != null)
                {
                    txtUsername.Text = Request.Cookies["UNAME"].Value;
                    txtPass.Text = Request.Cookies["UPWD"].Value;
                    CheckBox1.Checked = true;
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString);
            con.Open();
            string str = "select * from userlogin where user_name='" + txtUsername.Text + "' and password='" + txtPass.Text + "'";
            MySqlCommand cmd = new MySqlCommand(str, con);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count != 0)
            {
                Session["USERID"] = dt.Rows[0]["ID"].ToString();
                if (CheckBox1.Checked)
                {
                    Response.Cookies["UNAME"].Value = txtUsername.Text;
                    Response.Cookies["UPWD"].Value = txtPass.Text;
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(10);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(10);
                }
                else
                {
                    Response.Cookies["UNAME"].Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies["UPWD"].Expires = DateTime.Now.AddDays(-1);
                }
                string Utype = dt.Rows[0]["user_type"].ToString().Trim();
                if (Utype == "User")
                {
                    Session["user_name"] = txtUsername.Text;
                    Response.Redirect("~/Products.aspx");
                }
                if (Utype == "Admin")
                {
                    Session["user_name"] = txtUsername.Text;
                    Response.Redirect("~/adminhome.aspx");
                }
            }
            else
            {
                Response.Write("<script> alert('Login failed');  </script>");
            }

            con.Close();
        }
        private void clr()
        {
            txtPass.Text = string.Empty;
            txtUsername.Text = string.Empty;
            txtUsername.Focus();
        }
    }
}