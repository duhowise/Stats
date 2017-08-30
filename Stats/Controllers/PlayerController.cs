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
	public class PlayerController : BaseController
	{
		
		public PlayerController(IStatsService statsService) : base(statsService)
		{
			
		}

		public IHttpActionResult Get()
		{
			try
			{
				var players = StatsService.Players.Get();
				var models = players.Select(ModelFactory.Create);
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

		public IHttpActionResult Get(int id)
		{
			try
			{
				var player = StatsService.Players.Get(id);
				return Ok(ModelFactory.Create(player));
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

		[ModelValidator]
		public IHttpActionResult Post([FromBody] PlayerModel playerModel)
		{
			try
			{
				var player = ModelFactory.Create(playerModel);
				player = StatsService.Players.Insert(player);
				var model = ModelFactory.Create(player);
				return Created(playerModel.Url, model);
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

		[ModelValidator]public IHttpActionResult Put(PlayerModel playerModel)
		{
			try
			{
				var player = ModelFactory.Create(playerModel);
				player = StatsService.Players.Update(player);
				var model = ModelFactory.Create(player);
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


		public IHttpActionResult Delete(int id)
		{
			try
			{
				var player = StatsService.Players.Get(id);
				if (player != null)
					StatsService.Players.Delete(player);
				else
				{
					return NotFound();
				}
				return Ok();

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
