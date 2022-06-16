using LCW.Catalog.Web.Response;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LCW.Catalog.Web
{
    public class PostRequestBase
    {
        private readonly IMemoryCache _memoryCache;

        public PostRequestBase(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public string BaseUrl { get; set; } = "https://localhost:44366/api/";

        public async Task<Response<T>> SendPostRequest<T>(string endPoint,object data) 
        {
            var client = new HttpClient();

            var bearer= _memoryCache.Get("Token");
            
            if (bearer is not null)
            {
                var contentType = new MediaTypeWithQualityHeaderValue("application/json");

                client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearer.ToString());
            }

            var response = await client.PostAsJsonAsync(BaseUrl+endPoint, data);

            var a = await response.Content.ReadAsStringAsync();

            var b = JsonConvert.DeserializeObject<Response<T>>(a);

            return b;

        }


    }
}
