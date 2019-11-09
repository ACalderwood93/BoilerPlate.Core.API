using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Models;
using WebAPI.Data.Models.ViewModels;

namespace WebAPI.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();

        Product GetByName(string name);

        Task<Product> Create(VmProduct model);

        Task Update(VmProduct model);

    }
}
