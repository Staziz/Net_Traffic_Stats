using System;
using System.Windows.Forms;

namespace Net_Traffic_Stats
{
	public abstract class TrayIconNotificationContext : ApplicationContext
	{
		private readonly ContextMenuStrip contextMenuStrip;
		private readonly NotifyIcon notifyIcon;

		protected ContextMenuStrip ContextMenu { get => contextMenuStrip; }
		protected NotifyIcon TrayIcon { get => notifyIcon; }

		protected TrayIconNotificationContext()
		{
			contextMenuStrip = new ContextMenuStrip();
			notifyIcon = new NotifyIcon
			{
				ContextMenuStrip = ContextMenu,
				Text = Application.ProductName,
				Visible = true
			};
		}

		protected virtual void OnApplicationExit(EventArgs e)
		{
			if (contextMenuStrip != null)
			{
				contextMenuStrip.Dispose();
			}

			if (notifyIcon != null)
			{
				notifyIcon.Visible = false;
				notifyIcon.Dispose();
			}
		}

		protected virtual void OnTrayIconDoubleClick(MouseEventArgs e)
		{ }

		private void ApplicationExitHandler(object sender, EventArgs e)
		{
			OnApplicationExit(e);
		}

		private void TrayIconDoubleClickHandler(object sender, MouseEventArgs e)
		{
			OnTrayIconDoubleClick(e);
		}
	}
}