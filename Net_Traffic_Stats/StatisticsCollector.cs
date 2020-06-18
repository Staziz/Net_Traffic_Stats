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
			if (@interface != null)
			{
				string temp = $"{DateTime.Now.ToString("d/M/yyyy-hh:mm:ss:FFF")};";

				ipStat = @interface.GetIPStatistics();
				var props = ipStat.GetType().GetProperties();

				foreach (var property in props)
				{
					temp += $"{property.GetValue(ipStat)};";
				}

				result.Add(temp);
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
					return GetPropertyNames();
			}

			string temp = $"{DateTime.Now.ToString("d/M/yyyy-hh:mm:ss:FFF")};";

			foreach (var property in properties)
			{
				temp += $"{property.GetValue(stat)};";
			}

			result.Add(temp);

			return result;
		}

		private static List<string> GetPropertyNames()
		{
			PropertyInfo[] properties = null;
			IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
			List<string> result = new List<string>();
			result.Add($"{DateTime.Now.ToString("d/M/yyyy-hh:mm:ss:FFF")};");

			properties = typeof(TcpStatistics).GetProperties();
			string temp = "TCP;";
			foreach (var property in properties)
			{
				temp += $"{property.Name};";
			}
			result.Add(temp);

			properties = typeof(IPGlobalStatistics).GetProperties();
			temp = "IP;";
			foreach (var property in properties)
			{
				temp += $"{property.Name};";
			}
			result.Add(temp);

			properties = typeof(IcmpV4Statistics).GetProperties();
			temp = "ICMP;";
			foreach (var property in properties)
			{
				temp += $"{property.Name};";
			}
			result.Add(temp);

			properties = typeof(UdpStatistics).GetProperties();
			temp = "UDP;";
			foreach (var property in properties)
			{
				temp += $"{property.Name};";
			}
			result.Add(temp);

			properties = typeof(IPInterfaceStatistics).GetProperties();
			temp = "IPInterface;";
			foreach (var property in properties)
			{
				temp += $"{property.Name};";
			}
			result.Add(temp);

			return result;
		}
	}
}
