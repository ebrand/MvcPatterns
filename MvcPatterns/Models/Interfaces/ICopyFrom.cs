using System;

namespace MvcPatterns.Models.Interfaces
{
	public interface ICopyFrom<T>
	{
		void CopyFrom(T source);
	}
}