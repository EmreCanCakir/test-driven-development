using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.Model;

namespace TestDrivenDevelopmentApp.Services
{
    public interface IBaseService<T> where T : class, new()
    {
        IActionResult Add(T entity);
        List<T> GetAll();
    }
}
