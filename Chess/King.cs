using System;
using System.Collections.Generic;
using System.Drawing;
using MM.Chess.Properties;

namespace MM.Chess
{
	public class King : ChessPiece
	{
		public override Image Image => this.Suit == ChessPieceSuit.White ? Resources.WhiteKing : Resources.BlackKing;

		public override Image HighlightedImage => this.Suit == ChessPieceSuit.White ? Resources.WhiteKingHighlighted : Resources.BlackKingHighlighted;

		public override IEnumerable<ChessField> ReachableFields
		{
			get
			{
				List<ChessField> reachableFields = new List<ChessField>();
				for (int i = -1; i <= 1; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						if ((i == 0) && (j == 0))
						{
							continue;
						}

						int row = this.Row + i;
						int column = this.Column + j;
						if ((row >= 0) && (row < Chessboard.Size) && (column >= 0) && (column < Chessboard.Size))
						{
							ChessField field = this.Chessboard.FieldAt(row, column);
							if ((field.ChessPiece == null) || ((field.ChessPiece != null) && (field.ChessPiece.Suit != this.Suit)))
							{
								reachableFields.Add(field);
							}
						}
					}
				}

				return reachableFields;
			}
		}

		public King(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
		}

		public override ChessPiece SpecialMoveTo(ChessField field)
		{
			throw new NotImplementedException();
		}
	}
}
