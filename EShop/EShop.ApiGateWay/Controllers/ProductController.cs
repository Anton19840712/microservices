using System;
using EShop.Infrastructure.Command.Product;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MassTransit;
using EShop.Infrastructure.Query.Product;

//"applicationUrl": "http://localhost:25848" //6355

namespace EShop.ApiGateWay.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IBusControl _bus;
		//private readonly IConfiguration _configuration;
		private readonly IRequestClient<GetProductById> _requestClient;

		public ProductController(
			IBusControl busControl,
			//IConfiguration configuration,
			IRequestClient<GetProductById> requestClient)
		{
			_bus = busControl;
			//_configuration = configuration;
			_requestClient = requestClient;
		}

		[HttpGet]
		public async Task<IActionResult> Get(string productId)
		{
			var element = new GetProductById() {ProductId = productId};

			var product = await _requestClient.GetResponse<GetProductById>(element);

			return Accepted(product);
		}

		//[HttpGet]
		//public async Task<IActionResult> Get([FromForm] CreateProduct product)
		//{
		//	await Task.CompletedTask;
		//	return Accepted("Get product method called successfully!");
		//}

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
