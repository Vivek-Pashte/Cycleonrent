using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace oneceagain
{
    public partial class AddBrand : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrandRepeater();
            }
        }
        private void BindBrandRepeater()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand("select * from tblBrands", con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrBrands.DataSource = dt;
                        rptrBrands.DataBind();
                    }
                }
            }
        }
        protected void btnAddBrand_Click(object sender, EventArgs e)
        {
            if (txtBrand.Text != null && txtBrand.Text != "" && txtBrand.Text != string.Empty)
            {
                using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
                {
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("Insert into tblBrands(Name) Values('" + txtBrand.Text + "')", con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('Brand Added Successfully ');  </script>");
                    txtBrand.Text = string.Empty;
                    con.Close();
                    txtBrand.Focus();
                }
            }
        }
    }
}