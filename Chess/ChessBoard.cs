using System;
using System.Linq;

namespace MM.Chess
{
	public class Chessboard
	{
		public const int Size = 8;

		public ChessPieceSuit TurnToPlay { get; private set; }
		private readonly ChessField[][] fields;
		private ChessPiece selectedPiece;

		public Chessboard(ChessField[][] fields)
		{
			if (!Chessboard.AreFieldsValid(fields))
			{
				throw new ArgumentException("");
			}

			this.fields = fields;
			this.CreateChessPieces();
			this.TurnToPlay = ChessPieceSuit.White;
		}

		private static bool AreFieldsValid(ChessField[][] fields) => (fields != null) && fields.All(arr => (arr != null) && arr.All(field => field != null));

		private void CreateChessPieces()
		{
			for (int i = 0; i < Chessboard.Size; i++)
			{
				for (int j = 0; j < Chessboard.Size; j++)
				{
					this.fields[i][j].ChessPiece = null;
				}
			}

			for (int i = 0; i < Chessboard.Size; i++)
			{
				this.fields[1][i].ChessPiece = new Pawn(this, ChessPieceSuit.White);
				this.fields[6][i].ChessPiece = new Pawn(this, ChessPieceSuit.Black);
			}

			this.fields[0][0].ChessPiece = new Rook(this, ChessPieceSuit.White);
			this.fields[0][7].ChessPiece = new Rook(this, ChessPieceSuit.White);
			this.fields[0][1].ChessPiece = new Knight(this, ChessPieceSuit.White);
			this.fields[0][6].ChessPiece = new Knight(this, ChessPieceSuit.White);
			this.fields[0][2].ChessPiece = new Bishop(this, ChessPieceSuit.White);
			this.fields[0][5].ChessPiece = new Bishop(this, ChessPieceSuit.White);
			this.fields[0][3].ChessPiece = new Queen(this, ChessPieceSuit.White);
			this.fields[0][4].ChessPiece = new King(this, ChessPieceSuit.White);

			this.fields[7][0].ChessPiece = new Rook(this, ChessPieceSuit.Black);
			this.fields[7][7].ChessPiece = new Rook(this, ChessPieceSuit.Black);
			this.fields[7][1].ChessPiece = new Knight(this, ChessPieceSuit.Black);
			this.fields[7][6].ChessPiece = new Knight(this, ChessPieceSuit.Black);
			this.fields[7][2].ChessPiece = new Bishop(this, ChessPieceSuit.Black);
			this.fields[7][5].ChessPiece = new Bishop(this, ChessPieceSuit.Black);
			this.fields[7][3].ChessPiece = new Queen(this, ChessPieceSuit.Black);
			this.fields[7][4].ChessPiece = new King(this, ChessPieceSuit.Black);
		}

		public ChessField FieldAt(int row, int column)
		{
			if ((row < 0) || (row >= Chessboard.Size) || (column < 0) || (column >= Chessboard.Size))
			{
				throw new IndexOutOfRangeException("");
			}

			return this.fields[row][column];
		}

		public ChessPiece PieceAt(int row, int column)
		{
			return this.FieldAt(row, column).ChessPiece;
		}

		public bool IsChessPieceSelected()
		{
			return this.selectedPiece != null;
		}

		public bool IsChessPieceSelectable(ChessPiece piece)
		{
			return (piece != null) && (piece.Suit == this.TurnToPlay);
		}

		public void SelectChessPiece(ChessPiece piece)
		{
			if ((piece == null) || (piece.Suit != this.TurnToPlay))
			{
				throw new ArgumentException("");
			}

			this.selectedPiece?.ChessField.ClearHighlight();
			this.selectedPiece = piece;
			this.selectedPiece.ChessField.SetHighlight();
		}

		public bool MoveTo(ChessField to)
		{
			if ((this.selectedPiece == null) || (to == null))
			{
				return false;
			}

			ChessPiece piece = this.selectedPiece;
			ChessField from = this.selectedPiece.ChessField;
			MoveCommand move = new MoveCommand(piece, from, to);
			return this.ExecuteMove(move);
		}

		public bool ExecuteMove(MoveCommand move)
		{
			if (move == null)
			{
				return false;
			}

			ChessPiece piece = move.Piece;
			ChessField toField = move.To;
			if (!piece.IsFieldReachable(toField))
			{
				return false;
			}

			King king = this.GetPlayersKing();
			if (this.IsUnveilingCheck(king, move))
			{
				return false;
			}

			piece.ChessField.ClearHighlight();
			piece.MoveTo(toField);
			this.TurnToPlay = this.TurnToPlay == ChessPieceSuit.White ? ChessPieceSuit.Black : ChessPieceSuit.White;
			this.selectedPiece = null;
			return true;
		}

		private King GetPlayersKing()
		{
			for (int i = 0; i < Chessboard.Size; i++)
			{
				for (int j = 0; j < Chessboard.Size; j++)
				{
					King king = this.PieceAt(i, j) as King;
					if ((king != null) && (king.Suit == this.TurnToPlay))
					{
						return king;
					}
				}
			}

			return null;
		}

		private bool IsUnveilingCheck(King king, MoveCommand move)
		{
			ChessPiece playersPiece = move.Piece;
			ChessField from = move.From;
			ChessField to = move.To;
			ChessPiece opponentsPiece = to.ChessPiece;
			from.ChessPiece = null;
			to.ChessPiece = playersPiece;
			bool isInCheck = this.IsInCheck(king);
			from.ChessPiece = playersPiece;
			to.ChessPiece = opponentsPiece;
			return isInCheck;
		}

		private bool IsInCheck(King king)
		{
			for (int i = 0; i < Chessboard.Size; i++)
			{
				for (int j = 0; j < Chessboard.Size; j++)
				{
					ChessPiece piece = this.PieceAt(i, j);
					if ((piece != null) && (piece.Suit != this.TurnToPlay) && piece.IsFieldReachable(king.ChessField))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
