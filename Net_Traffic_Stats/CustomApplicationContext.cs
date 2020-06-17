using System;
using System.Windows.Forms;

namespace Net_Traffic_Stats
{
	internal class CustomApplicationContext : TrayIconNotificationContext
	{
		private AdapterChooser adapterChooser;

		public CustomApplicationContext()
		{
			TrayIcon.Icon = Properties.Resources.Icon;

			ContextMenu.Items.Add("&Adapter", null, AdapterContextMenuClickHandler);
			ContextMenu.Items.Add("-");
			ContextMenu.Items.Add("E&xit", null, ExitContextMenuClickHandler);

			if (Properties.Settings.Default.SelectedAdapterID == "empty")
			{
				ShowAdapterChooser();
			}

			DocumentWriter.WriteTCPStatistics(StatisticsCollector.GetTCPStatistics());
			DocumentWriter.WriteIPStatistics(StatisticsCollector.GetIPIntefaceStatistics());
		}

		protected override void OnTrayIconDoubleClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				ShowAdapterChooser();

			base.OnTrayIconDoubleClick(e);
		}

		private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
		{
			ExitThread();
		}

		private void AdapterContextMenuClickHandler(object sender, EventArgs eventArgs)
		{
			ShowAdapterChooser();
		}

		private void ShowAdapterChooser()
		{
			if (adapterChooser == null)
			{
				using (adapterChooser = new AdapterChooser())
					adapterChooser.ShowDialog();
				adapterChooser = null;
			}
			else
				adapterChooser.Activate();
		}
	}
}
