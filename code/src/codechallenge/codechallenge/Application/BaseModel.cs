using System;

namespace codechallenge.Application
{
    public class BaseModel : IBaseModel
    {
        public String apiListMethodPath;
        public String arayNameOfApiMethod;

        public BaseModel(string apiListMethodPath, string arayNameOfApiMethod)
        {
            this.apiListMethodPath = apiListMethodPath;
            this.arayNameOfApiMethod = arayNameOfApiMethod;
        }

        public string GetAPIListMethodPah() => apiListMethodPath;

        public string GetArrayNameOfApiMethod() => arayNameOfApiMethod;
    }
}