using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Core.ApplicationServices;
using ProductApp.Core.Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductApp.RestAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            try
            {
                return _productService.GetAllProducts();
            }
            catch (Exception e)
            {
                return StatusCode(500, "No");
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productService.FindProductById(id);
            if (product == null)
            {
                return StatusCode(404, "No");
            }

            try
            {
                return _productService.FindProductById(id);
            }
            catch (Exception e)
            {
                return StatusCode(500, "No");
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                return StatusCode(500, "Name is required for Creating Owner");
            }
            return _productService.CreateProduct(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult<Product> Put(int id, [FromBody] Product product)
        {
            if (id < 1 || id != product.Id)
            {
                return StatusCode(404, "No");
            }

            try
            {
                return _productService.UpdateProduct(product);
            }
            catch (Exception e)
            {
                return StatusCode(500, "No");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(int id)
        {
            var product = _productService.DeleteProduct(id);
            if (product == null)
            {
                return StatusCode(404, "?????");
            }

            try
            {
                return product;
            }
            catch (Exception e)
            {
                return StatusCode(500, "No");
            }
        }
    }
}
