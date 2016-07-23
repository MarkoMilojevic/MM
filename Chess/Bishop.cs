using System;
using System.Collections.Generic;
using System.Drawing;
using MM.Chess.Properties;

namespace MM.Chess
{
	public class Bishop : ChessPiece
	{
		public override Image Image => this.Suit == ChessPieceSuit.White ? Resources.WhiteBishop : Resources.BlackBishop;

		public override Image HighlightedImage => this.Suit == ChessPieceSuit.White ? Resources.WhiteBishopHighlighted : Resources.BlackBishopHighlighted;

		public override IEnumerable<ChessField> ReachableFields
		{
			get
			{
				List<ChessField> reachableFields = new List<ChessField>();
				reachableFields.AddRange(this.ExploreUpRight());
				reachableFields.AddRange(this.ExploreDownRight());
				reachableFields.AddRange(this.ExploreDownLeft());
				reachableFields.AddRange(this.ExploreUpLeft());
				return reachableFields;
			}
		}

		public Bishop(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
		}

		public override bool IsSpecialMoveAvailable(Move move)
		{
			return false;
		}

		public override IEnumerable<Move> GetSpecialMoveSequence(Move move)
		{
			throw new InvalidOperationException("");
		}

		private IEnumerable<ChessField> ExploreUpRight()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			int n = Math.Min(Chessboard.Size - this.Row - 1, Chessboard.Size - this.Column - 1);
			for (int i = 1; i <= n; i++)
			{
				ChessField field = this.Chessboard.FieldAt(this.Row + i, this.Column + i);
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
			int n = Math.Min(this.Row, Chessboard.Size - this.Column - 1);
			for (int i = 1; i <= n; i++)
			{
				ChessField field = this.Chessboard.FieldAt(this.Row - i, this.Column + i);
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
				ChessField field = this.Chessboard.FieldAt(this.Row - i, this.Column - i);
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
			int n = Math.Min(Chessboard.Size - this.Row - 1, this.Column);
			for (int i = 1; i <= n; i++)
			{
				ChessField field = this.Chessboard.FieldAt(this.Row + i, this.Column - i);
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
