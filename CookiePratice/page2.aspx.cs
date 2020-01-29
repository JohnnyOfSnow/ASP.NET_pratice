using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CookiePratice
{
    public partial class index : System.Web.UI.Page
    {
        public String lastTime;
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginCheck();
        }

        private void LoginCheck()
        {
            if (Request.Cookies["userinfo"] != null) // Cookies is exist.
            {
                Welcome_Hint.Text = "Welcome " + Server.HtmlEncode(Request.Cookies["userinfo"]["account"]) + " !!!";
            }
            else
            {
                Welcome_Hint.Text = "You don't login in!!!";
                logout_Btn.Text = "Return to login page.";
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs args)
        {
            Response.Cookies["userinfo"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("page1.aspx");
        }
    }
}