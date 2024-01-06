using E_Phone_Library.Contracts;
using E_Phone_Library.Models;
using E_Phone_Library.Responses;
using Microsoft.AspNetCore.Mvc;

namespace E_Phone_Server.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct _product;

        
        public ProductController(IProduct product)
        {
            _product = product;
        }

        //Get all product
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts(bool featured)
        {
            var products = await _product.GetProducts(featured);
            return products;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse>> AddProduct(Product product)
        {
            if (product is null) return BadRequest("Model is null");
            var response = await _product.AddProduct(product);
            return response;
        }
    }
}
