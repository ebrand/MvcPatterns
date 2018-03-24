using System;
using MvcPatterns.Repositories.Interfaces;
using MvcPatterns.Models;
using MvcPatterns.Models.Enums;
using Bogus;

namespace MvcPatterns.Repositories.Fake
{
	public static class FakeGenerator
	{
		static ISyncRepository<Universe> _universeRepo = new UniverseRepository();
		static ISyncRepository<Galaxy> _galaxyRepo = new GalaxyRepository();
		static ISyncRepository<Star> _starRepo = new StarRepository();
		static ISyncRepository<Planet> _planetRepo = new PlanetRepository();

		static Faker<Point3D> _pointFaker;
		static Faker<Planet> _planetFaker;
		static Faker<Star> _starFaker;
		static Faker<Galaxy> _galaxyFaker;
		static Faker<Universe> _universeFaker;

		public static void Init()
		{
			_pointFaker = new Faker<Point3D>()
				.RuleFor(l => l.X, f => f.Random.Decimal(-1.0M, 1.0M))
				.RuleFor(l => l.Y, f => f.Random.Decimal(-1.0M, 1.0M))
				.RuleFor(l => l.Z, f => f.Random.Decimal(-1.0M, 1.0M));
			
			_planetFaker = new Faker<Planet>()
				.RuleFor(p => p.Id, f => f.IndexFaker)
				.RuleFor(p => p.Name, f => f.Lorem.Word())
				.RuleFor(p => p.PlanetClass, f => f.PickRandom<PlanetClass>())
				.RuleFor(p => p.Location, _pointFaker.Generate());

			_starFaker = new Faker<Star>()
				.RuleFor(s => s.Id, f => f.IndexFaker)
				.RuleFor(s => s.Name, f => f.Lorem.Word())
				.RuleFor(s => s.StarClass, f => f.PickRandom<StarClass>())
				.RuleFor(s => s.Luminosity, f => f.Random.Decimal(0.0M, 100.0M))
				.RuleFor(s => s.AbsoluteMagnitude, f => f.Random.Decimal(0.0M, 100.0M))
				.RuleFor(s => s.DiameterInMeters, f => f.Random.Decimal(1000.0M, 10000.0M))
				.RuleFor(s => s.Location, f => _pointFaker.Generate())
				.RuleFor(s => s.Planets, f => _planetFaker.Generate(f.Random.Int(0, 20)));

			_galaxyFaker = new Faker<Galaxy>()
				.RuleFor(g => g.Id, f => f.IndexFaker)
				.RuleFor(g => g.Name, f => f.Lorem.Word())
				.RuleFor(g => g.GalaxyClass, f => f.PickRandom<GalaxyClass>())
				.RuleFor(g => g.RotationalSpeedInKph, f => f.Random.Decimal(0.0M, 1500.0M))
				.RuleFor(g => g.SolarMass, f => f.Random.Decimal(1.0M, 1000.0M))
				.RuleFor(g => g.Location, f => _pointFaker.Generate())
				.RuleFor(g => g.Stars, f => _starFaker.Generate(f.Random.Int(1000, 10000)));

			_universeFaker = new Faker<Universe>()
				.RuleFor(u => u.Id, f => f.IndexFaker)
				.RuleFor(u => u.Name, f => f.Lorem.Word())
				.RuleFor(u => u.Galaxies, f => _galaxyFaker.Generate(f.Random.Int(1, 100)));
		}

		public static void CreateUniverse()
		{
			_universeRepo.Create(_universeFaker.Generate());
		}

		public static void CreateGalaxy()
		{
			_galaxyRepo.Create(_galaxyFaker.Generate());
		}

		public static void CreateStar()
		{
			_starRepo.Create(_starFaker.Generate());
		}

		public static void CreatePlanet()
		{
			_planetRepo.Create(_planetFaker.Generate());
		}
	}
}