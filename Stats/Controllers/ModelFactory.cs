using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;
using Stats.DataAccess.Entities;
using Stats.Models;

namespace Stats.Controllers
{
	public class ModelFactory : IModelFactory
	{
		private  HttpRequestMessage _request;
		private UrlHelper urlHelper;

		public ModelFactory(HttpRequestMessage request)
		{
			_request = request;

			urlHelper=new UrlHelper(_request);
		}

		public PlayerModel Create(Player player)
		{
			return  new PlayerModel { Url =urlHelper.Link("DefaultApi",new {Id=player.Id}) , FirstName = player.FirstName,LastName = player.LastName,Id = player.Id,TeamId =player.Team?.Id ?? 0 ,TeamName = player.Team?.Name};
		}

		public Player Create(PlayerModel playerModel)
		{
			if (playerModel.Id==0)
			{
				return new Player {
					FirstName = playerModel.FirstName,
					LastName = playerModel.LastName,
					Id = playerModel.Id,
					UpdatedDate = DateTime.Now};

			}
			return new Player {
				FirstName = playerModel.FirstName,
				LastName = playerModel.LastName,
				Id = playerModel.Id,
				UpdatedDate = DateTime.Now};

		}

		public Team Create(TeamModel teamModel)
		{
			if (teamModel.Id == 0)
			{
				return new Team
				{
					Name = teamModel.Name,
					Players = new List<Player>(teamModel.Players.Select(Create)),
					UpdatedDate = DateTime.Now
				};
			}

			return new Team
			{
				Id = teamModel.Id,
				Name = teamModel.Name,
				Players = new List<Player>(teamModel.Players.Select(Create)),
				UpdatedDate = DateTime.Now
			};
		}

		public TeamModel Create(Team team)
		{
			
			return new TeamModel {Id = team.Id,
				Name = team.Name,
				Players =new List<PlayerModel>(team.Players.Select(Create))
				
			};
		}

		public GameModel Create(Game game)
		{
			return new GameModel
			{
				Id = game.Id,
				HomeTeam = Create(game.HomeTeam),
				AwayTeam = Create(game.AwayTeam),
				Events = game.Events.Select(Create).ToList(),
				StartTime = game.StartTime
		};
		}

		public Game Create(GameModel gameModel)
		{
			throw new NotImplementedException();
		}

		public GameEventModel Create(GameEvent gameModel)
		{
			return new GameEventModel
			{
				GameId = gameModel.Id,
				PlayerId = gameModel.Player.Id,
				PointValue = gameModel.PointValue,
				Url = urlHelper.Link("DefaultApi",new {Id=gameModel.Id})
			};
		}

		public GameEvent Create(Game game, Player player, int pointValue)
		{
			return new GameEvent { Game = game, Player = player, PointValue = pointValue, UpdatedDate = DateTime.Now };
		}
	}
}