using System;

namespace WebApplication1
{
    public partial class FAQ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void layout_Click(object sender, EventArgs e)
        {
            //go to layout page
            Response.Redirect("MasterPageLayout.aspx");
        }
    }
}