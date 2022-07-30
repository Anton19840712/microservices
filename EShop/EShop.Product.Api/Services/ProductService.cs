using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Services
{
	public class ProductService : IProductService
	{
		public Task<ProductCreated> AddProduct(CreateProduct product)
		{
			throw new NotImplementedException();
		}

		public Task<ProductCreated> GetProduct(Guid ProductId)
		{
			throw new NotImplementedException();
		}
	}
}
