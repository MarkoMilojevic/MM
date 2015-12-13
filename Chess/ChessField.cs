using System;
using System.Drawing;
using System.Windows.Forms;

namespace MM.Chess
{
	public class ChessField : PictureBox
	{
		private static readonly Image EmptyField = null;
		private static readonly Image HighlightedField = Image.FromFile("../../Images/highlighted-field.png");

		private static readonly Image WhitePawn = Image.FromFile("../../Images/white-pawn.png");
		private static readonly Image WhiteRook = Image.FromFile("../../Images/white-rook.png");
		private static readonly Image WhiteKnight = Image.FromFile("../../Images/white-knight.png");
		private static readonly Image WhiteBishop = Image.FromFile("../../Images/white-bishop.png");
		private static readonly Image WhiteQueen = Image.FromFile("../../Images/white-queen.png");
		private static readonly Image WhiteKing = Image.FromFile("../../Images/white-king.png");

		private static readonly Image WhitePawnSelected = Image.FromFile("../../Images/white-pawn-selected.png");
		private static readonly Image WhiteRookSelected = Image.FromFile("../../Images/white-rook-selected.png");
		private static readonly Image WhiteKnightSelected = Image.FromFile("../../Images/white-knight-selected.png");
		private static readonly Image WhiteBishopSelected = Image.FromFile("../../Images/white-bishop-selected.png");
		private static readonly Image WhiteQueenSelected = Image.FromFile("../../Images/white-queen-selected.png");
		private static readonly Image WhiteKingSelected = Image.FromFile("../../Images/white-king-selected.png");

		private static readonly Image BlackPawn = Image.FromFile("../../Images/black-pawn.png");
		private static readonly Image BlackRook = Image.FromFile("../../Images/black-rook.png");
		private static readonly Image BlackKnight = Image.FromFile("../../Images/black-knight.png");
		private static readonly Image BlackBishop = Image.FromFile("../../Images/black-bishop.png");
		private static readonly Image BlackQueen = Image.FromFile("../../Images/black-queen.png");
		private static readonly Image BlackKing = Image.FromFile("../../Images/black-king.png");

		private static readonly Image BlackPawnSelected = Image.FromFile("../../Images/black-pawn-selected.png");
		private static readonly Image BlackRookSelected = Image.FromFile("../../Images/black-rook-selected.png");
		private static readonly Image BlackKnightSelected = Image.FromFile("../../Images/black-knight-selected.png");
		private static readonly Image BlackBishopSelected = Image.FromFile("../../Images/black-bishop-selected.png");
		private static readonly Image BlackQueenSelected = Image.FromFile("../../Images/black-queen-selected.png");
		private static readonly Image BlackKingSelected = Image.FromFile("../../Images/black-king-selected.png");

		private Image ChessPieceImage
		{
			get
			{
				switch (this.ChessPiece.Type)
				{
					case ChessPieceType.PAWN:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhitePawn : ChessField.BlackPawn;
					case ChessPieceType.ROOK:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteRook : ChessField.BlackRook;
					case ChessPieceType.KNIGHT:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteKnight : ChessField.BlackKnight;
					case ChessPieceType.BISHOP:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteBishop : ChessField.BlackBishop;
					case ChessPieceType.QUEEN:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteQueen : ChessField.BlackQueen;
					case ChessPieceType.KING:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteKing : ChessField.BlackKing;
					default:
						return ChessField.EmptyField;
				}
			}
		}

		private Image SelectedChessPieceImage
		{
			get
			{
				switch (this.ChessPiece.Type)
				{
					case ChessPieceType.PAWN:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhitePawnSelected : ChessField.BlackPawnSelected;
					case ChessPieceType.ROOK:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteRookSelected : ChessField.BlackRookSelected;
					case ChessPieceType.KNIGHT:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteKnightSelected : ChessField.BlackKnightSelected;
					case ChessPieceType.BISHOP:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteBishopSelected : ChessField.BlackBishopSelected;
					case ChessPieceType.QUEEN:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteQueenSelected : ChessField.BlackQueenSelected;
					case ChessPieceType.KING:
						return this.ChessPiece.Suit == ChessPieceSuit.WHITE ? ChessField.WhiteKingSelected : ChessField.BlackKingSelected;
					default:
						return ChessField.EmptyField;
				}
			}
		}

		private int row;
		public int Row
		{
			get
			{
				return this.row;
			}
			protected set
			{
				if (value < 0 || value >= Chessboard.Dimension)
				{
					throw new ArgumentException("");
				}

				this.row = value;
			}
		}

		private int column;
		public int Column
		{
			get
			{
				return this.column;
			}
			protected set
			{
				if (value < 0 || value >= Chessboard.Dimension)
				{
					throw new ArgumentException("");
				}

				this.column = value;
			}
		}

		private ChessPiece chessPiece;
		public ChessPiece ChessPiece
		{
			get
			{
				return this.chessPiece;
			}
			set
			{
				this.chessPiece = value;
				if (value != null)
				{
					this.chessPiece.ChessField = this;
				}

				this.Image = value != null ? this.ChessPieceImage : ChessField.EmptyField;
			}
		}
		
		public ChessField(int row, int column, ChessPiece chessPiece = null)
		{
			this.Row = row;
			this.Column = column;
			this.ChessPiece = chessPiece;
		}

		public void SetHighlight()
		{
			this.Image = this.ChessPiece != null ? this.SelectedChessPieceImage : ChessField.HighlightedField;
		}

		public void ClearHighlight()
		{
			this.Image = this.ChessPiece != null ? this.ChessPieceImage : ChessField.EmptyField;
		}

		public bool IsHighlighted()
		{
			return this.ChessPiece != null ? this.Image == this.SelectedChessPieceImage : this.Image == ChessField.HighlightedField;
		}

		public void ToggleHighlight()
		{
			if (!this.IsHighlighted())
			{
				this.SetHighlight();
			}
			else
			{
				this.ClearHighlight();
			}
		}
	}
}
