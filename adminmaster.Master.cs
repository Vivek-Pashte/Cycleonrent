using System;

namespace oneceagain
{
    public partial class adminmaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdminlogout_Click(object sender, EventArgs e)
        {

            Session["Username"] = null;
            Response.Redirect("~/SignIn.aspx");
        }
    }
}