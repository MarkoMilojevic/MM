namespace MM.Chess
{
	public class Player
	{
		public int TimeToPlay { get; set; }
		public readonly King King;
		public readonly ChessPieceSuit Suit;

		public Player(ChessPieceSuit suit, King king, int timeToPlay)
		{
			this.Suit = suit;
			this.King = king;
			this.TimeToPlay = timeToPlay;
		}
	}
}
