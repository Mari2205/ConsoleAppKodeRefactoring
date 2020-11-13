using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace ConsoleAppKodeRefactoring
{
    class IpAdr
    {
        public string HostPcData(string pcHostname)
        {
            string hostName = pcHostname;
            IPHostEntry hostInfo = Dns.GetHostByName(hostName);

            // Get the IP address list that resolves to the host names contained in the 
            // Alias property.
            IPAddress[] address = hostInfo.AddressList;

            // Get the alias names of the addresses in the IP address list.
            String[] alias = hostInfo.Aliases;

            string hostPcDetiels;
            hostPcDetiels = $"\nHost name : {hostInfo.HostName} \n\nAliases : ";


            for (int index = 0; index < alias.Length; index++)
            {
                hostPcDetiels = hostPcDetiels + "\n" + alias[index].ToString();
            }

            hostPcDetiels = hostPcDetiels + "\nIP address list : ";

            for (int index = 0; index < address.Length; index++)
            {
                hostPcDetiels = hostPcDetiels + "\n" + address[index].ToString();
            }

            return hostPcDetiels;

        }

        /// <summary>
        /// henter url´s ip
        /// </summary>
        public void GetUlrIp(string url)
        {
            IPAddress[] array = Dns.GetHostAddresses(url);
            foreach (IPAddress ip in array)
            {
                Console.WriteLine(ip.ToString());
            }
        }
    }
}
