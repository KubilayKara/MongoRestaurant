using Mongo.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Web.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDto responseModel { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        private readonly IHttpClientFactory _httpClient;

        public BaseService(IHttpClientFactory httpClient)
        {
            this._httpClient = httpClient;
            this.responseModel = new ResponseDto();
        }

        public async Task<T> SendAsync<T>(ApiRequest request) 
        {
            try
            {
                var client = HttpClient.CreateClient("MangoApi");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(request.Url);
                client.DefaultRequestHeaders.Clear();
                if (request.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(request.Data),
                         Encoding.UTF8, "application/json");
                }
                HttpResponseMessage apiResponse = null;
                switch (request.ApiType)
                {
                    case StaticDictionary.ApiType.GET:
                        message.Method = HttpMethod.Get;
                        break;
                    case StaticDictionary.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDictionary.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDictionary.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        break;
                }
                apiResponse = await client.SendAsync(message);
                string apiContent = await apiResponse.Content.ReadAsStringAsync();
                T apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
                return apiResponseDto;
            }
            catch (Exception e)
            {
                ResponseDto errorResDto = new ResponseDto
                {
                    DisplayMessage = "Error",
                    ErrorMessaages = new List<string>
                    {
                        e.Message
                    },
                    IsSuccess = false
                };
                string errStr = JsonConvert.SerializeObject(errorResDto);
                return JsonConvert.DeserializeObject<T>(errStr); 
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

