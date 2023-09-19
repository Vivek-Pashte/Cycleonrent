using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace oneceagain
{
    public partial class Singup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtsignup_Click(object sender, EventArgs e)
        {
            if (isformvalid())
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("Insert into userlogin(name,user_name,password,email,user_type) Values('" + txtName.Text  + "','" + txtUname.Text  + "','" + txtPass.Text  + "','" + txtEmail.Text + "','User')", con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('Registration Successfully done');  </script>");
                    clr();
                    con.Close();
                }
                Response.Redirect("~/SignIn.aspx");
            }
            else
            {
                Response.Write("<script> alert('Registration failed');  </script>");
            }
        }
        private bool isformvalid()
        {
            if (txtUname.Text == "")
            {
                Response.Write("<script> alert('username not valid');  </script>");
                txtUname.Focus();
                return false;
            }
            else if (txtPass.Text == "")
            {
                Response.Write("<script> alert('Password not valid');  </script>");
                txtPass.Focus();
                return false;
            }
            else if (txtPass.Text != txtCPass.Text)
            {
                Response.Write("<script> alert('confirm Password not valid');  </script>");
                txtCPass.Focus();
                return false;
            }
            else if (txtEmail.Text == "")
            {
                Response.Write("<script> alert('Email not valid');  </script>");
                txtEmail.Focus();
                return false;
            }
            else if (txtName.Text == "")
            {
                Response.Write("<script> alert('Name not valid');  </script>");
                txtName.Focus();
                return false;
            }
            return true;
        }

        private void clr()
        {
            txtName.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtUname.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtCPass.Text = string.Empty;
        }
    }
}