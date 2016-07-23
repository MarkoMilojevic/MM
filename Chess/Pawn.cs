﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
					ChessField twoUp = this.Chessboard.FieldAt(this.Row + 2 * this.moveDirection, this.Column);
					if ((this.Row == this.startRow) && (twoUp.ChessPiece == null))
					{
						reachableFields.Add(twoUp);
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

		private readonly int moveDirection;
		private readonly int startRow;

		public Pawn(Chessboard chessboard, ChessPieceSuit suit) : base(chessboard, suit)
		{
			this.startRow = suit == ChessPieceSuit.White ? 1 : 6;
			this.moveDirection = suit == ChessPieceSuit.White ? 1 : -1;
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
	}
}
