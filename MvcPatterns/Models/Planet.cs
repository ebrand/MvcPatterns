using System;
using MvcPatterns.Models.Enums;
using MvcPatterns.Models.Interfaces;

namespace MvcPatterns.Models
{
	public class Planet : ICopyFrom<Planet>, ICloneable
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public PlanetClass PlanetClass { get; set; }
		public Point3D Location { get; set; }

		public Planet(int id, string name, PlanetClass planetClass, Point3D location)
		{
			this.Id = id;
			this.Name = name;
			this.PlanetClass = PlanetClass;
			this.Location = location;
		}

		public void CopyFrom(Planet source)
		{
			this.Id = source.Id;
			this.Name = source.Name;
			this.PlanetClass = source.PlanetClass;
		}

		public object Clone()
		{
			return new Planet(this.Id, this.Name, this.PlanetClass, this.Location);
		}
	}
}