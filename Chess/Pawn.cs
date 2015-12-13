using System;
using System.Collections.Generic;

namespace MM.Chess
{
	public class Pawn : ChessPiece
	{
		private readonly int StartRow;
		private readonly int MoveDirection;

		public Pawn(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
            this.StartRow = suit == ChessPieceSuit.WHITE ? 1 : 6;
			this.MoveDirection = suit == ChessPieceSuit.WHITE ? 1 : -1;
		}

		public override IEnumerable<ChessField> GetReachableFields()
		{
			List<ChessField> reachableFields = new List<ChessField>();
			if (this.Row == 0 || this.Row == Chessboard.Dimension - 1)
			{
				return reachableFields;
			}

			ChessField oneUp = this.chessboard.ChessFieldAt(this.Row + this.MoveDirection, this.Column);
            if (oneUp.ChessPiece == null)
			{
				reachableFields.Add(oneUp);
				ChessField twoUp = this.chessboard.ChessFieldAt(this.Row + (2 * this.MoveDirection), this.Column);
                if (this.Row == this.StartRow && twoUp.ChessPiece == null)
				{
					reachableFields.Add(twoUp);
				}
			}

			ChessField upLeft = this.Column > 0 ? this.chessboard.ChessFieldAt(this.Row + this.MoveDirection, this.Column - 1) : null;
            if (upLeft.ChessPiece != null && upLeft.ChessPiece.Suit != this.Suit)
			{
				reachableFields.Add(upLeft);
			}

			ChessField upRight = this.Column < Chessboard.Dimension - 1? this.chessboard.ChessFieldAt(this.Row + this.MoveDirection, this.Column + 1) : null;
			if (upRight.ChessPiece != null && upRight.ChessPiece.Suit != this.Suit)
			{
				reachableFields.Add(upRight);
			}

			return reachableFields;
		}

		public override ChessPiece SpecialMoveTo(ChessField field)
		{
			throw new NotImplementedException();
		}
	}
}
