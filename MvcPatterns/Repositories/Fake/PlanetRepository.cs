using System;
using MvcPatterns.Repositories.Interfaces;
using MvcPatterns.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcPatterns.Repositories.Fake
{
	public class PlanetRepository : ISyncRepository<Planet>
	{
		List<Planet> _coll;

		public PlanetRepository()
		{
			_coll = InMemoryDb.Instance.Planets;
		}

		public Planet Create(Planet obj)
		{
			if(!_coll.Contains(obj))
				_coll.Add(obj);
			return obj;
		}

		public Planet Retrieve(int id)
		{
			return _coll.FirstOrDefault(p => p.Id == id);
		}

		public void Update(Planet obj)
		{
			var planet = _coll.FirstOrDefault(p => p.Id == obj.Id);
			if(planet != null)
			{
				planet.CopyFrom(obj);
			}
		}

		public void Delete(int id)
		{
			if(_coll.FirstOrDefault(p => p.Id == id) != null)
				_coll.Remove(_coll.First(p => p.Id == id));
		}
	}
}