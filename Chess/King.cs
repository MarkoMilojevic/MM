using System;
using System.Collections.Generic;
using System.ComponentModel;
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

		private readonly int startingRow;

		internal bool HasMoved;

		public King(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
			this.HasMoved = false;
			this.startingRow = this.Suit == ChessPieceSuit.White ? 0 : 7;
			this.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
			{
				if (e.PropertyName == nameof(this.ChessField))
				{
					this.HasMoved = true;
				}
			};
		}

		public override bool IsSpecialMoveAvailable(Move move)
		{
			if (this.HasMoved || this.Chessboard.IsAttackedByOpponent(this))
			{
				return false;
			}

			if (this.IsKingsideCastlingAvailable() && this.IsKingsideCastling(move))
			{
				return true;
			}

			if (this.IsQueensideCastlingAvailable() && this.IsQueensideCastling(move))
			{
				return true;
			}

			return false;
		}

		public override IEnumerable<Move> GetSpecialMoveSequence(Move move)
		{
			if (this.IsKingsideCastlingAvailable() && this.IsKingsideCastling(move))
			{
				return this.KingsideCastlingMoveSequence(move);
			}

			if (this.IsQueensideCastlingAvailable() && this.IsQueensideCastling(move))
			{
				return this.QueensideCastlingMoveSequence(move);
			}

			throw new InvalidOperationException("");
		}

		private bool IsKingsideCastling(Move move)
		{
			return move.To == this.Chessboard.FieldAt(this.startingRow, 6);
		}

		private bool IsQueensideCastling(Move move)
		{
			return move.To == this.Chessboard.FieldAt(this.startingRow, 2);
		}

		private bool IsKingsideCastlingAvailable()
		{
			if (this.Chessboard.IsAttackedByOpponent(this.Chessboard.FieldAt(this.startingRow, 5)) ||
			    this.Chessboard.IsAttackedByOpponent(this.Chessboard.FieldAt(this.startingRow, 6)))
			{
				return false;
			}

			if (this.Chessboard.PieceAt(this.startingRow, 7) is Rook)
			{
				Rook rook = (Rook) this.Chessboard.PieceAt(this.startingRow, 7);
				if ((rook.Suit != this.Suit) || rook.HasMoved)
				{
					return false;
				}
			}

			return true;
		}

		private bool IsQueensideCastlingAvailable()
		{
			if (this.Chessboard.IsAttackedByOpponent(this.Chessboard.FieldAt(this.startingRow, 2)) ||
			    this.Chessboard.IsAttackedByOpponent(this.Chessboard.FieldAt(this.startingRow, 3)))
			{
				return false;
			}

			if (this.Chessboard.PieceAt(this.startingRow, 0) is Rook)
			{
				Rook rook = (Rook) this.Chessboard.PieceAt(this.startingRow, 0);
				if ((rook.Suit != this.Suit) || rook.HasMoved)
				{
					return false;
				}
			}

			return true;
		}

		private IEnumerable<Move> KingsideCastlingMoveSequence(Move move)
		{
			Rook rook = (Rook) this.Chessboard.PieceAt(this.startingRow, 7);
			ChessField rookTo = this.Chessboard.FieldAt(this.startingRow, 5);
			Move rookMove = new Move(rook, rook.ChessField, rookTo);
			return new[] {move, rookMove};
		}

		private IEnumerable<Move> QueensideCastlingMoveSequence(Move move)
		{
			Rook rook = (Rook) this.Chessboard.PieceAt(this.startingRow, 0);
			ChessField rookTo = this.Chessboard.FieldAt(this.startingRow, 3);
			Move rookMove = new Move(rook, rook.ChessField, rookTo);
			return new[] {move, rookMove};
		}
	}
}
