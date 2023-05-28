using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProducts_MongoDB.Service;

namespace WebApiProducts_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _product;

        public ProductsController(ProductService product) {
            _product = product;
        }

        [HttpGet]
        public readonly 
    }
}
