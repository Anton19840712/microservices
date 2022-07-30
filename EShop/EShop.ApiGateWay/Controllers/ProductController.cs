using EShop.Infrastructure.Command.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EShop.ApiGateWay.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> Get([FromForm] CreateProduct product)
		{
			await Task.CompletedTask;
			return Accepted("Get product method called successfully!");
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromForm] CreateProduct product)
		{
			await Task.CompletedTask;
			return Accepted("Product created successfully!");
		}
	}
}
