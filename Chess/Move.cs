﻿using System;

namespace MM.Chess
{
	public class Move
	{
		public readonly ChessPiece Piece;
		public readonly ChessPiece OpponentsPiece;
		public readonly ChessField From;
		public readonly ChessField To;

		public Move(ChessPiece piece, ChessField from, ChessField to)
		{
			if ((piece == null) || (from == null) || (to == null))
			{
				throw new ArgumentNullException("");
			}

			this.Piece = piece;
			this.OpponentsPiece = to.ChessPiece;
			this.From = from;
			this.To = to;
		}
	}
}