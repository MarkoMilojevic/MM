using System;

namespace MM.Chess
{
	public class MoveCommand
	{
		public readonly ChessPiece Piece;
		public readonly ChessField From;
		public readonly ChessField To;

		public MoveCommand(ChessPiece piece, ChessField from, ChessField to)
		{
			if ((piece == null) || (from == null) || (to == null))
			{
				throw new ArgumentNullException("");
			}

			this.Piece = piece;
			this.From = from;
			this.To = to;
		}
	}
}
