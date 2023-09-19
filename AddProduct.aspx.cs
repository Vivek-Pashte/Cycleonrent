using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

namespace oneceagain
{
    public partial class AddProduct : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBrand();
                BindCategory();
                BindGridview1();
                ddlCategory.Enabled = false;
            }
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                con.Open();
                MySqlCommand cmd1 = new MySqlCommand("Select * from tblsize where BrandID='" + ddlBrand.SelectedItem.Value + "'and  CartID='" + ddlCategory.SelectedItem.Value + "' ", con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    cblSize.DataSource = dt;
                    cblSize.DataTextField = "SizeName";
                    cblSize.DataValueField = "SizeID";
                    cblSize.DataBind();
                }
            }
        }
        protected void ddlBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBrand.SelectedIndex != 0)
            {
                ddlCategory.Enabled = true;
            }
            else
            {
                ddlCategory.Enabled=false;
            }
        }
        private void BindCategory()
        {
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                con.Open();
                string str1 = "Select * from tblCategory";
                MySqlCommand cmd1 = new MySqlCommand(str1, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd1);
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
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                con.Open();
                string str2 = "Select * from tblBrands";
                MySqlCommand cmd2 = new MySqlCommand(str2, con);
                MySqlDataAdapter sda = new MySqlDataAdapter(cmd2);
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
        private void BindGridview1()
        {
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                using (MySqlCommand cmd = new MySqlCommand("procBindAllProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        da.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            da.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(CS))
            {
                con.Open();                
                string str3 = "INSERT INTO cycleonrent.tblproducts(PName,PPrice,PSelPrice,PBrandID,PCategoryID,PProductDetail,FreeDelivery,COD) VALUES(@PName,@PPrice,@PSelPrice,@PBrandID,@PCategoryID,@PProductDetails,@FreeDelivery,@COD)";
                MySqlCommand cmd4 = new MySqlCommand(str3, con);
                cmd4.Parameters.AddWithValue("@PName", txtProductName.Text);
                cmd4.Parameters.AddWithValue("@PPrice", txtPrice.Text);
                cmd4.Parameters.AddWithValue("@PSelPrice", txtsellPrice.Text);
                cmd4.Parameters.AddWithValue("@PBrandID", ddlBrand.SelectedItem.Value);
                cmd4.Parameters.AddWithValue("@PCategoryID", ddlCategory.SelectedItem.Value);
                cmd4.Parameters.AddWithValue("@PProductDetails", txtPDetail.Text);
                cmd4.CommandText = str3;
                if (chFD.Checked == true)
                {
                    cmd4.Parameters.AddWithValue("@FreeDelivery", 1.ToString());
                }
                else
                {
                    cmd4.Parameters.AddWithValue("@FreeDelivery", 0.ToString());
                }
                if (cbCOD.Checked == true)
                {
                    cmd4.Parameters.AddWithValue("@COD", 1.ToString());
                }
                else
                {
                    cmd4.Parameters.AddWithValue("@COD", 0.ToString());
                }
                cmd4.ExecuteNonQuery();
                long LIID = cmd4.LastInsertedId;
                int PID = (int)LIID;
                //Insert size quantity
                for (int i = 0; i < cblSize.Items.Count; i++)
                {
                    if (cblSize.Items[i].Selected == true)
                    {
                        Int64 SizeID = Convert.ToInt64(cblSize.Items[i].Value);
                        int Quantity = Convert.ToInt32(txtQuantity.Text);
                        string str4 = "insert into tblProductSizeQuantity(PQID,SizeID,Quantity) values(@PID,@SizeID,@Quantity)";
                        MySqlCommand cmd5 = new MySqlCommand(str4, con);
                        cmd5.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                        cmd5.Parameters.AddWithValue("@SizeID", Convert.ToInt32(SizeID));
                        cmd5.Parameters.AddWithValue("@Quantity", Convert.ToInt32(Quantity));
                        cmd5.ExecuteNonQuery();
                    }
                }                
                if (fuImg1.HasFile)
                {
                    string str = fuImg1.FileName;
                    string S = Server.MapPath("~/images/" + str);
                    fuImg1.PostedFile.SaveAs(Server.MapPath("~/images/" + str));
                    string Image = "~/images/" + str.ToString();
                    string str5 = "insert into tblProductImages(PID,Image) values(@PID, '" + Image + "')";
                    MySqlCommand cmd6 = new MySqlCommand(str5, con);
                    cmd6.Parameters.AddWithValue("@PID", Convert.ToInt32(PID));
                    cmd6.ExecuteNonQuery();
                }
                BindGridview1();
                Response.Write("<script> alert('Product Added Successfully ');  </script>");
                txtPDetail.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtProductName.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                ddlBrand.ClearSelection();
                ddlBrand.Items.FindByValue("0").Selected = true;
                ddlCategory.ClearSelection();
                ddlCategory.Items.FindByValue("0").Selected = true;                
                txtProductName.Focus();
                con.Close();
            }
        }
    } 
}