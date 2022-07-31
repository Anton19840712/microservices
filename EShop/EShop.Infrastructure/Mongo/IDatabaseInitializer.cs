using System.Threading.Tasks;

namespace EShop.Infrastructure.Mongo
{
	public interface IDatabaseInitializer
	{
		Task InitializeAsync();
	}
}
