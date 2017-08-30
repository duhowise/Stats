using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Stats.DataAccess;

namespace Stats.Controllers
{
	public abstract class BaseController : ApiController
	{
		private  IModelFactory _modelFactory;
		private readonly IStatsService _service;

		protected BaseController( IStatsService statsService)
		{
			_service = statsService;
		}

		protected IModelFactory ModelFactory
		{
			get
			{
				if (_modelFactory==null)
					_modelFactory=new ModelFactory(Request);
				return _modelFactory;
			}
		}

		protected IStatsService StatsService
		{
			get { return _service; }
		}
	}
}
