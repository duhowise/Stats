namespace Stats.DataAccess.Entities
{
	public class GameEvent:EntityBase
	{
		public virtual Game Game { get; set; }
		public virtual Player Player { get; set; }
		public virtual int PointValue { get; set; }
	}
}