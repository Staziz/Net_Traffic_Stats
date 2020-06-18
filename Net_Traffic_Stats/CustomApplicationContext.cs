using System;
using System.Threading;
using System.Windows.Forms;

namespace Net_Traffic_Stats
{
	internal class CustomApplicationContext : TrayIconNotificationContext
	{
		private AdapterChooser adapterChooser;
		private Thread statisticsThread;

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

			DocumentWriter.WriteProperties(StatisticsCollector.GetStatistics(StatistiscType.undef));
			statisticsThread = new Thread(() => GetStatistics());
			statisticsThread.IsBackground = true;
			statisticsThread.Priority = ThreadPriority.BelowNormal;
			statisticsThread.Start();
		}

		private void GetStatistics()
		{
			while (!Program.exitFlag)
			{
				DocumentWriter.WriteIPInterfaceStatistics(StatisticsCollector.GetIPIntefaceStatistics());
				DocumentWriter.WriteTCPStatistics(StatisticsCollector.GetTCPStatistics());
				DocumentWriter.WriteIPStatistics(StatisticsCollector.GetIPStatistics());
				DocumentWriter.WriteICMPStatistics(StatisticsCollector.GetICMPStatistics());
				DocumentWriter.WriteUDPStatistics(StatisticsCollector.GetUDPStatistics());

				try
				{
					Thread.Sleep(new TimeSpan(0, 1, 0));
				}
				catch
				{
					ExitThread();
				}
			}
		}

		protected override void OnTrayIconDoubleClick(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
				ShowAdapterChooser();

			base.OnTrayIconDoubleClick(e);
		}

		private void ExitContextMenuClickHandler(object sender, EventArgs eventArgs)
		{
			Program.exitFlag = false;
			statisticsThread.Abort();
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
