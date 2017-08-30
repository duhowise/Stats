using Stats.DataAccess.Entities;
using Stats.Models;

namespace Stats.Controllers
{
	public interface IModelFactory
	{
		PlayerModel Create(Player player);
		Player Create(PlayerModel playerModel);
		Team Create(TeamModel teamModel);
		TeamModel Create(Team team);
		GameModel Create(Game game);
		Game Create(GameModel gameModel);
		GameEventModel Create(GameEvent gameModel);
		GameEvent Create(Game game,Player player,int pointValue);

		
	}
}