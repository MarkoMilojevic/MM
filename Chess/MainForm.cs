using System;
using System.Drawing;
using System.Windows.Forms;

namespace MM.Chess
{
	public partial class MainForm : Form
	{
		private readonly Chessboard chessboard;
		private readonly int chessFieldHeight;
		private readonly int chessFieldWidth;

		public MainForm()
		{
			this.InitializeComponent();
			this.chessFieldWidth = this.chessboardPanel.Width / Chessboard.Size;
			this.chessFieldHeight = this.chessboardPanel.Height / Chessboard.Size;
			this.chessboard = this.CreateChessboard();
		}

		private Chessboard CreateChessboard()
		{
			ChessField[][] fields = this.CreateChessFields();
			return new Chessboard(fields);
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
			}
			else if (this.chessboard.IsChessPieceSelected())
			{
				this.chessboard.MoveTo(field);
			}
		}
	}
}
