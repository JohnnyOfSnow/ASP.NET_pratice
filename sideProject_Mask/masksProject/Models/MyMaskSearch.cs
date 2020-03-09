using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using masksProject.Models;


namespace masksProject.Models
{
    /*
     *  1. Get Third party data(JSON), and deserialize it to object.
     *  2. According to the country name from Ajax request, return a List<selfMask>.
     */
    public class MyMaskSearch
    {

        public string content; // Store third party data.

        public List<selfMask> getCoutry(string countryName)
        {
            GetNewJson();

            Mask mask = JsonConvert.DeserializeObject<Mask>(content);

            List<selfMask> selfMasksList = new List<selfMask>();

            int i = 0;
            foreach (var item in mask.features)
            {
                if ((item.properties.town).Equals(countryName))
                {
                    selfMask self = new selfMask();
                    self.name = item.properties.name;
                    self.mask_child = item.properties.mask_child;
                    self.mask_adult = item.properties.mask_adult;
                    self.address = item.properties.address;
                    selfMasksList.Add(self);
                }
                i++;
            }
            return selfMasksList;
        }
        public void GetNewJson()
        {
            content = GetJsonContent("https://raw.githubusercontent.com/kiang/pharmacies/master/json/points.json");
        }

        private static string GetJsonContent(string Url)
        {
            string targetURI = Url;
            var request = System.Net.WebRequest.Create(targetURI);
            request.ContentType = "application/json; charset=utf-8";
            var response = request.GetResponse();
            string text;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                text = sr.ReadToEnd();
            }
            return text;
        }
    }
}