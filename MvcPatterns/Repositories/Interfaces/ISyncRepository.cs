using System;

namespace MvcPatterns.Repositories.Interfaces
{
	public interface ISyncRepository<T>
	{
		T Create(T obj);
		T Retrieve(int id);
		void Update(T obj);
		void Delete(int id);
	}
}