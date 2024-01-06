using E_Phone_Library.Contracts;
using E_Phone_Library.Models;
using E_Phone_Library.Responses;
using E_Phone_Server.Data;
using Microsoft.EntityFrameworkCore;

namespace E_Phone_Server.Repositories
{
    public class ProductRepository : IProduct
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ServiceResponse> AddProduct(Product model)
        {
            if (model is null) return new ServiceResponse(false, "Model is null");
            var(flag, message) = await CheckName(model.Name!);
            if (flag)
            {
                _appDbContext.Products.Add(model);
                await Commit();
                return new ServiceResponse(true, "Saved");
            }
            return new ServiceResponse(flag, message);
        }

        public async Task<List<Product>> GetProducts(bool featuredProducts)
        {
            if (featuredProducts)
            {
                return await _appDbContext.Products.Where(product => product.Featured).ToListAsync();
            }
            else
            {
                return await _appDbContext.Products.ToListAsync();
            }
        }


        //PRIVATE METHOD
        private async Task<ServiceResponse> CheckName(string name)
        {
            var product = await _appDbContext.Products.FirstOrDefaultAsync(product => product.Name!.ToLower().Equals(name.ToLower()));
            return product is null ? new ServiceResponse(true, null!) : new ServiceResponse(false, "Product already exist");
        }

        private async Task Commit() => await _appDbContext.SaveChangesAsync();
    }
}
