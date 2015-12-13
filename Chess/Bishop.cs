using System;
using System.Collections.Generic;

namespace MM.Chess
{
	public class Bishop : ChessPiece
	{
		public Bishop(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{

		}

		public override IEnumerable<ChessField> GetReachableFields()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			reachableFields.AddRange(this.ExploreUpRight());
			reachableFields.AddRange(this.ExploreDownRight());
			reachableFields.AddRange(this.ExploreDownLeft());
			reachableFields.AddRange(this.ExploreUpLeft());
			return reachableFields;
		}

		public override ChessPiece SpecialMoveTo(ChessField field)
		{
			throw new NotImplementedException();
		}

		private IEnumerable<ChessField> ExploreUpRight()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			int n = Math.Min(Chessboard.Dimension - this.Row - 1, Chessboard.Dimension - this.Column - 1);
			for (int i = 1; i <= n; i++)
			{
				ChessField field = this.chessboard.ChessFieldAt(this.Row + i, this.Column + i);
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

		private IEnumerable<ChessField> ExploreDownRight()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			int n = Math.Min(this.Row, Chessboard.Dimension - this.Column - 1);
			for (int i = 1; i <= n; i++)
			{
				ChessField field = this.chessboard.ChessFieldAt(this.Row - i, this.Column + i);
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

		private IEnumerable<ChessField> ExploreDownLeft()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			int n = Math.Min(this.Row, this.Column);
			for (int i = 1; i <= n; i++)
			{
				ChessField field = this.chessboard.ChessFieldAt(this.Row - i, this.Column - i);
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

		private IEnumerable<ChessField> ExploreUpLeft()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			int n = Math.Min(Chessboard.Dimension - this.Row - 1, this.Column);
			for (int i = 1; i <= n; i++)
			{
				ChessField field = this.chessboard.ChessFieldAt(this.Row + i, this.Column - i);
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
