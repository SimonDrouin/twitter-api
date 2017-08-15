using System;
using System.Net.Http;

namespace TwitterAPI {
  class Base {
    protected static HttpClient httpClient = new HttpClient();
    protected Twitter.Credentials credentials;

    public Base(String token, String secret) {
      this.credentials = new Twitter.Credentials(token, secret);
    }
  }
}