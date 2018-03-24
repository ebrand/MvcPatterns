using System;
using MvcPatterns.Models.Interfaces;

namespace MvcPatterns.Models
{
	public class Point3D : ICopyFrom<Point3D>, ICloneable
	{
		public decimal X { get; set; }
		public decimal Y { get; set; }
		public decimal Z { get; set; }

		public Point3D(decimal x, decimal y, decimal z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public void CopyFrom(Point3D source)
		{
			this.X = source.X;
			this.Y = source.Y;
			this.Z = source.Z;
		}

		public object Clone()
		{
			return new Point3D(this.X, this.Y, this.Z);
		}
	}
}