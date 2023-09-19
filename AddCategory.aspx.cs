using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace oneceagain
{
    public partial class AddCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCategoryReapter();
        }
        private void BindCategoryReapter()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tblCategory", con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrCategory.DataSource = dt;
                        rptrCategory.DataBind();
                    }
                }
            }
        }
        protected void btnAddtxtCategory_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Insert into tblCategory(CartName) Values('" + txtCategory.Text + "')", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script> alert('Category Added Successfully ');  </script>");
                txtCategory.Text = string.Empty;
                con.Close();
                txtCategory.Focus();
            }
        }
    }
}