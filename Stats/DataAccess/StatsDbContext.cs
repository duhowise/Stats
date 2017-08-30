using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Text;
using Stats.DataAccess.Entities;

namespace Stats.DataAccess
{
	public class StatsDbContext:DbContext
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Player> Players { get; set; }
		public DbSet<GameEvent> GameEvents { get; set; }

		

	}
}