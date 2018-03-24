using System;
using System.Collections.Generic;
using MvcPatterns.Models;
namespace MvcPatterns.Repositories.Fake
{
	public class InMemoryDb
	{
		#region Singleton implementation
		private static readonly InMemoryDb _instance = new InMemoryDb();
		static InMemoryDb() { }
		public static InMemoryDb Instance
		{
			get { return _instance; }
		}
		#endregion

		List<Universe> _universes;
		List<Galaxy> _galaxies;
		List<Star> _stars;
		List<Planet> _planets;

		public List<Universe> Universes => _universes;
		public List<Galaxy> Galaxies => _galaxies;
		public List<Star> Stars => _stars;
		public List<Planet> Planets => _planets;

		private InMemoryDb()
		{
			Init();
		}

		private void Init()
		{
			_universes = new List<Universe>();
			_galaxies = new List<Galaxy>();
			_stars = new List<Star>();
			_planets = new List<Planet>();
		}
	}
}