using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pageDirectPratice
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int choice = 3;

            if(choice == 1) // Response.Redirect test
            {
                /**
                 *  1. Web Address will be the new page.(detail.aspx)
                 *  
                 *  2. Only display the new page content.
                 */
                Response.Write("Response.Redirect方法");
                Response.Redirect("detail.aspx"); // Exit default.aspx, and direct to detail.aspx
                Response.Write("測試 Redirect");
            }
            else if(choice == 2) // Server.Transfer test
            {
                /**
                 *  1. Web Address is the original page.(default.aspx)
                 *  
                 *  2. Though the page change in server side (browser didn't know), 
                 *  so browser will display the original page content and new page content.
                 */
                Response.Write(".Transfer方法:");
                Server.Transfer("detail.aspx"); // page change is completed in server
                Response.Write("測試 Transfer");
            }else
            {
                /**
                 *  1. Web Address is the original page.(default.aspx)
                 *  
                 *  2. Though the page change in server side (browser didn't know), 
                 *  so browser will display the original page content and new page content.
                 *  
                 *  3. When new page has executed, it will return to original page to execute. 
                 */
                Response.Write(".Execute方法:");
                Server.Execute("detail.aspx"); // page change is completed in server
                Response.Write("測試 Execute");
            }
            
        }
    }
}