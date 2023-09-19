using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;

namespace oneceagain
{
    public partial class Report : System.Web.UI.Page
    {
        public static String CS = ConfigurationManager.ConnectionStrings["cycleonrent"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user_name"] != null)
                {
                    bindGrid1();
                    bindGrid2();
                }
                else
                {
                    Response.Redirect("Signin.aspx");
                }
            }
        }
        private void bindGrid2()
        {
            MySqlConnection con = new MySqlConnection(CS);
            string qr = "select  distinct t2.PName,t1.Quantity from tblProductsizequantity as t1 inner join tblProducts as t2 on t2.PID=t1.PQID";
            MySqlCommand cmd = new MySqlCommand(qr, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            GridView2.DataSource = dt;
            GridView2.DataBind();
        }
        private void bindGrid1()
        {
            MySqlConnection con = new MySqlConnection(CS);
            string qr = "select t1.OrderProID,t3.Name,t2.PName,t1.Quantity as QtySell,t4.Quantity as StockOpening,t4.Quantity-t1.Quantity as Available  from tblOrderProducts as t1 inner join tblProducts as t2 on t2.PID=t1.PID inner join userlogin as t3 on t3.ID=t1.OPUserID inner join tblProductsizequantity as t4 on t4.PQID=t1.PID";
            MySqlCommand cmd = new MySqlCommand(qr, con);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}