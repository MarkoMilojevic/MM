using System;
using System.Collections.Generic;
using System.Linq;

namespace MM.Chess
{
	public class Chessboard
	{
		public const int Size = 8;
		public Player CurrentPlayer { get; private set; }
		private readonly ChessField[][] fields;
		public readonly Stack<Move> PlayedMoves;
		private Queue<Player> playersQueue;
		private ChessPiece selectedPiece;

		public Chessboard(ChessField[][] fields)
		{
			if (!Chessboard.AreFieldsValid(fields))
			{
				throw new ArgumentException("");
			}

			this.fields = fields;
			this.PlayedMoves = new Stack<Move>();
			this.CreateChessPieces();
			this.CreatePlayers();
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

		private void CreatePlayers()
		{
			Player white = new Player(ChessPieceSuit.White, (King) this.fields[0][4].ChessPiece, 0);
			Player black = new Player(ChessPieceSuit.Black, (King) this.fields[7][4].ChessPiece, 0);
			this.CurrentPlayer = white;
			this.playersQueue = new Queue<Player>();
			this.playersQueue.Enqueue(black);
		}

		public static void ExecuteMoveUnconditionally(Move move)
		{
			move.From.ChessPiece = null;
			move.To.ChessPiece = move.Piece;
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
			return (piece != null) && (piece.Suit == this.CurrentPlayer.Suit);
		}

		public void SelectChessPiece(ChessPiece piece)
		{
			if ((piece == null) || (piece.Suit != this.CurrentPlayer.Suit))
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
			Move move = new Move(piece, from, to);
			return this.ExecuteMove(move);
		}

		private bool ExecuteMove(Move move)
		{
			if (move == null)
			{
				return false;
			}

			if (this.IsLeavingKingInCheck(move) || (!move.Piece.IsFieldReachable(move.To) && !move.Piece.IsSpecialMoveAvailable(move)))
			{
				return false;
			}

			if (move.Piece.IsFieldReachable(move.To))
			{
				Chessboard.ExecuteMoveUnconditionally(move);
			}
			else
			{
				IEnumerable<Move> specialMoveSequence = move.Piece.GetSpecialMoveSequence(move);
				foreach (Move specialMove in specialMoveSequence)
				{
					Chessboard.ExecuteMoveUnconditionally(specialMove);
				}
			}

			this.PlayedMoves.Push(move);
			this.playersQueue.Enqueue(this.CurrentPlayer);
			this.CurrentPlayer = this.playersQueue.Dequeue();
			this.selectedPiece = null;
			return true;
		}

		private bool IsLeavingKingInCheck(Move move)
		{
			ChessPiece playersPiece = move.Piece;
			ChessField from = move.From;
			ChessField to = move.To;
			ChessPiece opponentsPiece = to.ChessPiece;
			from.ChessPiece = null;
			playersPiece.ChessField = null; // stop chesspiece 'on chesspiece property change' event to fire
			to.ChessPiece = playersPiece;
			bool isInCheck = this.IsAttackedByOpponent(this.CurrentPlayer.King);
			playersPiece.ChessField = null; // stop chesspiece 'on chesspiece property change' event to fire
			from.ChessPiece = playersPiece;
			to.ChessPiece = opponentsPiece;
			return isInCheck;
		}

		public bool IsAttackedByOpponent(ChessField chessField)
		{
			for (int i = 0; i < Chessboard.Size; i++)
			{
				for (int j = 0; j < Chessboard.Size; j++)
				{
					ChessPiece piece = this.PieceAt(i, j);
					if ((piece != null) && (piece.Suit != this.CurrentPlayer.Suit) && piece.IsFieldReachable(chessField))
					{
						return true;
					}
				}
			}

			return false;
		}

		public bool IsAttackedByOpponent(ChessPiece piece)
		{
			return this.IsAttackedByOpponent(piece.ChessField);
		}
	}
}
