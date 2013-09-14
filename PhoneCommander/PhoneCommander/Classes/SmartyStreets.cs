using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PhoneCommander.Classes
{
    public class SmartyStreets
    {
        private static String URL = @"https://extract-beta.api.smartystreets.com/";
        private static String AuthID = "0108a8e3-ccd4-4aaa-b5be-d2ef27609d55";
        private static String AuthToken = "33AYYhTiGdUlZ%2FxoFCuLi%2FMhJKzQ81fiC0XUGQpJ%2B5ulrVO4Ov2i13eYSvZcxfje0LZjcofUWatL6H11Zc8a2w%3D%3D";
        private String ApiUrl = URL + "?auth-id=" + AuthID + "&auth-token=" + AuthToken;




        public async Task<List<String>> callAPI(String input)
        {
            List<String> results = new List<String>();
            HttpClient htc = new HttpClient();
            HttpContent hc = new StringContent(input);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            
            HttpResponseMessage hrm = await htc.PostAsync(ApiUrl, hc);
            Debug.WriteLine("Posted " + sw.ElapsedMilliseconds);
            if (hrm.IsSuccessStatusCode)
            {
                String response = await hrm.Content.ReadAsStringAsync();
                Debug.WriteLine("Read Data " + sw.ElapsedMilliseconds);
                dynamic json = JsonConvert.DeserializeObject(response);
                foreach (dynamic node in json.addresses)
                {
                    results.Add((String)node.text);
                }
                Debug.WriteLine("Parsed JSON " + sw.ElapsedMilliseconds);
            }
            return results;
        }


    }
}
