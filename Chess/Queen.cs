using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MM.Chess.Properties;

namespace MM.Chess
{
	public class Queen : ChessPiece
	{
		public override Image Image => this.Suit == ChessPieceSuit.White ? Resources.WhiteQueen : Resources.BlackQueen;

		public override Image HighlightedImage => this.Suit == ChessPieceSuit.White ? Resources.WhiteQueenHighlighted : Resources.BlackQueenHighlighted;

		public override IEnumerable<ChessField> ReachableFields
		{
			get
			{
				List<ChessField> reachableFields = new List<ChessField>();
				reachableFields.AddRange(this.ExploreUp());
				reachableFields.AddRange(this.ExploreUpRight());
				reachableFields.AddRange(this.ExploreRight());
				reachableFields.AddRange(this.ExploreDownRight());
				reachableFields.AddRange(this.ExploreDown());
				reachableFields.AddRange(this.ExploreDownLeft());
				reachableFields.AddRange(this.ExploreLeft());
				reachableFields.AddRange(this.ExploreUpLeft());
				return reachableFields;
			}
		}

		public Queen(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
		}

		public override bool IsSpecialMoveAvailable(Move move)
		{
			return false;
		}

		public override IEnumerable<Move> GetSpecialMoveSequence(Move move)
		{
			if (!this.IsSpecialMoveAvailable(move))
			{
				throw new InvalidOperationException("");
			}

			return Enumerable.Empty<Move>();
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
