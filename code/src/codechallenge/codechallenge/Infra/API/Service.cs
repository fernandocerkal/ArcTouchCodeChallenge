using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using codechallenge.Application;
using Newtonsoft.Json.Linq;

namespace codechallenge.Infra.API
{
    public class Service : IService
    {
        //todo: set in configuration
        private const string apiHostPrefix  = @"https://api.themoviedb.org/3/";
        private const string apiKey         = "1f54bd990f1cdfb230adb312546d765d";

        public async Task<IEnumerable<T>> GetList<T>(T model, Int32? page = null) where T : class, IBaseModel
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var urlRequest = $"{apiHostPrefix}{model.GetAPIListMethodPah()}?api_key={apiKey}";

                    if (page.HasValue) urlRequest += "&page={page}";

                    Console.WriteLine($"RX::{urlRequest}");

                    var httpResponse =  await client.GetAsync(new Uri(urlRequest));
                    var response = await httpResponse?.Content.ReadAsStringAsync();

                    Console.WriteLine($"TX::{response}");

                    return JToken.Parse(response)[model.GetArrayNameOfApiMethod()].ToObject<IEnumerable<T>>();
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