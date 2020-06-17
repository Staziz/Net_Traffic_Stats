using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Net_Traffic_Stats
{
	internal static class StatisticsCollector
	{
		internal static List<string> GetIPIntefaceStatistics()
		{
			NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
			NetworkInterface @interface = interfaces.FirstOrDefault(i => i.Id == Properties.Settings.Default.SelectedAdapterID);
			IPInterfaceStatistics ipStat = null;
			List<string> result = new List<string>();
			ipStat = @interface.GetIPStatistics();

			var props = ipStat.GetType().GetProperties();
			foreach (var property in props)
			{
				result.Add($"\t{property.Name}: {property.GetValue(ipStat)}");
			}
			return result;
		}

		internal static List<string> GetTCPStatistics()
		{
			return GetStatistics(StatistiscType.TCP);
		}

		internal static List<string> GetIPStatistics()
		{
			return GetStatistics(StatistiscType.IP);
		}

		internal static List<string> GetICMPStatistics()
		{
			return GetStatistics(StatistiscType.ICMP);
		}

		internal static List<string> GetUDPStatistics()
		{
			return GetStatistics(StatistiscType.UDP);
		}

		internal static List<string> GetStatistics(StatistiscType type)
		{
			object stat = null;
			PropertyInfo[] properties = null;
			IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
			List<string> result = new List<string>();
			switch (type)
			{
				case StatistiscType.TCP:
					stat = ipProperties.GetTcpIPv4Statistics();
					properties = typeof(TcpStatistics).GetProperties();
					break;
				case StatistiscType.IP:
					stat = ipProperties.GetIPv4GlobalStatistics();
					properties = typeof(IPGlobalStatistics).GetProperties();
					break;
				case StatistiscType.ICMP:
					stat = ipProperties.GetIcmpV4Statistics();
					properties = typeof(IcmpV4Statistics).GetProperties();
					break;
				case StatistiscType.UDP:
					stat = ipProperties.GetUdpIPv4Statistics();
					properties = typeof(UdpStatistics).GetProperties();
					break;
				default:
					return null;
			}
			foreach (var property in properties)
			{
				result.Add($"\t{property.Name}: {property.GetValue(stat)}");
			}

			return result;
		}
	}
}
