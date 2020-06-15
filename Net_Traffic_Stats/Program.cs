using System;
using System.Windows.Forms;

namespace Net_Traffic_Stats
{
	static class Program
	{
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			if (Properties.Settings.Default.SelectedAdapterID == "empty")
			{
				Application.Run(new Form1());
			}
			Application.Run();
		}
	}
}
