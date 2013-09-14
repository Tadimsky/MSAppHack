using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace PhoneCommander.Classes
{
    public class HtmlDownloader
    {

        public async static Task<String> DownloadToString(String uri)
        {
            HttpClient htc = new HttpClient();
            HttpResponseMessage response = await htc.GetAsync(uri);
            String j = await response.Content.ReadAsStringAsync();
            HtmlDocument hd = new HtmlDocument();
            hd.LoadHtml(j);
            dynamic p = hd.DocumentNode.Descendants("body");
            String val = "";
            foreach (dynamic node in p)
            {
                val = node.InnerText;
            }
            return val;
        }
    }
}
