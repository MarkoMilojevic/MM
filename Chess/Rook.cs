using System;
using System.Collections.Generic;
using System.Drawing;
using MM.Chess.Properties;

namespace MM.Chess
{
	public class Rook : ChessPiece
	{
		public override Image Image => this.Suit == ChessPieceSuit.White ? Resources.WhiteRook : Resources.BlackRook;

		public override Image HighlightedImage => this.Suit == ChessPieceSuit.White ? Resources.WhiteRookHighlighted : Resources.BlackRookHighlighted;

		public override IEnumerable<ChessField> ReachableFields
		{
			get
			{
				List<ChessField> reachableFields = new List<ChessField>();
				reachableFields.AddRange(this.ExploreUp());
				reachableFields.AddRange(this.ExploreRight());
				reachableFields.AddRange(this.ExploreDown());
				reachableFields.AddRange(this.ExploreLeft());
				return reachableFields;
			}
		}

		public Rook(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
		}

		public override ChessPiece SpecialMoveTo(ChessField field)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<ChessField> ExploreUp()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			for (int i = this.Row + 1; i < Chessboard.Size; i++)
			{
				ChessField field = this.Chessboard.FieldAt(i, this.Column);
				if (field.ChessPiece == null)
				{
					reachableFields.Add(field);
				}
				else
				{
					if (field.ChessPiece.Suit != this.Suit)
					{
						reachableFields.Add(field);
					}

					break;
				}
			}

			return reachableFields;
		}

		private IEnumerable<ChessField> ExploreRight()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			for (int i = this.Column + 1; i < Chessboard.Size; i++)
			{
				ChessField field = this.Chessboard.FieldAt(this.Row, i);
				if (field.ChessPiece == null)
				{
					reachableFields.Add(field);
				}
				else
				{
					if (field.ChessPiece.Suit != this.Suit)
					{
						reachableFields.Add(field);
					}

					break;
				}
			}

			return reachableFields;
		}

		private IEnumerable<ChessField> ExploreDown()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			for (int i = this.Row - 1; i >= 0; i--)
			{
				ChessField field = this.Chessboard.FieldAt(i, this.Column);
				if (field.ChessPiece == null)
				{
					reachableFields.Add(field);
				}
				else
				{
					if (field.ChessPiece.Suit != this.Suit)
					{
						reachableFields.Add(field);
					}

					break;
				}
			}

			return reachableFields;
		}

		private IEnumerable<ChessField> ExploreLeft()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			for (int i = this.Column - 1; i >= 0; i--)
			{
				ChessField field = this.Chessboard.FieldAt(this.Row, i);
				if (field.ChessPiece == null)
				{
					reachableFields.Add(field);
				}
				else
				{
					if (field.ChessPiece.Suit != this.Suit)
					{
						reachableFields.Add(field);
					}

					break;
				}
			}

			return reachableFields;
		}
	}
}
