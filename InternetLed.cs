using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson_201
{
    class InternetLed
    {
        private int throttle = 0;

        public int getThrottle()
        {
            return throttle;
        }
        
        public void InitalizeLed()
        {
            Debug.WriteLine("InternetLed::InitalizeLed");            
        }
                        
        const string WebAPIURL = "http://metabox.dynu.com:8080/rest/blinker";

        public async Task<int> GetThrottleFromWeb()
        {
            Debug.WriteLine("InternetLed::MakeWebApiCall");

            string responseString = "No response";

            try
            {
                using (HttpClient client = new HttpClient())
                {
                    responseString = await client.GetStringAsync(WebAPIURL);
                    
                    Debug.WriteLine(String.Format("Response string: [{0}]", responseString));
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

            if (!int.TryParse(responseString, out throttle))
            {
                throttle = 0;
            }
            
            return throttle;
        }
    }
}