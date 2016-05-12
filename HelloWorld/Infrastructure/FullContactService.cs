using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelloWorld.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net;

namespace HelloWorld.Infrastructure
{
    public class FullContactService
    {
        public string GetFullContactAsync(string email)
        {
            string baseUri = "https://api.fullcontact.com/v2/person.json?email=" + email + "&apiKey=8e684882ab2fc9ae";

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    return httpClient.GetStringAsync(baseUri).Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception is {0}", e.StackTrace);
                    return "";
                }
                    
            }
        }
    }
}