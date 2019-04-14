using System;
using System.Net.Http;
using System.Threading.Tasks;
using codechallenge.Application;
using Newtonsoft.Json;

namespace codechallenge.Infra.API
{
    public class Service : IService
    {
        //todo: set in configuration
        private const string apiHostPrefix  = @"https://api.themoviedb.org/3/";
        private const string apiKey         = "1f54bd990f1cdfb230adb312546d765d";

        public async Task<ApiResult<T>> GetList<T>(T model, Int32? page) where T : class, IBaseModel
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlRequest = $"{apiHostPrefix}{model.GetAPIListMethodPah()}?api_key={apiKey}";

                    if (page.HasValue) urlRequest += "&page={page}";

                    Console.WriteLine($"RX::{urlRequest}");

                    var httpResponse =  client.GetAsync(new Uri(urlRequest)).GetAwaiter().GetResult();
                    var response = httpResponse?.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    Console.WriteLine($"TX::{response}");

                    return JsonConvert.DeserializeObject<ApiResult<T>>(response);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}