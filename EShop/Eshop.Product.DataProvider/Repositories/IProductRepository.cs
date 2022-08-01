using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using System;
using System.Threading.Tasks;

namespace Eshop.Product.DataProvider.Repositories
{
	public interface IProductRepository
	{
		Task<ProductCreated> GetProduct(string productId);
		Task<ProductCreated> AddProduct(CreateProduct product);
	}
}
