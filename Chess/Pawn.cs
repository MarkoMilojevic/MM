using System;
using System.Collections.Generic;
using System.Drawing;
using MM.Chess.Properties;

namespace MM.Chess
{
	public class Pawn : ChessPiece
	{
		public override Image Image => this.Suit == ChessPieceSuit.White ? Resources.WhitePawn : Resources.BlackPawn;

		public override Image HighlightedImage => this.Suit == ChessPieceSuit.White ? Resources.WhitePawnHighlighted : Resources.BlackPawnHighlighted;

		public override IEnumerable<ChessField> ReachableFields
		{
			get
			{
				List<ChessField> reachableFields = new List<ChessField>();
				if ((this.Row == 0) || (this.Row == Chessboard.Size - 1))
				{
					return reachableFields;
				}

				ChessField oneUp = this.Chessboard.FieldAt(this.Row + this.moveDirection, this.Column);
				if (oneUp.ChessPiece == null)
				{
					reachableFields.Add(oneUp);
					if (this.Row == this.startRow)
					{
						ChessField twoUp = this.Chessboard.FieldAt(this.Row + 2 * this.moveDirection, this.Column);
						if (twoUp.ChessPiece == null)
						{
							reachableFields.Add(twoUp);
						}
					}
				}

				ChessField upLeft = this.Column > 0 ? this.Chessboard.FieldAt(this.Row + this.moveDirection, this.Column - 1) : null;
				if ((upLeft?.ChessPiece != null) && (upLeft.ChessPiece.Suit != this.Suit))
				{
					reachableFields.Add(upLeft);
				}

				ChessField upRight = this.Column < Chessboard.Size - 1 ? this.Chessboard.FieldAt(this.Row + this.moveDirection, this.Column + 1) : null;
				if ((upRight?.ChessPiece != null) && (upRight.ChessPiece.Suit != this.Suit))
				{
					reachableFields.Add(upRight);
				}

				return reachableFields;
			}
		}

		private readonly int enPassantRow;

		private readonly int moveDirection;
		private readonly int startRow;

		public Pawn(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
			this.moveDirection = suit == ChessPieceSuit.White ? 1 : -1;
			this.startRow = suit == ChessPieceSuit.White ? 1 : 6;
			this.enPassantRow = suit == ChessPieceSuit.White ? 4 : 3;
		}

		public override bool IsSpecialMoveAvailable(Move move)
		{
			return this.IsEnPassantAvailable(move);
		}

		public override IEnumerable<Move> GetSpecialMoveSequence(Move move)
		{
			if (this.IsEnPassantAvailable(move))
			{
				return this.EnPassantMoveSequence(move);
			}

			throw new InvalidOperationException("");
		}

		private bool IsEnPassantAvailable(Move move)
		{
			if (this.Row != this.enPassantRow)
			{
				return false;
			}

			Move previousMove = this.Chessboard.PlayedMoves.Peek();
			return previousMove.Piece is Pawn && (previousMove.To.Row == this.enPassantRow) && (Math.Abs(this.Column - previousMove.To.Column) == 1) &&
			       (move.To.Column == previousMove.To.Column) && (move.To.Row == previousMove.To.Row + this.moveDirection) &&
			       (previousMove.From.Row == ((Pawn) previousMove.Piece).startRow);
		}

		private IEnumerable<Move> EnPassantMoveSequence(Move move)
		{
			Move previousMove = this.Chessboard.PlayedMoves.Peek();
			Move move1 = new Move(move.Piece, move.From, previousMove.To);
			Move move2 = new Move(move.Piece, previousMove.To, move.To);
			return new[] {move1, move2};
		}
	}
}
