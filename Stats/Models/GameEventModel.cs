using System.ComponentModel.DataAnnotations;

namespace Stats.Models
{
	public class GameEventModel
	{
		public string Url { get; set; }
		[Required]public int GameId { get; set; }
		[Required]public int  PlayerId { get; set; }
		[Required]public int PointValue { get; set; }

	}
}