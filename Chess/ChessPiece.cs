﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MM.Chess
{
	public abstract class ChessPiece
	{
		public ChessField ChessField { get; internal set; }

		public int Row => this.ChessField.Row;

		public int Column => this.ChessField.Column;

		public abstract Image Image { get; }
		public abstract Image HighlightedImage { get; }

		public abstract IEnumerable<ChessField> ReachableFields { get; }
		public readonly ChessPieceSuit Suit;
		protected Chessboard Chessboard;

		protected ChessPiece(Chessboard chessboard, ChessPieceSuit suit)
		{
			if (chessboard == null)
			{
				throw new ArgumentException("");
			}

			this.Chessboard = chessboard;
			this.Suit = suit;
		}

		public bool IsFieldReachable(ChessField field)
		{
			if (field == null)
			{
				throw new ArgumentException("");
			}

			return this.ReachableFields.Contains(field);
		}

		public ChessPiece MoveTo(ChessField field)
		{
			if (field == null)
			{
				throw new ArgumentException("");
			}

			if (!this.IsFieldReachable(field))
			{
				throw new ArgumentException("");
			}

			ChessPiece eatenPiece = field.ChessPiece;
			this.ChessField.ChessPiece = null;
			field.ChessPiece = this;
			return eatenPiece;
		}

		public abstract ChessPiece SpecialMoveTo(ChessField field);
	}
}
