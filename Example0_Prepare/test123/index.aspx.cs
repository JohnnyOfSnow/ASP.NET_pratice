using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;



namespace test123
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string content = GetJsonContent("https://www.ktec.gov.tw/ktec_api.php?type=json");
            Data data = JsonConvert.DeserializeObject<Data>(content);
            message.InnerHtml += "<CAPTION><h1>高雄市政府相關求才發布</h1></CAPTION>";
            message.InnerHtml += "<table><tr><th>類型</th><th>主題</th><th>發表日期</th></tr>";

            int i = 0;
            foreach(var item in data.entries)
            {
                if(item.title.Length > 35)
                {
                    item.title = item.title.Substring(0, 35);
                    item.title += "...詳情請點";
                    message.InnerHtml += "<tr>" + "<td>" + item.category + "</td>" + "<td><a href = \"detail.aspx?i="
                        + i + "\">" + item.title + "</a></td>" + "<td>" + item.publication_date + "</td></tr>";
                    i++;
                }
                else
                {
                    message.InnerHtml += "<tr>" + "<td>" + item.category + "</td>" + "<td><a href = \"detail.aspx?i="
                       + i + "\">" + item.title + "</a></td>" + "<td>" + item.publication_date + "</td></tr>";
                    i++;
                }
            }
            message.InnerHtml += "</table>";
            
        }

        private static string GetJsonContent(string Url)
        {
            String targetUrl = Url;
            var request = System.Net.WebRequest.Create(targetUrl);
            request.ContentType = "application/json; charset=utf-8";
            var response = request.GetResponse();
            string text;
            using (var sr = new StreamReader(response.GetResponseStream())) // Class StreamReader need to include System.IO
            {
                text = sr.ReadToEnd();
            }
            return text;
        }

    }
}