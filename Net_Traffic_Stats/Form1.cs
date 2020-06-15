﻿using System.Net.NetworkInformation;
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
				Properties.Settings.Default.SelectedAdapterID = selectedRow.Cells["AdapterID"].Value.ToString();
				Properties.Settings.Default.Save();
			}
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason != CloseReason.UserClosing)
			{
				return;
			}
			e.Cancel = true;
			(sender as Form).Hide();
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface adapter in interfaces)
			{
				string versions = "";

				if (adapter.Supports(NetworkInterfaceComponent.IPv4))
				{
					versions = "IPv4";
				}
				if (adapter.Supports(NetworkInterfaceComponent.IPv6))
				{
					if (versions.Length > 0)
					{
						versions += " ";
					}
					versions += "IPv6";
				}

				adapterGrid.Rows.Add(new string[] {
					adapter.Id,
					adapter.Name,
					adapter.Description,
					adapter.OperationalStatus.ToString(),
					adapter.NetworkInterfaceType.ToString(),
					versions
				});
			}
		}
	}
}
