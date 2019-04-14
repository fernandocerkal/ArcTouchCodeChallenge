using System;

namespace codechallenge.Application
{
    public class BaseModel : IBaseModel
    {
        public String apiListMethodPath;

        public BaseModel(string apiListMethodPath)
        {
            this.apiListMethodPath = apiListMethodPath;
        }

        public string GetAPIListMethodPah() => apiListMethodPath;
    }
}

