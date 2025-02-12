using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using AplicatieAPI.Entities;
using AplicatieAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using static System.Net.Mime.MediaTypeNames;

namespace AplicatieAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IDynamoDBContext _dbContext;

        private static readonly AmazonDynamoDBClient client = new AmazonDynamoDBClient("AKIA53RMINWZZUNWTIHR", "pttUOu8dOa0p9Xszd9Ei5fF/r11WlCFOkY9AvmnT", Amazon.RegionEndpoint.EUCentral1);
        private static readonly DynamoDBContext context = new DynamoDBContext(client);

        public ProductController(IDynamoDBContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {

            var products = new List<Product>
            {
                new Product { Id = Guid.NewGuid(), Name = "Laptop", Price = 120000, Quantity = 5, Description = "High-performance laptop" },
                new Product { Id = Guid.NewGuid(), Name = "Smartphone", Price = 60000, Quantity = 10, Description = "Latest model smartphone" },
                new Product { Id = Guid.NewGuid(), Name = "Headphones", Price = 15000, Quantity = 15, Description = "Noise-canceling headphones" }
            };

            return Ok(products);
        }

        [HttpGet("/aws")]
        public async Task<IActionResult> GetAllProductsFromAWS()
        {
    
            var productList = await context.ScanAsync<ProductEntity>(default).GetRemainingAsync();

            Console.Write(productList);
            return Ok(productList);
;
        }
    }

}
