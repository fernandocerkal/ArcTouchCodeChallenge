using System;
using System.Threading.Tasks;
using codechallenge.Application;

namespace codechallenge.Infra.API
{
    public interface IService
    {
        Task<ApiResult<T>> GetList<T>(T model, Int32? page) where T : class, IBaseModel;
    }
}