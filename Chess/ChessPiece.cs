using System;

namespace MM.Chess
{
	public enum ChessPieceSuit
	{
		WHITE, BLACK
	}

	public enum ChessPieceType
	{
		PAWN, ROOK, KNIGHT, BISHOP, QUEEN, KING
	}

	public abstract class ChessPiece
	{
		protected Chessboard chessboard;
		public ChessField ChessField
		{
			get;
			internal set;
		}
		
		public int Row
		{
			get
			{
				return this.ChessField.Row;
			}
		}
		
		public int Column
		{
			get
			{
				return this.ChessField.Column;
			}
		}

		public ChessPieceSuit Suit
		{
			get;
			private set;
		}

		public abstract ChessPieceType Type
		{
			get;
		}

		public ChessPiece(Chessboard chessboard, ChessPieceSuit suit)
		{
			if (chessboard == null)
			{
				throw new ArgumentException("");
			}

			this.chessboard = chessboard;
			this.Suit = suit;
		}
	}
}
