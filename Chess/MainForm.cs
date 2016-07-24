using System;
using System.Drawing;
using System.Windows.Forms;
using MM.Chess.Properties;

namespace MM.Chess
{
	public partial class MainForm : Form
	{
		private bool IsTimerEnabled => this.timeControlInSeconds > 0;
		private readonly int chessFieldHeight;
		private readonly int chessFieldWidth;
		private Chessboard chessboard;
		private bool shouldHighlightAvailableMoves;
		private int timeControlInSeconds;

		public MainForm()
		{
			this.InitializeComponent();
			this.chessFieldWidth = this.chessboardPanel.Width / Chessboard.Size;
			this.chessFieldHeight = this.chessboardPanel.Height / Chessboard.Size;
			this.timeControlInSeconds = Chessboard.DefaultTimeToPlayInSeconds;
			this.chessboard = this.CreateChessboard();
			this.InitializeFormControls();
		}

		private Chessboard CreateChessboard()
		{
			ChessField[][] fields = this.CreateChessFields();
			return new Chessboard(fields, this.timeControlInSeconds);
		}

		private ChessField[][] CreateChessFields()
		{
			ChessField[][] fields = new ChessField[Chessboard.Size][];
			for (int i = 0; i < Chessboard.Size; i++)
			{
				fields[i] = new ChessField[Chessboard.Size];
				for (int j = 0; j < Chessboard.Size; j++)
				{
					ChessField field = this.CreateChessField(i, j);
					this.chessboardPanel.Controls.Add(field);
					fields[i][j] = field;
				}
			}

			return fields;
		}

		private ChessField CreateChessField(int row, int column)
		{
			ChessField field = new ChessField(row, column)
			{
				Location = new Point(column * this.chessFieldWidth, this.chessboardPanel.Height - row * this.chessFieldHeight - this.chessFieldHeight),
				Size = new Size(this.chessFieldWidth, this.chessFieldHeight),
				BackColor = row % 2 != column % 2 ? Color.White : Color.Gray,
				Visible = true
			};

			field.Click += this.OnClickChessField;
			return field;
		}

		private void InitializeFormControls()
		{
			this.chessboardPanel.Enabled = true;
			this.drawButton.Enabled = true;
			this.resignButton.Enabled = true;
			this.takeBackButton.Enabled = true;
			this.sacrificeButton.Enabled = false;
			this.statusLabel.Text = Resources.StatusWhiteToPlay;
			this.SetTimerLabelValues(ChessPieceSuit.White, this.timeControlInSeconds);
			this.SetTimerLabelValues(ChessPieceSuit.Black, this.timeControlInSeconds);
			this.Timer.Stop();
		}

		private void SetTimerLabelValues(ChessPieceSuit suit, int timeToPlay)
		{
			string minutesLeft = timeToPlay / 60 < 10 ? "0" + timeToPlay / 60 : Convert.ToString(timeToPlay / 60);
			string secondsLeft = timeToPlay % 60 < 10 ? "0" + timeToPlay % 60 : Convert.ToString(timeToPlay % 60);
			if (suit == ChessPieceSuit.White)
			{
				this.whiteMinutesLabel.Text = minutesLeft;
				this.whiteSecondsLabel.Text = secondsLeft;
			}
			else
			{
				this.blackMinutesLabel.Text = minutesLeft;
				this.blackSecondsLabel.Text = secondsLeft;
			}
		}

		private void OnClickChessField(object sender, EventArgs e)
		{
			ChessField field = sender as ChessField;
			if (field == null)
			{
				return;
			}

			if (this.chessboard.IsChessPieceSelectable(field.ChessPiece))
			{
				this.chessboard.SelectChessPiece(field.ChessPiece);
				this.sacrificeButton.Enabled = this.chessboard.CanSacrifice();
				if (this.shouldHighlightAvailableMoves)
				{
					this.chessboard.ClearAllHighlights();
					this.chessboard.HighlightAvailableMoves();
				}
			}
			else if (this.chessboard.IsChessPieceSelected())
			{
				bool isMoveExecuted = this.chessboard.MoveTo(field);
				if (!isMoveExecuted)
				{
					return;
				}

				this.chessboard.ClearAllHighlights();
				this.sacrificeButton.Enabled = false;
				if (!this.Timer.Enabled)
				{
					this.Timer.Start();
				}

				this.CheckGameStatus();
			}
		}

