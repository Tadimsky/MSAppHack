using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using PhoneCommander.DataModel;

namespace PhoneCommander.Classes
{
    public class Detector
    {
        private DataPackageView myData;

        private static String PHONE_FORMAT = @"\b(?:\+?1[-. ]?)?\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})\b";

        public DetectedItems Detected { get; set; }

        public Detector(DataPackageView data)
        {
            myData = data;
            Detected = new DetectedItems();
        }

        public async void Detect()
        {
            var dataTypes = myData.AvailableFormats;
            
            if (dataTypes.Contains(StandardDataFormats.Uri))
            {
                Stopwatch st = new Stopwatch();
                st.Start();
                
                Uri uri = await myData.GetUriAsync();

                // Get the HTML Content
                String HtmlContent = await HtmlDownloader.DownloadToString(uri.ToString());
                Debug.WriteLine(" Fetch URL - " + st.ElapsedMilliseconds);
                List<String> nums = getNumbers(HtmlContent);
                foreach (var num in nums)
                {
                    Detected.Numbers.Add(num);    
                }
                Detected.LoadingNumbers = false;
                Debug.WriteLine(" Detect Numbers - " + st.ElapsedMilliseconds);
                nums = await getAddresses(HtmlContent);
                foreach (var address in nums)
                {
                    Detected.Addresses.Add(address);
                }
                Detected.LoadingAddresses = false;
                Debug.WriteLine(" Detect Addresses - " + st.ElapsedMilliseconds);
            }
        }

        private List<String> getNumbers(String input)
        {

            HashSet<String> numbers = new HashSet<String>();
            Regex matcher = new Regex(PHONE_FORMAT);
            Match match = matcher.Match(input);
            while (match.Success)
            {
                String p = match.Value;

                numbers.Add(GetNumber(p));
                match = match.NextMatch();
            }
            return new List<string>(numbers);

        }

        private static String GetNumber(String yolo)
        {
            String f = "";
            int chars = 0;
            foreach (char c in yolo.ToCharArray().Reverse())
            {
                int val = -1;
                if (int.TryParse(c.ToString(), out val))
                {
                    f = c + f;
                    if (chars == 3 || chars == 6 || chars == 9)
                    {
                        f = " " + f;
                    }
                    chars++;
                }
            }
            return f;
        }

        private async static Task<List<String>> getAddresses(String input)
        {
            SmartyStreets ss = new SmartyStreets();
            return await ss.callAPI(input);
        }

        
    }
}
