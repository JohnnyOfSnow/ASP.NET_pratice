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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["userinfo"]["account"] != null)
            {
                Welcome_Hint.Text = "Welcome " + Server.HtmlEncode(Request.Cookies["userinfo"]["account"]) + " !!!";
            }
            else
            {
                Welcome_Hint.Text = "You don't login in!!!";
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs args)
        {

        }
    }
}