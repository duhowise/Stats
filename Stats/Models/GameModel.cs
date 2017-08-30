using System;
using System.Collections.Generic;
using Stats.DataAccess.Entities;

namespace Stats.Models
{
	public class GameModel
	{
		public int Id { get; set; }
		public TeamModel AwayTeam { get; set; }
		public TeamModel HomeTeam { get; set; }
		public DateTime StartTime { get; set; }

		public  List<GameEventModel> Events { get; set; }
	}
}