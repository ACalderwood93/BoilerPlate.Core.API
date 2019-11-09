using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.QueryClasses.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductQueries Queries { get; }
        public ProductController(IProductQueries queries)
        {
            Queries = queries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(Queries.GetAll());
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Getall(string name)
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
    }
}