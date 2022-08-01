using Eshop.Product.DataProvider.Repositories;
using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using System.Threading.Tasks;

namespace Eshop.Product.DataProvider.Services
{
	public class ProductService : IProductService
	{
		private readonly IProductRepository _repository;
		public ProductService(IProductRepository repository)
		{
			_repository = repository;
		}

		public async Task<ProductCreated> AddProduct(CreateProduct product)
		{
			return await _repository.AddProduct(product);
		}

		public async Task<ProductCreated> GetProduct(string productId)
		{
			return await _repository.GetProduct(productId);
		}
	}
}
