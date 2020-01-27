using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace responseObjectPratice
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(".machineName屬性:");
            Response.Write("伺服器機器名: " + Server.MachineName); // get server name
            Response.Write("<br>.ScriptTimeout屬性:");
            Response.Write("超時時間為: " + Server.ScriptTimeout);

            Response.Write("<hr><br>根目錄的實際路徑為:" + Server.MapPath("/")); // root directory's physical file path

            // Url Encode test
            Response.Write("<br / >Server.UrlEncode下的熱門: " + Server.UrlEncode("熱門"));
            Response.Write("<br / >Server.UrlDecode下的熱門: " + Server.UrlDecode("熱門"));

            // HTML's tag Encode test
            Response.Write("<hr><br />HTMLDecode方法下: <b>粗體字</b>:"); // don't take <b></b> as special text, so <b> </b> is treated as HTML tag. 
            Response.Write("<br / >HTMLEncode方法下: " + Server.HtmlEncode("<b>粗體字</b>")); //  take <b></b> as special text, so <b> </b> isn't treated as HTML tag.



        }
    }
}