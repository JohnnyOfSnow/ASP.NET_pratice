using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SessionPratice
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_Click(object sender, EventArgs args)
        {
            Session["age"] = AgeTextBox.Text;
            AgeTextBox.Text = "";
        }

        protected void ShowButoon_Click(object sender, EventArgs args)
        {
            if(Session["age"] != null) // Session exist
            {
                Response.Write("You are " + Session["age"] + "years old.<br/>");
                Response.Write("Session ID: " + Session.SessionID.ToString() + "<br/>");
                Response.Write("Timeout: " + Session.Timeout.ToString() + "<br/>");
            }
            else
            {
                Response.Write("Session not exist!");
            }
        }
    }
}