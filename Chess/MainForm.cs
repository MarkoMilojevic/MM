using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MM.Chess
{
	public partial class MainForm : Form
	{
		private Chessboard chessboard;

		public MainForm()
		{
			InitializeComponent();
			InitializeChessboardPanel();
		}

		private void InitializeChessboardPanel()
		{
			int chessFieldWidth = chessboardPanel.Width / Chessboard.Dimension;
			int chessFieldHeight = chessboardPanel.Height / Chessboard.Dimension;
			ChessField[][] chessFields = new ChessField[Chessboard.Dimension][];
			for (int i = 0; i < Chessboard.Dimension; i++)
			{
				chessFields[i] = new ChessField[Chessboard.Dimension];
				for (int j = 0; j < Chessboard.Dimension; j++)
				{
					ChessField chessField = new ChessField(i, j);
					chessField.Location = new Point(j * chessFieldWidth, chessboardPanel.Height - (i * chessFieldHeight) - chessFieldHeight);
					chessField.Size = new Size(chessFieldWidth, chessFieldHeight);
					chessField.BackColor = (i % 2 != j % 2) ? Color.White : Color.Gray;
					chessField.Visible = true;
					chessField.Click += ChessField_Click;
					chessboardPanel.Controls.Add(chessField);
					chessFields[i][j] = chessField;
				}
			}

			chessboard = new Chessboard(chessFields);
		}

		void ChessField_Click(object sender, EventArgs e)
		{
			ChessField chessField = sender as ChessField;
			if (chessField == null)
			{
				return;
			}
		}
	}
}
