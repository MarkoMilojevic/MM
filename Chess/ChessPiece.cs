using System;
using System.Collections.Generic;
using System.Linq;

namespace MM.Chess
{
	public enum ChessPieceSuit
	{
		WHITE, BLACK
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
		
		public ChessPiece(Chessboard chessboard, ChessPieceSuit suit)
		{
			if (chessboard == null)
			{
				throw new ArgumentException("");
			}

			this.chessboard = chessboard;
			this.Suit = suit;
		}

		public abstract IEnumerable<ChessField> GetReachableFields();

		public bool IsFieldReachable(ChessField field)
		{
			if (field == null)
			{
				throw new ArgumentException("");
			}

			return this.GetReachableFields().Contains(field);
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
