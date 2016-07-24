using System;
using System.Collections.Generic;
using System.Linq;

namespace MM.Chess
{
	public class Chessboard
	{
		public const int Size = 8;
		public const int DefaultTimeToPlayInSeconds = 300;
		public Player CurrentPlayer { get; private set; }

		public ChessPiece SelectedPiece { get; private set; }

		public GameStatus GameStatus
		{
			get
			{
				IEnumerable<ChessPiece> currentPlayerPieces =
					this.fields.SelectMany(arr => arr.Select(field => field.ChessPiece)).Where(piece => (piece != null) && (piece.Suit == this.CurrentPlayer.Suit));
				IEnumerable<ChessPiece> pieces = currentPlayerPieces as ChessPiece[] ?? currentPlayerPieces.ToArray();
				foreach (ChessPiece piece in pieces)
				{
					foreach (ChessField reachableField in piece.ReachableFields)
					{
						Move move = new Move(piece, piece.ChessField, reachableField);
						if (!this.IsLeavingKingInCheck(move))
						{
							return GameStatus.InProgress;
						}
					}
				}

				if (this.IsAttackedByOpponent(this.CurrentPlayer.King))
				{
					return this.CurrentPlayer.Suit == ChessPieceSuit.White ? GameStatus.BlackWins : GameStatus.WhiteWins;
				}

				return pieces.Any(this.CanSacrifice) ? GameStatus.InProgress : GameStatus.Draw;
			}
		}

		private readonly ChessField[][] fields;
		public readonly Stack<Move> PlayedMoves;
		private Queue<Player> playersQueue;

		public Chessboard(ChessField[][] fields, int timeToPlayInSeconds)
		{
			if (!Chessboard.AreFieldsValid(fields))
			{
				throw new ArgumentException("");
			}

			this.fields = fields;
			this.PlayedMoves = new Stack<Move>();
			this.CreateChessPieces();
			this.CreatePlayers(timeToPlayInSeconds);
		}

		private static bool AreFieldsValid(ChessField[][] fields) => (fields != null) && fields.All(row => (row != null) && row.All(field => field != null));

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

		private void CreatePlayers(int timeToPlay)
		{
			Player white = new Player(ChessPieceSuit.White, (King) this.fields[0][4].ChessPiece, timeToPlay);
			Player black = new Player(ChessPieceSuit.Black, (King) this.fields[7][4].ChessPiece, timeToPlay);
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
			return this.SelectedPiece != null;
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

			this.SelectedPiece?.ChessField.ClearHighlight();
			this.SelectedPiece = piece;
			this.SelectedPiece.ChessField.SetHighlight();
		}

		public bool MoveTo(ChessField to)
		{
			if ((this.SelectedPiece == null) || (to == null))
			{
				return false;
			}

			ChessPiece piece = this.SelectedPiece;
			ChessField from = this.SelectedPiece.ChessField;
			Move move = new Move(piece, from, to);
			return this.ExecuteMove(move);
		}

		public void TakeBackMove()
		{
			if (this.PlayedMoves.Count == 0)
			{
				return;
			}

			Move lastMove = this.PlayedMoves.Pop();
			lastMove.From.ChessPiece = lastMove.Piece;
			lastMove.To.ChessPiece = lastMove.OpponentsPiece;
			this.CurrentPlayer = this.NextPlayer();
			this.SelectedPiece?.ChessField.ClearHighlight();
			this.SelectedPiece = null;
		}

		public bool CanSacrifice()
		{
			return this.CanSacrifice(this.SelectedPiece);
		}

		private bool CanSacrifice(ChessPiece piece)
		{
			if ((piece == null) || piece is King)
			{
				return false;
			}

			Move sacrificeMove = new Move(null, piece.ChessField, piece.ChessField);
			bool canSacrifice = !this.IsLeavingKingInCheck(sacrificeMove);
			this.SelectedPiece?.ChessField.SetHighlight();
			return canSacrifice;
		}

