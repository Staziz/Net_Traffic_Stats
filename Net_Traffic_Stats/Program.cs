﻿using System;
using System.Windows.Forms;

namespace Net_Traffic_Stats
{
	static class Program
	{
		internal static bool exitFlag = false;
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new CustomApplicationContext());
		}
	}
}
