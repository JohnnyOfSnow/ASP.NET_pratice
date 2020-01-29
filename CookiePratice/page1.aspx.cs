using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookiePratice
{
    public partial class login : System.Web.UI.Page
    {
        public String lastTime;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SubmitButton_Click(object sender, EventArgs args)
        {
            // Set Cookie's data.
            Response.Cookies["userinfo"]["account"] = AccountText.Text;
            Response.Cookies["userinfo"]["password"] = PasswordText.Text;
            Response.Cookies["userinfo"].Expires = DateTime.Now.AddDays(1);

            Response.Redirect("page2.aspx"); // jump to home page.

        }

        protected void EnterHomePageButton_Click(object sender, EventArgs args)
        {
            Response.Redirect("page2.aspx"); // jump to home page.
        }
    }
}