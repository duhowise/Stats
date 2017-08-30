using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Stats.DataAccess.Entities;

namespace Stats.Models
{
	public class TeamModel
	{
		public int Id { get; set; }
		[Required]public string Name { get; set; }
		public List<PlayerModel> Players { get; set; }
	}
}