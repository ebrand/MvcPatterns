using System;
using MvcPatterns.Repositories.Interfaces;
using MvcPatterns.Models;
using System.Linq;
using System.Collections.Generic;

namespace MvcPatterns.Repositories.Fake
{
	public class UniverseRepository : ISyncRepository<Universe>
	{
	 	List<Universe> _coll;

		public UniverseRepository()
		{
			_coll = InMemoryDb.Instance.Universes;
		}

		public Universe Create(Universe obj)
		{
			if(!_coll.Contains(obj))
				_coll.Add(obj);
			return obj;
		}

		public Universe Retrieve(int id)
		{
			return _coll.FirstOrDefault(u => u.Id == id);
		}

		public void Update(Universe obj)
		{
			var universe = _coll.FirstOrDefault(u => u.Id == obj.Id);
			if(universe != null)
			{
				universe.CopyFrom(obj);
			}
		}

		public void Delete(int id)
		{
			if(_coll.FirstOrDefault(u => u.Id == id) != null)
				_coll.Remove(_coll.First(u => u.Id == id));
		}
	}
}