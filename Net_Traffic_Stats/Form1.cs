using System.Windows.Forms;

namespace Net_Traffic_Stats
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void selectButton_Click(object sender, System.EventArgs e)
		{
			DataGridViewRow selectedRow = null;
			if (adapterGrid.SelectedRows.Count != 0)
			{
				selectedRow = adapterGrid.SelectedRows[0];
			}
			else
			{
				if (adapterGrid.SelectedCells.Count != 0)
				{
					var selectedCell = adapterGrid.SelectedCells[0];
					selectedRow = adapterGrid.Rows[selectedCell.RowIndex];
				}
			}
			if (selectedRow != null)
			{
				Properties.Settings.Default.SelectedAdapterID
			}
		}
	}
}
