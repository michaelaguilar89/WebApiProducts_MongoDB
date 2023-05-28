using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiProduccion.Models;
using WebApiProducts_MongoDB.Models;
using WebApiProducts_MongoDB.Service;

namespace WebApiProducts_MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _product;
        protected myResponse _response;
        public ProductsController(ProductService product) {
            _product = product;

            _response = new myResponse();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try 
            {
               
               var list =await  _product.get();
                _response.Result = list;
                _response.DisplayMessage = "List of Products";
                return Ok(_response);

            }catch (Exception ex) 
            {
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }  
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(Products newProduct)
        {
            try
            {
                await _product.CreateProduct(newProduct);
                _response.DisplayMessage = "New Product";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
