using System;

namespace WebApplication1
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            //go to login page
            Response.Redirect("Login and Vote.aspx");
        }

        protected void regButton_Click(object sender, EventArgs e)
        {
            //go to registration page
            Response.Redirect("Register.aspx");
        }

    }
}