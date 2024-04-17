using Microsoft.AspNetCore.Mvc;
using TestDrivenDevelopmentApp.Services;

namespace TestDrivenDevelopmentApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController<TEntity, TService> : ControllerBase, IController<TEntity>
        where TEntity : class, new()
        where TService : class, IBaseService<TEntity>
    {
        private readonly TService _service;
        public BaseController(TService service)
        {
            _service = service;
        }
        [HttpPost(Name = "Add")]
        public async Task<IActionResult> Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var entities = _service.GetAll();
            if (!entities.Any())
            {
                return BadRequest();
            }
            return Ok(entities);
        }
    }
}
