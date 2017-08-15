using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace dotnet
{
    class TwitterSample {
        public String Res { get ; set; }
        public TwitterSample(String res) {
            this.Res = res;
        }
    }
    class Program
    {
        static HttpClient httpClient = new HttpClient();

        static void Main(string[] args)
        {
            try
            {
                Run().Wait();
            }
            catch (System.Exception e)
            {
                Console.Write(e.Message);
            }
        }

        static async Task Run()
        {
            var twitterUserAPI = new TwitterAPI.Stream.Base("i7IODCxH51rVaUY09jL4Ec0JK", "OsXyD0rYNH9zhT2JLHOqjP0dqmfv6UTl5QSyXFl78Wq0LVtiOZ");
            await twitterUserAPI.streamTweets();
        }
    }
}
