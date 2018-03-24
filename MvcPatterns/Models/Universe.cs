using System;
using System.Collections.Generic;
using MvcPatterns.Models.Interfaces;

namespace MvcPatterns.Models
{
	public class Universe : ICopyFrom<Universe>, ICloneable
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime Created { get; set; }
		public List<Galaxy> Galaxies { get; set; }

		public Universe(int id, string name)
		{
			this.Id = id;
			this.Name = name;
			this.Created = DateTime.UtcNow;
			this.Galaxies = new List<Galaxy>();
		}

		public void CopyFrom(Universe source)
		{
			this.Id = source.Id;
			this.Name = source.Name;
			this.Created = source.Created;
			this.Galaxies.Clear();
			foreach(var g in source.Galaxies)
			{
				this.Galaxies.Add(g.Clone() as Galaxy);
			}
		}

		public object Clone()
		{
			var universe =  new Universe(this.Id, this.Name);
			foreach(var g in this.Galaxies)
			{
				universe.Galaxies.Add(g.Clone() as Galaxy);
			}
			return universe;
		}
	}
}