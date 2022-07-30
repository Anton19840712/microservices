using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Services
{
	public interface IProductService
	{
		Task<ProductCreated> GetProduct(Guid ProductId);
		Task<ProductCreated> AddProduct(CreateProduct product);

	}
}
