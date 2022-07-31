using EShop.Infrastructure.Command.Product;
using EShop.Product.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		[HttpGet]
		public async Task<IActionResult> Get(string productId)
		{
			var product = await _productService.GetProduct(productId);
			return Ok(product);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromForm] CreateProduct product)
		{
			var addedProduct = await _productService.AddProduct(product);

			return Ok(addedProduct);
		}
	}
}
