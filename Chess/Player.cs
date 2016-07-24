namespace MM.Chess
{
	public class Player
	{
		public int TimeToPlayInSeconds { get; set; }
		public readonly King King;
		public readonly ChessPieceSuit Suit;

		public Player(ChessPieceSuit suit, King king, int timeToPlayInSeconds)
		{
			this.Suit = suit;
			this.King = king;
			this.TimeToPlayInSeconds = timeToPlayInSeconds;
		}
	}
}
