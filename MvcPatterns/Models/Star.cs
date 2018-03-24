using System;
using System.Collections.Generic;
using MvcPatterns.Models.Enums;
using MvcPatterns.Models.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace MvcPatterns.Models
{
	public class Star : ICopyFrom<Star>, ICloneable
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public StarClass StarClass { get; set; }
		public decimal Luminosity { get; set; }
		public decimal AbsoluteMagnitude { get; set; }
		public decimal DiameterInMeters { get; set; }
		public Point3D Location { get; set; }
		public List<Planet> Planets { get; set; }

		public Star(
			int Id, 
			string name, 
			StarClass starClass, 
			decimal luminosity, 
			decimal absoluteMagnitude, 
			decimal diameterInMeters, 
			Point3D location
		){
			this.Id = Id;
			this.Name = name;
			this.StarClass = starClass;
			this.Luminosity = luminosity;
			this.AbsoluteMagnitude = absoluteMagnitude;
			this.DiameterInMeters = diameterInMeters;
			this.Location = location;
			this.Planets = new List<Planet>();
		}

		public void CopyFrom(Star source)
		{
			this.Id = source.Id;
			this.Name = source.Name;
			this.StarClass = source.StarClass;
			this.Luminosity = source.Luminosity;
			this.AbsoluteMagnitude = source.AbsoluteMagnitude;
			this.DiameterInMeters = source.DiameterInMeters;
			this.Location = source.Location;
			this.Planets.Clear();
			foreach(var p in source.Planets)
			{
				this.Planets.Add(p.Clone() as Planet);
			}
		}

		public object Clone()
		{
			var star = new Star(this.Id, this.Name, this.StarClass, this.Luminosity, this.AbsoluteMagnitude, this.DiameterInMeters, this.Location);
			foreach(var p in this.Planets)
			{
				star.Planets.Add(p.Clone() as Planet);
			}
			return star;
		}
	}
}