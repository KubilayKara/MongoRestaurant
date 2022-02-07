using Mongo.Web.Models;
using System;
using System.Threading.Tasks;

namespace Mongo.Web.Services
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest request);
    }
}

