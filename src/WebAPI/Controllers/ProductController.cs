using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Models.ViewModels;
using WebAPI.Data.QueryClasses.Interfaces;
using WebAPI.Data.Repositories.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductQueries Queries { get; }

        public IProductRepository Repo { get; }
        public ProductController(IProductQueries queries, IProductRepository repo)
        {
            Queries = queries;
            Repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(Queries.GetAll());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByName(string name)
        {

            if (name.Length < 1)
            {
                return BadRequest("Invalid Name");
            }

            var result = Queries.GetByName(name);

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
                return BadRequest("Invalid product");
            }

            try
            {
                var newProduct = new Data.Models.Product()
                {
                    ProductName = product.ProductName
                };

                return Ok(await Repo.Create(newProduct));


            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}