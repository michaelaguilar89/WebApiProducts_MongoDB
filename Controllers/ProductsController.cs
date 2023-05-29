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
                _response.IsSucces = false;
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
                _response.IsSucces = false;
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
       [HttpPut]
       public async Task<IActionResult> EditProduct(Products updateProduct)
        {
            try
            {
               var myresponse= await _product.EditProduct(updateProduct.Id, updateProduct);
                if (myresponse is false)
                {
                    _response.DisplayMessage = "Product not found";
                    return BadRequest(_response);
                }
                _response.DisplayMessage = "Update Product";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> RemoveProduct(string id)
        {
            try
            {
                var myresponse = await _product.RemoveProduct(id);
                if (myresponse is false)
                {
                    _response.DisplayMessage = "Product not found";
                    return BadRequest(_response);

                }
                _response.DisplayMessage = "removed Product";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            try
            {
                var newProduct = await _product.getById(id);
                if (newProduct is null)
                {
                    _response.DisplayMessage="The product not exist!";
                    return BadRequest(_response);
                }
                _response.Result = newProduct;
                _response.DisplayMessage = "Data of Id : " + id;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSucces = false;
                _response.DisplayMessage = "Error";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }
    }
}
