using System;
using System.Threading.Tasks;

namespace MvcPatterns.Repositories.Interfaces
{
	public interface IAsyncRepository<T>
	{
		Task<T> Create(T obj);
		Task<T> Retrieve(int id);
		Task Update(T obj);
		Task Delete(int id);
	}
}