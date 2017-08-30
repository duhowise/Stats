using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stats.DataAccess;
using Stats.Filters;
using Stats.Models;

namespace Stats.Controllers
{
	public class GameController : BaseController
	{
		public GameController(IStatsService statsService) : base(statsService)
		{
		}

		public IHttpActionResult Get()
		{
			try
			{
				var games = StatsService.Games.Get();
				var models = games.Select(ModelFactory.Create);

				return Ok(models);
			}
			catch (Exception e)
			{
#if DEBUG
				return InternalServerError(e);
#endif
#pragma warning disable 162
				return InternalServerError();
#pragma warning restore 162
			}
			


		}

		//[ModelValidator]
		public IHttpActionResult CreateEvent(GameEventModel gameEventModel)
		{
			try
			{
				var gameEntity = StatsService.Games.Get(gameEventModel.GameId);
				var playerEntity = StatsService.Players.Get(gameEventModel.PlayerId);
				var pointvalue = gameEventModel.PointValue;
				var gameEventEntity = ModelFactory.Create(gameEntity, playerEntity, pointvalue);
				StatsService.Events.Insert(gameEventEntity);

				return Created($"http://localhost:30329/api/game/{gameEntity.Id}",gameEventModel);
			}
			catch (Exception e)
			{
#if DEBUG
				return InternalServerError(e);
#endif
#pragma warning disable 162
				return InternalServerError();
#pragma warning restore 162
			}
		}


		public IHttpActionResult Get(int id)
		{
			try
			{
				var game = StatsService.Games.Get(id);
				var model = ModelFactory.Create(game);

				return Ok(model);
			}
			catch (Exception e)
			{
#if DEBUG
				return InternalServerError(e);
#endif
#pragma warning disable 162
				return InternalServerError();
#pragma warning restore 162
			}
		}
	}
}
