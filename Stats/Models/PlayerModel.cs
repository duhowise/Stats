﻿using System.ComponentModel.DataAnnotations;

namespace Stats.Models
{
	public class PlayerModel
	{
		public int Id { get; set; }
		public string Url { get; set; }
		[Required]public string FirstName { get; set; }
		[Required]public string LastName { get; set; }
		public int TeamId { get; set; }
		public string TeamName { get; set; }
	}
}