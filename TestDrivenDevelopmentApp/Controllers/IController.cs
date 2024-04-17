using Microsoft.AspNetCore.Mvc;

namespace TestDrivenDevelopmentApp.Controllers
{
    public interface IController<T>
    {
        Task<IActionResult> GetAll();
    }
}
