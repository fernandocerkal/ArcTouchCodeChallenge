using System.Collections.Generic;
using codechallenge.Application;
using Newtonsoft.Json;

namespace codechallenge.Infra.API
{
    public class ApiResult<T> where T : class, IBaseModel
    {
        [JsonProperty("results")]
        public IEnumerable<T> Results { get; set; }
    }
}
