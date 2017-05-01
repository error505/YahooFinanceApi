using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeYahooFinance.Services
{
    public class CallWebRequest
    {
        public  async Task<string> WebRequest(string url)
        {
            try
            {
                using (var web = new WebClient())
                {
                    try
                    {
                        web.Proxy = null;
             
                        web.Encoding = Encoding.UTF8;
                        var urlEncoded = WebUtility.UrlEncode(url);
                        web.Headers[HttpRequestHeader.UserAgent] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/57.0.2987.133 Safari/537.36";
                        var webResponseData = await web.DownloadStringTaskAsync(new Uri(url));
                        return webResponseData;
                    }
                    catch (WebException e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }

                }
            }
            catch (WebException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
