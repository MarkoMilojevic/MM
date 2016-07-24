using System;
using System.Linq;
using System.Windows.Forms;
using MM.Chess.Properties;

namespace MM.Chess
{
	public partial class TimerForm : Form
	{
		public int Selection { get; private set; }

		public TimerForm()
		{
			this.InitializeComponent();
		}

		private void OnClickOkButton(object sender, EventArgs e)
		{
			RadioButton checkedButton = this.choice.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
			if (checkedButton != null)
			{
				if (checkedButton.Text == Resources.Time5min)
				{
					this.Selection = 300;
				}
				else if (checkedButton.Text == Resources.Time10min)
				{
					this.Selection = 600;
				}
				else if (checkedButton.Text == Resources.Time15min)
				{
					this.Selection = 900;
				}
				else if (checkedButton.Text == Resources.Time30min)
				{
					this.Selection = 1800;
				}
				else if (checkedButton.Text == Resources.TimeNoLimit)
				{
					this.Selection = 0;
				}
			}

			this.Hide();
		}
	}
}
