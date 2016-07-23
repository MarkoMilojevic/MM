using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using MM.Chess.Annotations;

namespace MM.Chess
{
	public abstract class ChessPiece : INotifyPropertyChanged
	{
		public ChessField ChessField
		{
			get { return this.chessField; }
			internal set
			{
				ChessField oldValue = this.chessField;
				this.chessField = value;
				if ((oldValue != null) && (value != null))
				{
					this.OnPropertyChanged(nameof(this.ChessField));
				}
			}
		}

		public int Row => this.ChessField.Row;

		public int Column => this.ChessField.Column;

		public abstract Image Image { get; }
		public abstract Image HighlightedImage { get; }

		public abstract IEnumerable<ChessField> ReachableFields { get; }
		protected readonly Chessboard Chessboard;
		public readonly ChessPieceSuit Suit;
		private ChessField chessField;

		protected ChessPiece(Chessboard chessboard, ChessPieceSuit suit)
		{
			if (chessboard == null)
			{
				throw new ArgumentException("");
			}

			this.Chessboard = chessboard;
			this.Suit = suit;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public bool IsFieldReachable(ChessField field)
		{
			if (field == null)
			{
				throw new ArgumentException("");
			}

			return this.ReachableFields.Contains(field);
		}

		public abstract bool IsSpecialMoveAvailable(Move move);

		public abstract IEnumerable<Move> GetSpecialMoveSequence(Move move);

		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
