using System;
using MvcPatterns.Models;
using MvcPatterns.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MvcPatterns.Repositories.Fake
{
	public class StarRepository : ISyncRepository<Star>
	{
		List<Star> _coll;

		public StarRepository()
		{
			_coll = InMemoryDb.Instance.Stars;
		}

		public Star Create(Star obj)
		{
			if(!_coll.Contains(obj))
				_coll.Add(obj);
			return obj;
		}

		public Star Retrieve(int id)
		{
			return _coll.FirstOrDefault(s => s.Id == id);
		}

		public void Update(Star obj)
		{
			var star = _coll.FirstOrDefault(s => s.Id == obj.Id);
			if(star != null)
			{
				star.CopyFrom(obj);
			}
		}

		public void Delete(int id)
		{
			if(_coll.FirstOrDefault(s => s.Id == id) != null)
				_coll.Remove(_coll.First(s => s.Id == id));
		}
	}
}