using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Models;
using WebAPI.Data.Models.ViewModels;
using WebAPI.Data.QueryClasses.Interfaces;
using WebAPI.Data.Repositories.Interfaces;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class ProductService : IProductService
    {
        public IProductRepository Repo { get; }
        public IProductQueries Query { get; }
        public IMapper Mapper { get; }

        public ProductService(IProductRepository repo, IProductQueries query, IMapper mapper)
        {
            Repo = repo;
            Query = query;
            Mapper = mapper;
        }

        public IEnumerable<Product> GetAll() => Query.GetAll();


        public Product GetByName(string name) => Query.GetByName(name);


        public async Task<Product> Create(VmProduct model)
        {
            var product = Mapper.Map<Product>(model);
            return await Repo.Create(product);
        }


        public async Task Update(VmProduct model)
        {
            var product = Mapper.Map<Product>(model);
            await Repo.Update(product);

        }
    }
}
