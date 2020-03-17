using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;


namespace HttpHandler_ex.Models
{
    public class CountHttpHandler : IHttpHandler
    {
        private RequestContext _requestContext;

        public CountHttpHandler(RequestContext requestContext)
        {
            _requestContext = requestContext;
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            context.Response.Write("==================<br/>");
            context.Response.Write("Hello World<br/>");
            context.Response.Write("==================<br/>");
            ///context.Response.Write(string.Format("<script>alert('CountRequest = {0} ');</script>", gCountRequest));
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}