		private void CheckGameStatus()
		{
			GameStatus status = this.chessboard.GameStatus;
			switch (status)
			{
				case GameStatus.InProgress:
					this.statusLabel.Text = this.chessboard.CurrentPlayer.Suit == ChessPieceSuit.White ? Resources.StatusWhiteToPlay : Resources.StatusBlackToPlay;
					break;
				case GameStatus.Draw:
					this.statusLabel.Text = Resources.StatusDraw;
					break;
				case GameStatus.WhiteWins:
					this.statusLabel.Text = Resources.StatusWhiteWins;
					this.whiteScoreLabel.Text = Convert.ToString(Convert.ToInt32(this.whiteScoreLabel.Text) + 1);
					break;
				case GameStatus.BlackWins:
					this.statusLabel.Text = Resources.StatusBlackWins;
					this.blackScoreLabel.Text = Convert.ToString(Convert.ToInt32(this.blackScoreLabel.Text) + 1);
					break;
				default:
					throw new ArgumentOutOfRangeException("");
			}

			if (status != GameStatus.InProgress)
			{
				this.chessboardPanel.Enabled = false;
				this.drawButton.Enabled = false;
				this.resignButton.Enabled = false;
				this.takeBackButton.Enabled = false;
				this.sacrificeButton.Enabled = false;

				this.Timer.Stop();
				this.chessboard.ClearAllHighlights();
			}
		}

		private void OnClickNewGameButton(object sender, EventArgs e)
		{
			this.chessboardPanel.Controls.Clear();
			this.chessboard = this.CreateChessboard();
			this.InitializeFormControls();
		}

		private void OnClickDrawButton(object sender, EventArgs e)
		{
			this.newGameButton.PerformClick();
		}

		private void OnClickResignButton(object sender, EventArgs e)
		{
			if (this.chessboard.CurrentPlayer.Suit == ChessPieceSuit.White)
			{
				this.blackScoreLabel.Text = Convert.ToString(Convert.ToInt32(this.blackScoreLabel.Text) + 1);
			}
			else if (this.chessboard.CurrentPlayer.Suit == ChessPieceSuit.Black)
			{
				this.whiteScoreLabel.Text = Convert.ToString(Convert.ToInt32(this.whiteScoreLabel.Text) + 1);
			}

			this.newGameButton.PerformClick();
		}

		private void OnClickTakeBackButton(object sender, EventArgs e)
		{
			this.chessboard.TakeBackMove();
			this.statusLabel.Text = this.chessboard.CurrentPlayer.Suit == ChessPieceSuit.White ? Resources.StatusWhiteToPlay : Resources.StatusBlackToPlay;
		}

		private void OnClickSacrificeButton(object sender, EventArgs e)
		{
			this.chessboard.Sacrifice();
			this.sacrificeButton.Enabled = false;
			this.statusLabel.Text = this.chessboard.CurrentPlayer.Suit == ChessPieceSuit.White ? Resources.StatusWhiteToPlay : Resources.StatusBlackToPlay;
		}

		private void OnClickSetTimerMenuItem(object sender, EventArgs e)
		{
			TimerForm timerForm = new TimerForm();
			timerForm.ShowDialog();
			this.timeControlInSeconds = timerForm.Selection;
		}

		private void OnClickShowMovesMenuItem(object sender, EventArgs e)
		{
			this.shouldHighlightAvailableMoves = !this.shouldHighlightAvailableMoves;
			this.highlightAvailableMovesMenuItem.Text = this.shouldHighlightAvailableMoves ? "Hide available moves" : "Show available moves";
			if (this.shouldHighlightAvailableMoves)
			{
				this.chessboard.HighlightAvailableMoves();
			}
			else
			{
				this.chessboard.ClearAllHighlights();
				this.chessboard.SelectedPiece?.ChessField.SetHighlight();
			}
		}

		private void TimerTick(object sender, EventArgs e)
		{
			if (!this.IsTimerEnabled)
			{
				return;
			}

			Player currentPlayer = this.chessboard.CurrentPlayer;
			currentPlayer.TimeToPlayInSeconds -= 1;
			this.SetTimerLabelValues(currentPlayer.Suit, currentPlayer.TimeToPlayInSeconds);
			if (currentPlayer.TimeToPlayInSeconds > 0)
			{
				return;
			}

			this.Timer.Stop();
			this.chessboardPanel.Enabled = false;
			this.drawButton.Enabled = false;
			this.resignButton.Enabled = false;
			this.takeBackButton.Enabled = false;
			this.sacrificeButton.Enabled = false;
			this.chessboard.ClearAllHighlights();
			this.statusLabel.Text = $"Time is up. {currentPlayer.Suit.ToString().ToUpper()} wins.";
			switch (currentPlayer.Suit)
			{
				case ChessPieceSuit.White:
					this.whiteScoreLabel.Text = Convert.ToString(Convert.ToInt32(this.blackScoreLabel.Text) + 1);
					break;
				case ChessPieceSuit.Black:
					this.blackScoreLabel.Text = Convert.ToString(Convert.ToInt32(this.blackScoreLabel.Text) + 1);
					break;
				default:
					throw new ArgumentOutOfRangeException("");
			}
		}
	}
}
