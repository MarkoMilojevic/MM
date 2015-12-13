using System;
using System.Collections.Generic;

namespace MM.Chess
{
	public class King : ChessPiece
	{
		public King(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}

		public override IEnumerable<ChessField> GetReachableFields()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (i == 0 && j == 0)
					{
						continue;
					}

					int row = this.Row + i;
					int column = this.Column + j;
					if (row >= 0 && row < Chessboard.Dimension && column >= 0 && column < Chessboard.Dimension)
					{
						ChessField field = this.chessboard.ChessFieldAt(this.Row + i, this.Column + j);
						if (field.ChessPiece == null || (field.ChessPiece != null && field.ChessPiece.Suit != this.Suit))
						{
							reachableFields.Add(field);
						}
					}
				}
			}

			return reachableFields;
		}

		public override ChessPiece SpecialMoveTo(ChessField field)
		{
			throw new NotImplementedException();
		}
	}
}
