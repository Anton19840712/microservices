using EShop.Infrastructure.Command.Product;
using EShop.Infrastructure.Event.Product;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Product.Api.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly IMongoDatabase _database;

		private readonly IMongoCollection<CreateProduct> _collection;

		public ProductRepository(IMongoDatabase database)
		{
			_database = database;

			_collection = database.GetCollection<CreateProduct>("product");
		}
		public async Task<ProductCreated> AddProduct(CreateProduct product)
		{
			await _collection.InsertOneAsync(product);

			return new ProductCreated()
			{
				ProductId = product.ProductId,
				CreatedAt= DateTime.UtcNow,
				ProductName = product.ProductName,
			};
		}

		public async Task<ProductCreated> GetProduct(string productId)
		{
			var product = _collection.AsQueryable().Where(x => x.ProductId == productId).FirstOrDefault();

			if (product == null) throw new Exception("product not found");

			await Task.CompletedTask;

			return new ProductCreated
			{
				ProductId = product.ProductId,
				CreatedAt = DateTime.UtcNow,
				ProductName = product.ProductName,
			};
		}
	}
}
