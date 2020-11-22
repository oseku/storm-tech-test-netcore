using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Services
{
    public class Gravatar
    {
        private readonly HttpClient _http;

        public Gravatar(HttpClient httpClient)
        {
            _http = httpClient;
            _http.DefaultRequestHeaders.Add("User-Agent", "Todo lsit"); //gravatar returns 403 without User-Agent...
            _http.Timeout = TimeSpan.FromMilliseconds(2000);    // cancel request if service is slow or unavailable
        }

        public async Task<dynamic> GetProfile(string hash)
        {
            try
            {
                var response = await _http.GetAsync($"https://www.gravatar.com/{hash}.json");

                return response.IsSuccessStatusCode
                    ? await response.Content.ReadAsAsync<dynamic>()
                    : null;
            }
            catch    // empty catch on purpose 
            {
                return null;
            }
        }

        public static string GetHash(string emailAddress)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.Default.GetBytes(emailAddress.Trim().ToLowerInvariant());
                var hashBytes = md5.ComputeHash(inputBytes);

                var builder = new StringBuilder();
                foreach (var b in hashBytes)
                {
                    builder.Append(b.ToString("X2"));
                }
                return builder.ToString().ToLowerInvariant();
            }
        }
    }
}