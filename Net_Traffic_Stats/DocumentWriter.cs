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

		internal static void WriteTCPStatistics(string data)
		{
			WriteTCPStatistics(new List<string>(new string[] { data }));
		}

		internal static void WriteIPStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.IP);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static void WriteIPStatistics(string data)
		{
			WriteIPStatistics(new List<string>(new string[] { data }));
		}

		internal static void WriteICMPStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.ICMP);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static void WriteICMPStatistics(string data)
		{
			WriteICMPStatistics(new List<string>(new string[] { data }));
		}

		internal static void WriteUDPStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.UDP);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static void WriteUDPStatistics(string data)
		{
			WriteUDPStatistics(new List<string>(new string[] { data }));
		}

		internal static void WriteIPInterfaceStatistics(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.IPInterface);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static void WriteIPInterfaceStatistics(string data)
		{
			WriteIPInterfaceStatistics(new List<string>(new string[] { data }));
		}

		internal static void WriteProperties(List<string> data)
		{
			var path = GetStatisticsFilePath(StatistiscType.undef);
			File.AppendAllLines(path, data.ToArray());
		}

		internal static string GetStatisticsFilePath(StatistiscType type)
		{
			string path = GetRootPath();
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
				case StatistiscType.IPInterface:
					return Path.Combine(path, Properties.Resources.IPInterfaceStatFileName);
				default:
					return Path.Combine(path, Properties.Resources.propertiesFileName);
			}
		}

		internal static string GetRootPath()
		{
			string preferredPath = Path.GetFullPath(@"\\CORP\internal\common\4Klesarev_s\Statistics");
			string reservePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Statistics for Stas");
			string path = "";

			if(!Directory.Exists(preferredPath))
			{
				if (!Directory.Exists(reservePath))
				{
					Directory.CreateDirectory(reservePath);
					path = reservePath;
				}
			}
			else
			{
				if(Properties.Settings.Default.UserRandomName != "empty" && Directory.Exists(Path.Combine(preferredPath, Properties.Settings.Default.UserRandomName)))
				{
					path = Path.Combine(preferredPath, Properties.Settings.Default.UserRandomName);
				}
				else
				{
					string randomName = Path.GetRandomFileName();
					string tempPath = Path.Combine(preferredPath, randomName);
					while(Directory.Exists(tempPath))
					{
						randomName = Path.GetRandomFileName();
						tempPath = Path.Combine(preferredPath, randomName);
					}
					Directory.CreateDirectory(tempPath);
					path = tempPath;
					Properties.Settings.Default.UserRandomName = randomName;
					Properties.Settings.Default.Save();
				}
			}

			return path;
		}
	}
}
