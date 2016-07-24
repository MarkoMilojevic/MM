using System.ComponentModel;
using System.Windows.Forms;

namespace MM.Chess
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStrip = new System.Windows.Forms.MenuStrip();
			this.editMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.setTimerMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.highlightAvailableMovesMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rowNumbersImage = new System.Windows.Forms.PictureBox();
			this.chessboardPanel = new System.Windows.Forms.Panel();
			this.columnLettersImage = new System.Windows.Forms.PictureBox();
			this.movesTextBox = new System.Windows.Forms.RichTextBox();
			this.newGameButton = new System.Windows.Forms.Button();
			this.drawButton = new System.Windows.Forms.Button();
			this.resignButton = new System.Windows.Forms.Button();
			this.takeBackButton = new System.Windows.Forms.Button();
			this.sacrificeButton = new System.Windows.Forms.Button();
			this.whiteLabel = new System.Windows.Forms.Label();
			this.whiteScoreLabel = new System.Windows.Forms.Label();
			this.scoreColonLabel = new System.Windows.Forms.Label();
			this.blackScoreLabel = new System.Windows.Forms.Label();
			this.blackLabel = new System.Windows.Forms.Label();
			this.whiteTimerImage = new System.Windows.Forms.PictureBox();
			this.blackTimerImage = new System.Windows.Forms.PictureBox();
			this.whiteMinutesLabel = new System.Windows.Forms.Label();
			this.whiteTimerColonLabel = new System.Windows.Forms.Label();
			this.whiteSecondsLabel = new System.Windows.Forms.Label();
			this.timerHyphenLabel = new System.Windows.Forms.Label();
			this.blackMinutesLabel = new System.Windows.Forms.Label();
			this.blackTimerColonLabel = new System.Windows.Forms.Label();
			this.blackSecondsLabel = new System.Windows.Forms.Label();
			this.statusTitleLabel = new System.Windows.Forms.Label();
			this.statusLabel = new System.Windows.Forms.Label();
			this.Timer = new System.Windows.Forms.Timer(this.components);
			this.menuStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rowNumbersImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.columnLettersImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.whiteTimerImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.blackTimerImage)).BeginInit();
			this.SuspendLayout();
			// 
			// menuStrip
			// 
			this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editMenuItem,
            this.viewMenuItem});
			this.menuStrip.Location = new System.Drawing.Point(0, 0);
			this.menuStrip.Name = "menuStrip";
			this.menuStrip.Size = new System.Drawing.Size(584, 24);
			this.menuStrip.TabIndex = 0;
			this.menuStrip.Text = "menuStrip1";
			// 
			// editMenuItem
			// 
			this.editMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setTimerMenuItem});
			this.editMenuItem.Name = "editMenuItem";
			this.editMenuItem.Size = new System.Drawing.Size(43, 20);
			this.editMenuItem.Text = "EDIT";
			// 
			// setTimerMenuItem
			// 
			this.setTimerMenuItem.Name = "setTimerMenuItem";
			this.setTimerMenuItem.Size = new System.Drawing.Size(130, 22);
			this.setTimerMenuItem.Text = "Set timer...";
			this.setTimerMenuItem.Click += new System.EventHandler(this.OnClickSetTimerMenuItem);
			// 
			// viewMenuItem
			// 
			this.viewMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highlightAvailableMovesMenuItem});
			this.viewMenuItem.Name = "viewMenuItem";
			this.viewMenuItem.Size = new System.Drawing.Size(46, 20);
			this.viewMenuItem.Text = "VIEW";
			// 
			// highlightAvailableMovesMenuItem
			// 
			this.highlightAvailableMovesMenuItem.Name = "highlightAvailableMovesMenuItem";
			this.highlightAvailableMovesMenuItem.Size = new System.Drawing.Size(190, 22);
			this.highlightAvailableMovesMenuItem.Text = "Show available moves";
			this.highlightAvailableMovesMenuItem.Click += new System.EventHandler(this.OnClickShowMovesMenuItem);
			// 
			// rowNumbersImage
			// 
			this.rowNumbersImage.Image = ((System.Drawing.Image)(resources.GetObject("rowNumbersImage.Image")));
			this.rowNumbersImage.Location = new System.Drawing.Point(19, 45);
			this.rowNumbersImage.Name = "rowNumbersImage";
			this.rowNumbersImage.Size = new System.Drawing.Size(25, 400);
			this.rowNumbersImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.rowNumbersImage.TabIndex = 1;
			this.rowNumbersImage.TabStop = false;
			// 
			// chessboardPanel
			// 
			this.chessboardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.chessboardPanel.Location = new System.Drawing.Point(50, 45);
			this.chessboardPanel.Name = "chessboardPanel";
			this.chessboardPanel.Size = new System.Drawing.Size(400, 400);
			this.chessboardPanel.TabIndex = 2;
			// 
			// columnLettersImage
			// 
			this.columnLettersImage.Image = ((System.Drawing.Image)(resources.GetObject("columnLettersImage.Image")));
			this.columnLettersImage.Location = new System.Drawing.Point(50, 451);
			this.columnLettersImage.Name = "columnLettersImage";
			this.columnLettersImage.Size = new System.Drawing.Size(400, 20);
			this.columnLettersImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.columnLettersImage.TabIndex = 3;
			this.columnLettersImage.TabStop = false;
			// 
			// movesTextBox
			// 
			this.movesTextBox.Enabled = false;
			this.movesTextBox.Location = new System.Drawing.Point(456, 45);
			this.movesTextBox.Name = "movesTextBox";
			this.movesTextBox.ReadOnly = true;
			this.movesTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.movesTextBox.Size = new System.Drawing.Size(123, 255);
			this.movesTextBox.TabIndex = 4;
			this.movesTextBox.Text = "";
			// 
			// newGameButton
			// 
			this.newGameButton.Location = new System.Drawing.Point(456, 306);
			this.newGameButton.Name = "newGameButton";
			this.newGameButton.Size = new System.Drawing.Size(123, 23);
			this.newGameButton.TabIndex = 5;
			this.newGameButton.Text = "New Game";
			this.newGameButton.UseVisualStyleBackColor = true;
			this.newGameButton.Click += new System.EventHandler(this.OnClickNewGameButton);
			// 
			// drawButton
			// 
			this.drawButton.Location = new System.Drawing.Point(456, 335);
			this.drawButton.Name = "drawButton";
			this.drawButton.Size = new System.Drawing.Size(123, 23);
			this.drawButton.TabIndex = 6;
			this.drawButton.Text = "Draw";
			this.drawButton.UseVisualStyleBackColor = true;
			this.drawButton.Click += new System.EventHandler(this.OnClickDrawButton);
			// 
			// resignButton
			// 
			this.resignButton.Location = new System.Drawing.Point(456, 364);
			this.resignButton.Name = "resignButton";
			this.resignButton.Size = new System.Drawing.Size(123, 23);
			this.resignButton.TabIndex = 7;
			this.resignButton.Text = "Resign";
			this.resignButton.UseVisualStyleBackColor = true;
			this.resignButton.Click += new System.EventHandler(this.OnClickResignButton);
			// 
			// takeBackButton
			// 
			this.takeBackButton.Location = new System.Drawing.Point(456, 393);
			this.takeBackButton.Name = "takeBackButton";
			this.takeBackButton.Size = new System.Drawing.Size(123, 23);
			this.takeBackButton.TabIndex = 8;
			this.takeBackButton.Text = "Take Back";
			this.takeBackButton.UseVisualStyleBackColor = true;
			this.takeBackButton.Click += new System.EventHandler(this.OnClickTakeBackButton);
			// 
			// sacrificeButton
			// 
			this.sacrificeButton.Location = new System.Drawing.Point(456, 422);
			this.sacrificeButton.Name = "sacrificeButton";
			this.sacrificeButton.Size = new System.Drawing.Size(123, 23);
			this.sacrificeButton.TabIndex = 9;
			this.sacrificeButton.Text = "Sacrifice";
			this.sacrificeButton.UseVisualStyleBackColor = true;
			this.sacrificeButton.Click += new System.EventHandler(this.OnClickSacrificeButton);
			// 
			// whiteLabel
			// 
			this.whiteLabel.AutoSize = true;
			this.whiteLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteLabel.Location = new System.Drawing.Point(132, 480);
			this.whiteLabel.Name = "whiteLabel";
			this.whiteLabel.Size = new System.Drawing.Size(82, 26);
			this.whiteLabel.TabIndex = 10;
			this.whiteLabel.Text = "WHITE";
			// 
			// whiteScoreLabel
			// 
			this.whiteScoreLabel.AutoSize = true;
			this.whiteScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteScoreLabel.Location = new System.Drawing.Point(220, 480);
			this.whiteScoreLabel.Name = "whiteScoreLabel";
			this.whiteScoreLabel.Size = new System.Drawing.Size(24, 26);
			this.whiteScoreLabel.TabIndex = 11;
			this.whiteScoreLabel.Text = "0";
			// 
			// scoreColonLabel
			// 
			this.scoreColonLabel.AutoSize = true;
			this.scoreColonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.scoreColonLabel.Location = new System.Drawing.Point(250, 480);
			this.scoreColonLabel.Name = "scoreColonLabel";
			this.scoreColonLabel.Size = new System.Drawing.Size(18, 26);
			this.scoreColonLabel.TabIndex = 12;
			this.scoreColonLabel.Text = ":";
			// 
			// blackScoreLabel
			// 
			this.blackScoreLabel.AutoSize = true;
			this.blackScoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackScoreLabel.Location = new System.Drawing.Point(274, 480);
			this.blackScoreLabel.Name = "blackScoreLabel";
			this.blackScoreLabel.Size = new System.Drawing.Size(24, 26);
			this.blackScoreLabel.TabIndex = 13;
			this.blackScoreLabel.Text = "0";
			// 
			// blackLabel
			// 
			this.blackLabel.AutoSize = true;
			this.blackLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackLabel.Location = new System.Drawing.Point(304, 480);
			this.blackLabel.Name = "blackLabel";
			this.blackLabel.Size = new System.Drawing.Size(85, 26);
			this.blackLabel.TabIndex = 14;
			this.blackLabel.Text = "BLACK";
			// 
			// whiteTimerImage
			// 
			this.whiteTimerImage.Image = ((System.Drawing.Image)(resources.GetObject("whiteTimerImage.Image")));
			this.whiteTimerImage.Location = new System.Drawing.Point(139, 510);
			this.whiteTimerImage.Name = "whiteTimerImage";
			this.whiteTimerImage.Size = new System.Drawing.Size(24, 24);
			this.whiteTimerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.whiteTimerImage.TabIndex = 15;
			this.whiteTimerImage.TabStop = false;
			// 
			// blackTimerImage
			// 
			this.blackTimerImage.Image = ((System.Drawing.Image)(resources.GetObject("blackTimerImage.Image")));
			this.blackTimerImage.Location = new System.Drawing.Point(348, 510);
			this.blackTimerImage.Name = "blackTimerImage";
			this.blackTimerImage.Size = new System.Drawing.Size(24, 24);
			this.blackTimerImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.blackTimerImage.TabIndex = 16;
			this.blackTimerImage.TabStop = false;
			// 
			// whiteMinutesLabel
			// 
			this.whiteMinutesLabel.AutoSize = true;
			this.whiteMinutesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteMinutesLabel.Location = new System.Drawing.Point(175, 518);
			this.whiteMinutesLabel.Name = "whiteMinutesLabel";
			this.whiteMinutesLabel.Size = new System.Drawing.Size(24, 17);
			this.whiteMinutesLabel.TabIndex = 17;
			this.whiteMinutesLabel.Text = "00";
			// 
			// whiteTimerColonLabel
			// 
			this.whiteTimerColonLabel.AutoSize = true;
			this.whiteTimerColonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteTimerColonLabel.Location = new System.Drawing.Point(205, 518);
			this.whiteTimerColonLabel.Name = "whiteTimerColonLabel";
			this.whiteTimerColonLabel.Size = new System.Drawing.Size(12, 17);
			this.whiteTimerColonLabel.TabIndex = 18;
			this.whiteTimerColonLabel.Text = ":";
			// 
			// whiteSecondsLabel
			// 
			this.whiteSecondsLabel.AutoSize = true;
			this.whiteSecondsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whiteSecondsLabel.Location = new System.Drawing.Point(223, 518);
			this.whiteSecondsLabel.Name = "whiteSecondsLabel";
			this.whiteSecondsLabel.Size = new System.Drawing.Size(24, 17);
			this.whiteSecondsLabel.TabIndex = 19;
			this.whiteSecondsLabel.Text = "00";
			// 
			// timerHyphenLabel
			// 
			this.timerHyphenLabel.AutoSize = true;
			this.timerHyphenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.timerHyphenLabel.Location = new System.Drawing.Point(253, 520);
			this.timerHyphenLabel.Name = "timerHyphenLabel";
			this.timerHyphenLabel.Size = new System.Drawing.Size(13, 17);
			this.timerHyphenLabel.TabIndex = 20;
			this.timerHyphenLabel.Text = "-";
			// 
			// blackMinutesLabel
			// 
			this.blackMinutesLabel.AutoSize = true;
			this.blackMinutesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackMinutesLabel.Location = new System.Drawing.Point(272, 518);
			this.blackMinutesLabel.Name = "blackMinutesLabel";
			this.blackMinutesLabel.Size = new System.Drawing.Size(24, 17);
			this.blackMinutesLabel.TabIndex = 21;
			this.blackMinutesLabel.Text = "00";
			// 
			// blackTimerColonLabel
			// 
			this.blackTimerColonLabel.AutoSize = true;
			this.blackTimerColonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackTimerColonLabel.Location = new System.Drawing.Point(302, 518);
			this.blackTimerColonLabel.Name = "blackTimerColonLabel";
			this.blackTimerColonLabel.Size = new System.Drawing.Size(12, 17);
			this.blackTimerColonLabel.TabIndex = 22;
			this.blackTimerColonLabel.Text = ":";
			// 
			// blackSecondsLabel
			// 
			this.blackSecondsLabel.AutoSize = true;
			this.blackSecondsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.blackSecondsLabel.Location = new System.Drawing.Point(318, 518);
			this.blackSecondsLabel.Name = "blackSecondsLabel";
			this.blackSecondsLabel.Size = new System.Drawing.Size(24, 17);
			this.blackSecondsLabel.TabIndex = 23;
			this.blackSecondsLabel.Text = "00";
			// 
			// statusTitleLabel
			// 
			this.statusTitleLabel.AutoSize = true;
			this.statusTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusTitleLabel.Location = new System.Drawing.Point(14, 576);
			this.statusTitleLabel.Name = "statusTitleLabel";
			this.statusTitleLabel.Size = new System.Drawing.Size(80, 26);
			this.statusTitleLabel.TabIndex = 24;
			this.statusTitleLabel.Text = "Status:";
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusLabel.Location = new System.Drawing.Point(100, 576);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(158, 26);
			this.statusLabel.TabIndex = 25;
			this.statusLabel.Text = "WHITE to play.";
			// 
			// Timer
			// 
			this.Timer.Interval = 1000;
			this.Timer.Tick += new System.EventHandler(this.TimerTick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(584, 611);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.statusTitleLabel);
			this.Controls.Add(this.blackMinutesLabel);
			this.Controls.Add(this.blackTimerColonLabel);
			this.Controls.Add(this.blackSecondsLabel);
			this.Controls.Add(this.timerHyphenLabel);
			this.Controls.Add(this.whiteSecondsLabel);
			this.Controls.Add(this.whiteTimerColonLabel);
			this.Controls.Add(this.whiteMinutesLabel);
			this.Controls.Add(this.blackTimerImage);
			this.Controls.Add(this.whiteTimerImage);
			this.Controls.Add(this.blackLabel);
			this.Controls.Add(this.blackScoreLabel);
			this.Controls.Add(this.scoreColonLabel);
			this.Controls.Add(this.whiteScoreLabel);
			this.Controls.Add(this.whiteLabel);
			this.Controls.Add(this.sacrificeButton);
			this.Controls.Add(this.takeBackButton);
			this.Controls.Add(this.resignButton);
			this.Controls.Add(this.drawButton);
			this.Controls.Add(this.newGameButton);
			this.Controls.Add(this.movesTextBox);
			this.Controls.Add(this.columnLettersImage);
			this.Controls.Add(this.chessboardPanel);
			this.Controls.Add(this.rowNumbersImage);
			this.Controls.Add(this.menuStrip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStrip;
			this.MaximizeBox = false;
			this.MinimumSize = new System.Drawing.Size(600, 650);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Chess";
			this.menuStrip.ResumeLayout(false);
			this.menuStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.rowNumbersImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.columnLettersImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.whiteTimerImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.blackTimerImage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private MenuStrip menuStrip;
		private ToolStripMenuItem editMenuItem;
		private ToolStripMenuItem setTimerMenuItem;
		private ToolStripMenuItem viewMenuItem;
		private ToolStripMenuItem highlightAvailableMovesMenuItem;
		private Panel chessboardPanel;
		private PictureBox rowNumbersImage;
		private PictureBox columnLettersImage;
		private RichTextBox movesTextBox;
		private Button newGameButton;
		private Button drawButton;
		private Button resignButton;
		private Button takeBackButton;
		private Button sacrificeButton;
		private PictureBox whiteTimerImage;
		private PictureBox blackTimerImage;
		private Label whiteLabel;
		private Label whiteScoreLabel;
		private Label scoreColonLabel;
		private Label blackScoreLabel;
		private Label blackLabel;
		private Label whiteMinutesLabel;
		private Label whiteTimerColonLabel;
		private Label whiteSecondsLabel;
		private Label timerHyphenLabel;
		private Label blackMinutesLabel;
		private Label blackTimerColonLabel;
		private Label blackSecondsLabel;
		private Label statusTitleLabel;
		private Label statusLabel;
		private Timer Timer;
	}
}

