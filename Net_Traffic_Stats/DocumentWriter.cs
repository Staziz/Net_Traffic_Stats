using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Traffic_Stats
{

	internal static class DocumentWriter
	{
		internal static void WriteTCPStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.TCP);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static void WriteIPStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.IP);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static void WriteICMPStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.IP);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static void WriteUDPStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.IP);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static string GetStatisticsFilePath(StatistiscType type)
		{
			var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Statistics for Stas");
			EnsurePathExists(path);
			switch (type)
			{
				case StatistiscType.TCP:
					return Path.Combine(path, Properties.Resources.TCPStatFileName);
				case StatistiscType.IP:
					return Path.Combine(path, Properties.Resources.IPStatFileName);
				case StatistiscType.ICMP:
					return Path.Combine(path, Properties.Resources.ICMPStatFileName);
				case StatistiscType.UDP:
					return Path.Combine(path, Properties.Resources.UDPStatFileName);
				default:
					return Path.Combine(path, Properties.Resources.statisticsFileName);
			}
		}

		internal static void EnsurePathExists(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
	}
}
