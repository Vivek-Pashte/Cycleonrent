using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace oneceagain
{
    public partial class AddSize : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrand();
                BindMainCategory();
                BindrptrSize();
            }
        }
        private void BindrptrSize()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {
                string str = "select A.*,B.*,C.* from tblSize A inner join tblCategory B on B.CartID =A.CartID  inner join tblBrands C on C.BrandID =A.BrandID  ";
                using (MySqlCommand cmd = new MySqlCommand(str, con))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        rptrSize.DataSource = dt;
                        rptrSize.DataBind();
                    }
                }
            }
        }
        private void BindMainCategory()
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {
                con.Open();
                string str1 = "Select * from tblCategory";
                MySqlCommand cmd = new MySqlCommand(str1, con);
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
                string str2 = "Select * from tblBrands";
                MySqlCommand cmd = new MySqlCommand(str2, con);
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
        protected void btnAddSize_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString))
            {           
                    con.Open();
                    string str3 = "Insert into tblsize(SizeName,BrandID,CartID) Values('" + txtSize.Text + "','" + ddlBrand.SelectedItem.Value + "' '','" + ddlCategory.SelectedItem.Value + "')";
                    MySqlCommand cmd = new MySqlCommand(str3, con);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script> alert('Size Added Successfully ');  </script>");
                    txtSize.Text = string.Empty;                    
                    ddlBrand.ClearSelection();
                    ddlBrand.Items.FindByValue("0").Selected = true;
                    ddlCategory.ClearSelection();
                    ddlCategory.Items.FindByValue("0").Selected = true;
                    BindrptrSize();
                    con.Close();
            }            
        }
    }
}