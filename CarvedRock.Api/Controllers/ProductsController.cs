using System.Collections.Generic;
using CarvedRock.Api.ApiModels;
using CarvedRock.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
using Serilog;

namespace CarvedRock.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        // private readonly ILogger<ProductsController> _logger; // cos we are using SeriLog (ILogger is default way of logging in aspnet core)// one less service to inject in controller
        private readonly IProductLogic _productLogic;

        //public ProductsController(ILogger<ProductsController> logger, IProductLogic productLogic)
        public ProductsController(IProductLogic productLogic)
        {
            // _logger = logger;
            _productLogic = productLogic;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts(string category = "all")
        {
            // _logger.LogInformation($"Started GetProducts() with category {category}");
            Log.Information($"Started GetProducts() with category {category}"); // shorter code using serlog
            Log.ForContext("assembly", category).Information($" Inside ProductController => Getproducts");
            return _productLogic.GetProductsForCategory(category);
        }
    }
}