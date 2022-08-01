using System;
using EShop.Infrastructure.Command.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MassTransit;

namespace EShop.ApiGateWay.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IBusControl _busControl;

		public ProductController(IBusControl busControl)
		{
			_busControl = busControl;
		}
		[HttpGet]
		public async Task<IActionResult> Get([FromForm] CreateProduct product)
		{
			await Task.CompletedTask;
			return Accepted("Get product method called successfully!");
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromForm] CreateProduct product)
		{
			//await Task.CompletedTask;
			var uri = new Uri("rabbitmq://localhost/create_product");
			var endPoint = await _busControl.GetSendEndpoint(uri);

			await endPoint.Send(endPoint);
			return Accepted("Product created successfully!");
		}
	}
}
