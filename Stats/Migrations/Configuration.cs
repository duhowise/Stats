using System.Collections.Generic;
using Stats.DataAccess.Entities;

namespace Stats.Migrations
{
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<Stats.DataAccess.StatsDbContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(Stats.DataAccess.StatsDbContext context)
		{
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method 
			//  to avoid creating duplicate seed data. E.g.
			//
			//    context.People.AddOrUpdate(
			//      p => p.FullName,
			//      new Person { FullName = "Andrew Peters" },
			//      new Person { FullName = "Brice Lambson" },
			//      new Person { FullName = "Rowan Miller" }
			//    );
			//



			var player = new Player{FirstName = "John",LastName = "Doe",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now};
			var player1 = new Player{FirstName = "Sylvester",LastName = "stallone",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now};
			var playe2r = new Player{FirstName = "Rickky",LastName = "Jonson",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now};
			var player3 = new Player{FirstName = "Bobby",LastName = "Frank",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now};
			
			var t1=new Team {Name = "Rhinos",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now,Players = new List<Player> {player,player1} };
			var t2=new Team {Name = "Eagles",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now,Players = new List<Player> {playe2r,player3} };

			player.Team = t1;
			player1.Team = t1;
			playe2r.Team = t2;
			player3.Team = t2;

			var game=new Game {AwayTeam = t2,HomeTeam = t1,CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now,StartTime = DateTime.Now};

			context.Players.Add(player);
			context.Players.Add(playe2r);
			context.Players.Add(player1);
			context.Players.Add(player3);

			context.Teams.Add(t1);
			context.Teams.Add(t2);
			context.Games.Add(game);

		}
	}
}
