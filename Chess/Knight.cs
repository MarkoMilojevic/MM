using System;
using System.Collections.Generic;

namespace MM.Chess
{
	public class Knight : ChessPiece
	{
		public Knight(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}

		public override IEnumerable<ChessField> GetReachableFields()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			for (int row = 0; row < Chessboard.Dimension; row++)
			{
				for (int column = 0; column < Chessboard.Dimension; column++)
				{
					ChessField field = this.chessboard.ChessFieldAt(row, column);
					if (IsAttackingField(field) && (field.ChessPiece == null || (field.ChessPiece != null && field.ChessPiece.Suit != this.Suit)))
					{
						reachableFields.Add(field);
					}
				}
			}

			return reachableFields;
		}

		public override ChessPiece SpecialMoveTo(ChessField field)
		{
			throw new NotImplementedException();
		}

		private bool IsAttackingField(ChessField field)
		{
			return (Math.Abs(field.Row - this.Row) == 2 && Math.Abs(field.Column - this.Column) == 1) 
				|| (Math.Abs(field.Row - this.Row) == 1 && Math.Abs(field.Column - this.Column) == 2);
		}
	}
}
