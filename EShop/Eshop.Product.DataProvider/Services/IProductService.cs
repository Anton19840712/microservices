using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using System.Threading.Tasks;

namespace Eshop.Product.DataProvider.Services
{
	public interface IProductService
	{
		Task<ProductCreated> GetProduct(string productId);
		Task<ProductCreated> AddProduct(CreateProduct product);

	}
}
