using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace oneceagain
{
    public partial class EditSize : System.Web.UI.Page
    {
        string BrandID = "";
        string SizeName = "";
        string MainCID = "";
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
            MySqlDataAdapter da = new MySqlDataAdapter("select t1.SizeID,t1.SizeName,t2.Name as Brand,t3.CartName as Category from tblsize as t1 inner join tblbrands as t2 on t2.BrandID=t1.BrandID inner join tblcategory as t3 on t3.CartID=t1.CartID", con);
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
            MySqlCommand cmd = new MySqlCommand("select SizeName,BrandID,CartID from tblsize where SizeID=@ID", con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(txtID.Text));
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            da.Fill(ds, "dt");
            con.Close();
            if (ds.Tables[0].Rows.Count > 0)
            {
                BrandID = ds.Tables[0].Rows[0]["BrandID"].ToString();
                BindBrand();
                ddlBrand.SelectedValue = BrandID;
                SizeName = ds.Tables[0].Rows[0]["SizeName"].ToString();
                txtSize.Text = SizeName;
                MainCID = ds.Tables[0].Rows[0]["CartID"].ToString();
                BindMainCategory();
                ddlCategory.SelectedValue = MainCID;                
            }
            else
            {

            }
            con.Close();
        }
        private void BindMainCategory()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from tblcategory", con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlCategory.DataSource = dt;
                    ddlCategory.DataTextField = "CartName";
                    ddlCategory.DataValueField = "CartID";
                    ddlCategory.DataBind();
                    ddlCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
        private void BindBrand()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("Select * from tblBrands", con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    ddlBrand.DataSource = dt;
                    ddlBrand.DataTextField = "Name";
                    ddlBrand.DataValueField = "BrandID";
                    ddlBrand.DataBind();
                    ddlBrand.Items.Insert(0, new ListItem("-Select-", "0"));
                }
            }
        }
        protected void btnUpdateSize_Click(object sender, EventArgs e)
        {
            if (txtID.Text != string.Empty && txtSize.Text != string.Empty && ddlCategory.SelectedIndex != -1)
            {
                MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString);
                if (con.State == ConnectionState.Closed) { con.Open(); }
                MySqlCommand cmd = new MySqlCommand("update tblsize set SizeName=@SizeName,BrandID=@BrandID,CartID=@CategoryID where SizeID=@SizeID", con);
                cmd.Parameters.AddWithValue("@SizeID", Convert.ToInt32(txtID.Text));
                cmd.Parameters.AddWithValue("@CategoryID", ddlCategory.SelectedValue);
                cmd.Parameters.AddWithValue("@BrandID", ddlBrand.SelectedValue);
                cmd.Parameters.AddWithValue("@SizeName", txtSize.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Update successfully')</script>");
                BindGridview();
                txtID.Text = string.Empty;
                ddlBrand.SelectedIndex = -1;
                ddlCategory.SelectedIndex = -1;
                txtSize.Text = string.Empty;
            }
        }
    }
}