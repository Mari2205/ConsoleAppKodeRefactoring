using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Diagnostics;

namespace ConsoleAppKodeRefactoring
{
    class PingAdr
    {
        /// <summary>
        /// Ping's the local machine.
        /// </summary>
        /// <returns></returns>
        public string LocalPing()
        {

            Ping pingSender = new Ping();
            IPAddress address = IPAddress.Loopback;
            PingReply reply = pingSender.Send(address);

            if (reply.Status == IPStatus.Success)
            {
                string pingResponse = $"Address: {reply.Address.ToString()} " +
                    $"\nRoundTrip time: {reply.RoundtripTime} " +
                    $"\nTime to live: {reply.Options.Ttl} " +
                    $"\nDon't fragment: {reply.Options.DontFragment} " +
                    $"\nBuffer size: {reply.Buffer.Length}";

                return pingResponse;
            }
            else
            {
                string statusReply = reply.Status.ToString();
                return statusReply;
            }
        }


        public string Traceroute(string ipAddressOrHostName)
        {
            IPAddress ipAddress = Dns.GetHostEntry(ipAddressOrHostName).AddressList[0];
            StringBuilder traceResults = new StringBuilder();


            using (Ping pingSender = new Ping())
            {

                PingOptions pingOptions = new PingOptions();
                Stopwatch stopWatch = new Stopwatch();
                byte[] bytes = new byte[32];

                pingOptions.DontFragment = true;
                pingOptions.Ttl = 1;
                int maxHops = 30;

                traceResults.AppendLine(
                    string.Format(
                        "Tracing route to {0} over a maximum of {1} hops:",
                        ipAddress,
                        maxHops));

                traceResults.AppendLine();

                for (int i = 1; i < maxHops + 1; i++)
                {
                    stopWatch.Reset();
                    stopWatch.Start();

                    PingReply pingReply = pingSender.Send(
                        ipAddress,
                        5000,
                        new byte[32], pingOptions);

                    stopWatch.Stop();

                    traceResults.AppendLine(
                        string.Format("{0}\t{1} ms\t{2}",
                        i,
                        stopWatch.ElapsedMilliseconds,
                        pingReply.Address));



                    if (pingReply.Status == IPStatus.Success)
                    {
                        traceResults.AppendLine();
                        traceResults.AppendLine("Trace complete."); break;
                    }

                    pingOptions.Ttl++;

                }
            }
            return traceResults.ToString();
        }

    }
}
