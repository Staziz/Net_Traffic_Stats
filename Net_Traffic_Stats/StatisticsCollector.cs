using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Net_Traffic_Stats
{
	internal static class StatisticsCollector
	{
		internal static void GetTcpStatistics(NetworkInterfaceComponent version)
		{
			IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
			TcpStatistics tcpstat = null;
			string result = "";
			switch (version)
			{
				case NetworkInterfaceComponent.IPv4:
					tcpstat = properties.GetTcpIPv4Statistics();
					result += "TCP/IPv4 Statistics:\n";
					break;
				case NetworkInterfaceComponent.IPv6:
					tcpstat = properties.GetTcpIPv6Statistics();
					result += "TCP/IPv6 Statistics:\n";
					break;
				default:
					throw new ArgumentException("version");
			}
			result += $"\tMinimum Transmission Timeout: {tcpstat.MinimumTransmissionTimeout}";
			result += $"\tMaximum Transmission Timeout: {tcpstat.MaximumTransmissionTimeout}";
			
			result += "\tConnection Data:";
			result += $"\t\tCurrent: {tcpstat.CurrentConnections}";
			result += $"\t\tCumulative: {tcpstat.CumulativeConnections}";
			result += $"\t\tInitiated: {tcpstat.ConnectionsInitiated}";
			result += $"\t\tAccepted: {tcpstat.ConnectionsAccepted}";
			result += $"\t\tFailed Attempts: {tcpstat.FailedConnectionAttempts}";
			result += $"\t\tReset: {tcpstat.ResetConnections}";

			result += $"\tSegment Data:";
			result += $"\t\tReceived: {tcpstat.SegmentsReceived}";
			result += $"\t\tSent: {tcpstat.SegmentsSent}";
			result += $"\t\tRetransmitted: {tcpstat.SegmentsResent}";

			result += "";
		}
	}
}
