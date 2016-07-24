using System;
using System.Linq;
using System.Windows.Forms;

namespace MM.Chess
{
	internal partial class WhitePawnPromotionForm : Form
	{
		public Promotion Selection { get; private set; }

		public WhitePawnPromotionForm()
		{
			this.InitializeComponent();
		}

		private void OnClickOkButton(object sender, EventArgs e)
		{
			RadioButton checkedButton = this.choice.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			if (checkedButton != null)
			{
				switch (checkedButton.Text)
				{
					case "Queen":
						this.Selection = Promotion.Queen;
						break;
					case "Rook":
						this.Selection = Promotion.Rook;
						break;
					case "Bishop":
						this.Selection = Promotion.Bishop;
						break;
					case "Knight":
						this.Selection = Promotion.Knight;
						break;
				}
			}

			this.Hide();
		}
	}
}
