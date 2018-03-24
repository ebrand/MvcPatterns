using System;
using MvcPatterns.Models;
using MvcPatterns.Repositories.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace MvcPatterns.Repositories.Fake
{
	public class GalaxyRepository : ISyncRepository<Galaxy>
	{
		List<Galaxy> _coll;

		public GalaxyRepository()
		{
			_coll = InMemoryDb.Instance.Galaxies;
		}

		public Galaxy Create(Galaxy obj)
		{
			if(!_coll.Contains(obj))
				_coll.Add(obj);
			return obj;
		}

		public Galaxy Retrieve(int id)
		{
			return _coll.FirstOrDefault(g => g.Id == id);
		}

		public void Update(Galaxy obj)
		{
			var galaxy = _coll.FirstOrDefault(g => g.Id == obj.Id);
			if(galaxy != null)
			{
				galaxy.CopyFrom(obj);
			}
		}

		public void Delete(int id)
		{
			if(_coll.FirstOrDefault(g => g.Id == id) != null)
				_coll.Remove(_coll.First(g => g.Id == id));
		}
	}
}