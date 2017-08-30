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
	public class TeamController : BaseController
	{

		

		public TeamController(IStatsService statsService) : base(statsService)
		{
		
		}

		public IHttpActionResult Get()
		{
			try
			{
				var teams = StatsService.Teams.Get();
				var models = teams.Select(ModelFactory.Create);
				return Ok(models);

			}
			catch (Exception e)
			{
			#if DEBUG
				return InternalServerError(e);
			#endif
#pragma warning disable 162
				return InternalServerError()
					;
#pragma warning restore 162
			}
		}

		public IHttpActionResult Get(int id)
		{
			try
			{
				var team = StatsService.Teams.Get(id);
				return Ok(ModelFactory.Create(team));
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
		public IHttpActionResult Post([FromBody] TeamModel teamModel)
		{
			try
			{
				var team = ModelFactory.Create(teamModel);
				team = StatsService.Teams.Insert(team);
				var model = ModelFactory.Create(team);
				return Created($"http://localhost:30329/api/Team/{model.Id}", model);
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
