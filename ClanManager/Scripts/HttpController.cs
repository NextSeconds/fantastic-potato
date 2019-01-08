using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ClanManager.Scripts
{
    public class HttpController
    {
        private static string PRIVATE_KEY = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImRlNTNjMGVjLWE4MDEtNGU4My05OGJlLTcxYTUwNmJlNzVmMSIsImlhdCI6MTU0NjIxOTcxOCwic3ViIjoiZGV2ZWxvcGVyL2M1ZDhlZGVlLTY1MWYtZjhmNS0yMmNmLTFhNmU2YjdmZjNjNSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjExMS4yMjYuMTk5LjIyNiJdLCJ0eXBlIjoiY2xpZW50In1dfQ.ILCux9LlEh_pYiy--hgO6rLefCkfbPYZCb9gKzUmArJKMGFdJauDMuugc0Ehm-iikpYd30MMP6oHkmHlyPo20A";
        public static string GetKey() { return PRIVATE_KEY; }
        public static string GetResponse(string url, out string statusCode)
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetKey());
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            statusCode = response.StatusCode.ToString();
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            return null;
        }

        public static T GetResponse<T>(string url, out string statusCode) where T : class, new()
        {
            if (url.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", GetKey());
            HttpResponseMessage response = httpClient.GetAsync(url).Result;
            statusCode = response.StatusCode.ToString();

            T result = default(T);
            if (response.IsSuccessStatusCode)
            {
                Task<string> t = response.Content.ReadAsStringAsync();
                string s = t.Result;
                result = JsonConvert.DeserializeObject<T>(s);
            }
            return result;
        }
    }
}
