using Stats.DataAccess.Entities;
using Stats.DataAccess.Repositories;

namespace Stats.DataAccess
{
	public interface IStatsService
	{
		Repository<Team> Teams { get;  }
		Repository<Game> Games { get;  }
		Repository<Player> Players { get;  }
		Repository<GameEvent> Events { get;  }
	}
}