		public void Sacrifice()
		{
			if (!this.CanSacrifice())
			{
				return;
			}

			Move sacrificeMove = new Move(null, this.SelectedPiece.ChessField, this.SelectedPiece.ChessField);
			Chessboard.ExecuteMoveUnconditionally(sacrificeMove);
			this.LogMoveAndSwitchPlayer(sacrificeMove);
		}

		private bool ExecuteMove(Move move)
		{
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

			this.CheckPawnPromotion(move);
			this.LogMoveAndSwitchPlayer(move);
			return true;
		}

		private void CheckPawnPromotion(Move move)
		{
			if (!(move.Piece is Pawn))
			{
				return;
			}

			Pawn pawn = (Pawn) move.Piece;
			int promotionRow = pawn.Suit == ChessPieceSuit.White ? 7 : 0;
			if (move.To.Row == promotionRow)
			{
				switch (pawn.Suit)
				{
					case ChessPieceSuit.White:
						WhitePawnPromotionForm whitePromotionForm = new WhitePawnPromotionForm();
						whitePromotionForm.ShowDialog();
						switch (whitePromotionForm.Selection)
						{
							case Promotion.Knight:
								move.To.ChessPiece = new Knight(this, ChessPieceSuit.White);
								break;
							case Promotion.Bishop:
								move.To.ChessPiece = new Bishop(this, ChessPieceSuit.White);
								break;
							case Promotion.Rook:
								move.To.ChessPiece = new Rook(this, ChessPieceSuit.White);
								break;
							case Promotion.Queen:
								move.To.ChessPiece = new Queen(this, ChessPieceSuit.White);
								break;
							default:
								throw new ArgumentOutOfRangeException();
						}

						break;
					case ChessPieceSuit.Black:
						BlackPawnPromotionForm blackPromotionForm = new BlackPawnPromotionForm();
						blackPromotionForm.ShowDialog();
						switch (blackPromotionForm.Selection)
						{
							case Promotion.Knight:
								move.To.ChessPiece = new Knight(this, ChessPieceSuit.Black);
								break;
							case Promotion.Bishop:
								move.To.ChessPiece = new Bishop(this, ChessPieceSuit.Black);
								break;
							case Promotion.Rook:
								move.To.ChessPiece = new Rook(this, ChessPieceSuit.Black);
								break;
							case Promotion.Queen:
								move.To.ChessPiece = new Queen(this, ChessPieceSuit.Black);
								break;
							default:
								throw new ArgumentOutOfRangeException();
						}

						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
		}

		private void LogMoveAndSwitchPlayer(Move sacrificeMove)
		{
			this.PlayedMoves.Push(sacrificeMove);
			this.CurrentPlayer = this.NextPlayer();
			this.SelectedPiece = null;
		}

		private Player NextPlayer()
		{
			this.playersQueue.Enqueue(this.CurrentPlayer);
			return this.playersQueue.Dequeue();
		}

		private bool IsLeavingKingInCheck(Move move)
		{
			ChessPiece opponentsPiece = move.To.ChessPiece;
			move.From.ChessPiece = null;
			if (move.Piece != null)
			{
				move.Piece.ChessField = null; // stop chesspiece 'chessfield property on change' event to fire
			}

			move.To.ChessPiece = move.Piece;
			bool isInCheck = this.IsAttackedByOpponent(this.CurrentPlayer.King);
			if (move.Piece != null)
			{
				move.Piece.ChessField = null; // stop chesspiece 'chessfield property on change' event to fire
			}

			move.From.ChessPiece = move.Piece;
			this.SelectedPiece?.ChessField.SetHighlight();
			move.To.ChessPiece = opponentsPiece;
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

		public void HighlightAvailableMoves()
		{
			if (this.SelectedPiece == null)
			{
				return;
			}

			foreach (ChessField field in this.SelectedPiece.ReachableFields)
			{
				field.SetHighlight();
			}
		}

		public void ClearAllHighlights()
		{
			for (int i = 0; i < Chessboard.Size; i++)
			{
				for (int j = 0; j < Chessboard.Size; j++)
				{
					this.FieldAt(i, j).ClearHighlight();
				}
			}
		}
	}
}
