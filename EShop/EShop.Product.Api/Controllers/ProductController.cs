using EShop.Infrastructure.Command.Product;
using EShop.Product.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductService _productService;

		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		public async Task<IActionResult> Get(Guid productId)
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
