using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;

namespace WebAPI.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> Create(Product product);
        Task Update(Product product);
    }
}
