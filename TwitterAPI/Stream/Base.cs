using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

/**
  Streaming calls to the Twitter API
  No rate limits
  Signature rulezz : https://dev.twitter.com/oauth/overview/creating-signatures
 */
namespace TwitterAPI {
  namespace Stream {
    class Base : TwitterAPI.Base {
      public Base(String token, String secret) : base(token, secret){}

      private AuthenticationHeaderValue getAuthenticationHeader(string method, string uri) {
        TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
        int secondsSinceEpoch = (int)t.TotalSeconds;

        var oauthSignature = $"{method}{Uri.EscapeDataString(uri)}";
        //$"OAuth oauth_consumer_key=\"{this.credentials.Access}\", oauth_nonce=\"{System.Guid.NewGuid()}\", oauth_signature=\"\", oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"{secondsSinceEpoch}\", oauth_token=\"370773112-GmHxMAgYyLbNEtIKZeRNFsMKPR9EyMZeS9weJAEb\", oauth_version=\"1.0\"";

                return new AuthenticationHeaderValue("todo");
      }

      string TWEETS_URI = "https://stream.twitter.com/1.1/statuses/filter.json";
      public async Task<string> streamTweets(){

        var request = new HttpRequestMessage() {
          RequestUri = new Uri(TWEETS_URI),
          Method = HttpMethod.Get
        };
        request.Headers.Authorization = getAuthenticationHeader("POST", TWEETS_URI);
        var res = await httpClient.SendAsync(request);
        res.EnsureSuccessStatusCode();

        // HttpResponseMessage res = await httpClient.GetAsync($"https://api.twitter.com/1.1/followers/ids.json?user_id=12345&cursor=0");
        // res.EnsureSuccessStatusCode();

        return await res.Content.ReadAsStringAsync();
      }
    }
  }
}