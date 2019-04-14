using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public async Task<List<T>> GetList<T>(T model, int page) where T : class, IBaseModel
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlRequest = $"{apiHostPrefix}{model.GetAPIListMethodPah()}?api_key={apiKey}&page={page}";

                    Debug.WriteLine($"RX::{urlRequest}");

                    var httpResponse =  client.GetAsync(new Uri(urlRequest)).GetAwaiter().GetResult();
                    var response = httpResponse?.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                    Debug.WriteLine($"TX::{response}");

                    return JsonConvert.DeserializeObject<List<T>>(response);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        }
    }
}