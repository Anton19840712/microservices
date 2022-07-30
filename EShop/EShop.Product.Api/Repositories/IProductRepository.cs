using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using System;
using System.Threading.Tasks;

namespace EShop.Product.Api.Repositories
{
	public interface IProductRepository
	{
		Task<ProductCreated> GetProduct(Guid ProductId);
		Task<ProductCreated> AddProduct(CreateProduct product);

	}
}
