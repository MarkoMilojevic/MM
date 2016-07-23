using System;
using System.Drawing;
using System.Windows.Forms;
using MM.Chess.Properties;

namespace MM.Chess
{
	public class ChessField : PictureBox
	{
		private Image ChessPieceImage => this.ChessPiece.Image;

		private Image HighlightedChessPieceImage => this.ChessPiece.HighlightedImage;

		public ChessPiece ChessPiece
		{
			get { return this.chessPiece; }
			set
			{
				this.chessPiece = value;
				if (value != null)
				{
					this.chessPiece.ChessField = this;
				}

				this.Image = value != null ? this.ChessPieceImage : null;
			}
		}

		public readonly int Column;

		public readonly int Row;

		private ChessPiece chessPiece;

		public ChessField(int row, int column, ChessPiece chessPiece = null)
		{
			if ((row < 0) || (row >= Chessboard.Size) || (column < 0) || (column >= Chessboard.Size))
			{
				throw new ArgumentException("");
			}

			this.Row = row;
			this.Column = column;
			this.ChessPiece = chessPiece;
		}

		public void SetHighlight()
		{
			this.Image = this.ChessPiece != null ? this.HighlightedChessPieceImage : Resources.HighlightedField;
		}

		public void ClearHighlight()
		{
			this.Image = this.ChessPiece != null ? this.ChessPieceImage : null;
		}

		public bool IsHighlighted()
		{
			return this.ChessPiece != null ? this.Image == this.HighlightedChessPieceImage : this.Image == Resources.HighlightedField;
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
