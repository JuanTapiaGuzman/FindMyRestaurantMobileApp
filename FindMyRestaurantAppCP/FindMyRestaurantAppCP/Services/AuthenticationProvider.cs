using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindMyRestaurantAppCP.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace FindMyRestaurantAppCP.Services
{
    class AuthenticationProvider
    {
        private HttpClient Client;

        public HttpClient CurrentClient { get { return Client; } }

        private Usuario session;

        public Usuario Session
        {
            get
            {
                return session;
            }
        }

        public string UserId { get; private set; }

        private static readonly Lazy<AuthenticationProvider> instance = new Lazy<AuthenticationProvider>(() =>
        {
            return new AuthenticationProvider();
        });

        public static AuthenticationProvider Instance { get { return instance.Value; } }

        public AuthenticationProvider()
        {
            this.Client = new HttpClient();
        }


        public async Task<bool> Login(string username, string password)
        {
            var success = false;

            try
            {
                //obtain request
                var response = await this.Client.GetAsync(UrlConstants.Url + "/api/usuario?usuario="+ username + "&password=" + password);

                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    //var posts = JsonConvert.DeserializeObject<Usuario>(result);
                    if(response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        return true;
                    }
                }

                return false;

            }
            catch (Exception e)
            {
                success = false;
            }
            return success;
        }
    }
}
