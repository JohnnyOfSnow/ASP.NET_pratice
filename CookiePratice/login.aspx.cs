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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs args)
        {

            Response.Cookies["userinfo"]["account"] = AccountText.Text;
            Response.Cookies["userinfo"]["password"] = PasswordText.Text;
            Response.Cookies["userinfo"].Expires = DateTime.Now.AddDays(1);

            Response.Redirect("index.aspx");

        }
    }
}