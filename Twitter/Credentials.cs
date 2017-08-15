using System;

namespace Twitter {
  class Credentials {
      public String Access {get; set;}
      public String Secret {get; set;}

      public Credentials(String access, String secret){
          this.Access = access;
          this.Secret = secret;
      }

      public String toBearerTokenCredentials(){
          var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{this.Access}:{this.Secret}");

          String t = System.Convert.ToBase64String(plainTextBytes);
          return t;
      }
  }
}