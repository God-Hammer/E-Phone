using E_Phone_Library.Models;
using E_Phone_Library.Responses;

namespace E_Phone_Library.Contracts
{
    public interface IProduct
    {
        Task<ServiceResponse> AddProduct(Product model);
        Task<List<Product>> GetProducts(bool featuredProducts);
    }
}
