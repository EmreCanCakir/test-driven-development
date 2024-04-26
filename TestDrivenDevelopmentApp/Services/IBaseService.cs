using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.Core.Entities;

namespace TestDrivenDevelopmentApp.Services
{
    public interface IBaseService<T> where T : class, IEntity, new()
    {
        Task<List<T>> GetAll();
    }
}
