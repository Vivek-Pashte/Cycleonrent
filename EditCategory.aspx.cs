using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace oneceagain
{
    public partial class EditCategory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_name"] != null)
            {
                if (!IsPostBack)
                {
                    BindGridview();
                }
            }
            else
            {
                Response.Redirect("SignIn.aspx");
            }
        }
        private void BindGridview()
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            MySqlDataAdapter da = new MySqlDataAdapter("select CartID,CartName from tblCategory", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            else
            {
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
        }
        protected void txtID_TextChanged(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("select CartName from tblCategory where CartID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds, "dt");
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnUpdateBrand.Enabled = true;
                txtUpdateCatName.Text = ds.Tables[0].Rows[0]["CartName"].ToString();
            }
            else
            {
                btnUpdateBrand.Enabled = false;
                txtUpdateCatName.Text = string.Empty;
            }
            con.Close();
        }
        protected void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString);
            if (con.State == ConnectionState.Closed) { con.Open(); }
            MySqlCommand cmd = new MySqlCommand("update tblCategory set CartName=@Name where CartID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            cmd.Parameters.AddWithValue("@Name", txtUpdateCatName.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Update successfully')</script>");
            BindGridview();
            txtID.Text = string.Empty;
            txtUpdateCatName.Text = string.Empty;
        }
    }
}