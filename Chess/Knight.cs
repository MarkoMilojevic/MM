using System;
using System.Collections.Generic;
using System.Drawing;
using MM.Chess.Properties;

namespace MM.Chess
{
	public class Knight : ChessPiece
	{
		public override Image Image => this.Suit == ChessPieceSuit.White ? Resources.WhiteKnight : Resources.BlackKnight;

		public override Image HighlightedImage => this.Suit == ChessPieceSuit.White ? Resources.WhiteKnightHighlighted : Resources.BlackKnightHighlighted;

		public override IEnumerable<ChessField> ReachableFields
		{
			get
			{
				List<ChessField> reachableFields = new List<ChessField>();
				for (int row = 0; row < Chessboard.Size; row++)
				{
					for (int column = 0; column < Chessboard.Size; column++)
					{
						ChessField field = this.Chessboard.FieldAt(row, column);
						if (this.IsAttacking(field) && ((field.ChessPiece == null) || ((field.ChessPiece != null) && (field.ChessPiece.Suit != this.Suit))))
						{
							reachableFields.Add(field);
						}
					}
				}

				return reachableFields;
			}
		}

		public Knight(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
		}

		private bool IsAttacking(ChessField field)
		{
			return ((Math.Abs(field.Row - this.Row) == 2) && (Math.Abs(field.Column - this.Column) == 1))
			       || ((Math.Abs(field.Row - this.Row) == 1) && (Math.Abs(field.Column - this.Column) == 2));
		}

		public override bool IsSpecialMoveAvailable(Move move)
		{
			return false;
		}

		public override IEnumerable<Move> GetSpecialMoveSequence(Move move)
		{
			throw new InvalidOperationException("");
		}
	}
}
