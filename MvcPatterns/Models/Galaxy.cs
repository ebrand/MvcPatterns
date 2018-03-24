using System;
using System.Collections.Generic;
using MvcPatterns.Models.Enums;
using MvcPatterns.Models.Interfaces;

namespace MvcPatterns.Models
{
	public class Galaxy : ICopyFrom<Galaxy>, ICloneable
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public GalaxyClass GalaxyClass { get; set; }
		public decimal RotationalSpeedInKph { get; set; }
		public decimal SolarMass { get; set; }
		public Point3D Location { get; set; }
		public List<Star> Stars { get; set; }

		public Galaxy(
			int id, 
			string name, 
			GalaxyClass galaxyClass, 
			decimal rotationalSpeedInKph, 
			decimal solarMass, 
			Point3D location
		){
			this.Id = id;
			this.Name = name;
			this.GalaxyClass = galaxyClass;
			this.RotationalSpeedInKph = rotationalSpeedInKph;
			this.SolarMass = solarMass;
			this.Location = location;
			this.Stars = new List<Star>();
		}

		public void CopyFrom(Galaxy source)
		{
			this.Id = source.Id;
			this.Name = source.Name;
			this.GalaxyClass = source.GalaxyClass;
			this.RotationalSpeedInKph = source.RotationalSpeedInKph;
			this.SolarMass = source.SolarMass;
			this.Location = source.Location;
			this.Stars.Clear();
			foreach(var s in source.Stars)
			{
				this.Stars.Add(s.Clone() as Star);
			}
		}

		public object Clone()
		{
			var galaxy = new Galaxy(this.Id, this.Name, this.GalaxyClass, this.RotationalSpeedInKph, this.SolarMass, this.Location);
			foreach(var s in this.Stars){
				galaxy.Stars.Add(s.Clone() as Star);
			}
			return galaxy;
		}
	}
}