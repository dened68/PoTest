using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using AutoMapper;
using System.Net.Http;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace TestPO.Model
    
{
    public class Dadata:IDadata
    {
         
        
         HttpClient hc = new HttpClient();
         string token;
         string secret;
        private readonly IConfiguration Configuration;
        public Dadata(IConfiguration configuration) { Configuration = configuration; }
        
        
        public async Task<List<ClearResponse>> ClearRequest(string rawAdress)
        {
            //string URI = "https://cleaner.dadata.ru/api/v1/clean/address";

            

            hc.BaseAddress = new Uri(Configuration["dadata:cleanUri"]);
            hc.DefaultRequestHeaders.Add("Authorization", Configuration["dadata:key"]);
            hc.DefaultRequestHeaders.Add("X-Secret", Configuration["dadata:secret"]);

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, Configuration["dadata:cleanUri"]);

            request.Content = new StringContent($"[ \"{rawAdress}\" ]",
                                                Encoding.UTF8,
                                                "application/json");

            HttpResponseMessage httpResponseMessage = await hc.SendAsync(request);

            var response = await httpResponseMessage.Content.ReadAsStringAsync();
            var jsonoObj = JArray.Parse(response);
            List<ClearResponse> cleanResponse = jsonoObj.ToObject<List<ClearResponse>>();
            return cleanResponse;
        }

        
    }
}
