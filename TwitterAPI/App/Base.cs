using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace TwitterAPI {
  namespace App {
    class Base : TwitterAPI.Base {
      private String bearerToken;

      public Base(String token, String secret) : base(token, secret) {}

      public async void Authenticate(){
        this.bearerToken = await GetBearerToken(this.credentials);

        Console.Write("Twitter App succesfully authenticated...");
      }

      private async Task<String> GetBearerToken(Twitter.Credentials creds){

        var request = new HttpRequestMessage() {
            RequestUri = new Uri("https://api.twitter.com/oauth2/token"),
            Method = HttpMethod.Post
        };
        request.Headers.Authorization = new AuthenticationHeaderValue("Basic", creds.toBearerTokenCredentials());
        request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");

        HttpResponseMessage res = await httpClient.SendAsync(request);
        res.EnsureSuccessStatusCode();

        return await res.Content.ReadAsStringAsync();
        }
    }
  }
}