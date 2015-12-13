using System;

namespace MM.Chess
{
	public class Chessboard
	{
		public const int Dimension = 8;
		private ChessField[][] fields;

		public Chessboard(ChessField[][] fields)
		{
			if (!this.AreFieldsValid(fields))
			{
				throw new ArgumentException("");
			}

			this.fields = fields;
			ClearFields();
			InitializeFields();
		}

		private bool AreFieldsValid(ChessField[][] fields)
		{
			if (fields == null || fields.Length != Chessboard.Dimension)
			{
				return false;
			}

			for (int i = 0; i < Chessboard.Dimension; i++)
			{
				if (fields[i] == null || fields[i].Length != Chessboard.Dimension)
				{
					return false;
				}

				for (int j = 0; j < Chessboard.Dimension; j++)
				{
					if (fields[i][j] == null)
					{
						return false;
					}
				}
			}

			return true;
		}

		private void ClearFields()
		{
			for (int i = 0; i < Chessboard.Dimension; i++)
			{
				for (int j = 0; j < Chessboard.Dimension; j++)
				{
					this.fields[i][j].ChessPiece = null;
				}
			}
		}

		private void InitializeFields()
		{
			for (int i = 0; i < Chessboard.Dimension; i++)
			{
				this.fields[1][i].ChessPiece = new Pawn(this, ChessPieceSuit.WHITE);
				this.fields[6][i].ChessPiece = new Pawn(this, ChessPieceSuit.BLACK);
			}

			this.fields[0][0].ChessPiece = new Rook(this, ChessPieceSuit.WHITE);
			this.fields[0][7].ChessPiece = new Rook(this, ChessPieceSuit.WHITE);
			this.fields[0][1].ChessPiece = new Knight(this, ChessPieceSuit.WHITE);
			this.fields[0][6].ChessPiece = new Knight(this, ChessPieceSuit.WHITE);
			this.fields[0][2].ChessPiece = new Bishop(this, ChessPieceSuit.WHITE);
			this.fields[0][5].ChessPiece = new Bishop(this, ChessPieceSuit.WHITE);
			this.fields[0][3].ChessPiece = new Queen(this, ChessPieceSuit.WHITE);
			this.fields[0][4].ChessPiece = new King(this, ChessPieceSuit.WHITE);

			this.fields[7][0].ChessPiece = new Rook(this, ChessPieceSuit.BLACK);
			this.fields[7][7].ChessPiece = new Rook(this, ChessPieceSuit.BLACK);
			this.fields[7][1].ChessPiece = new Knight(this, ChessPieceSuit.BLACK);
			this.fields[7][6].ChessPiece = new Knight(this, ChessPieceSuit.BLACK);
			this.fields[7][2].ChessPiece = new Bishop(this, ChessPieceSuit.BLACK);
			this.fields[7][5].ChessPiece = new Bishop(this, ChessPieceSuit.BLACK);
			this.fields[7][3].ChessPiece = new Queen(this, ChessPieceSuit.BLACK);
			this.fields[7][4].ChessPiece = new King(this, ChessPieceSuit.BLACK);
		}
	}
}
