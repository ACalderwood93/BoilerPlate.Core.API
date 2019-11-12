using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Models.ViewModels;
using WebAPI.Services.Interfaces;

namespace WebAPI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        public IProductService Service { get; }

        public ProductController(IProductService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(Service.GetAll());

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var result = Service.GetByName(name);

            if (result == null)
            {
                return BadRequest("No Data Found");
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] VmProduct product)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await Service.Create(product));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}