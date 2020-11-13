using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;

namespace ConsoleAppKodeRefactoring
{
    class DHCPServer
    {
        public string DisplayDhcpServerAddresses()
        {
            string displayDHCP;
            displayDHCP = "DHCP Servers";
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in adapters)
            {
                IPInterfaceProperties adapteradapterProperties = adapter.GetIPProperties();
                IPAddressCollection addresses = adapteradapterProperties.DhcpServerAddresses;
                if (addresses.Count > 0)
                {
                    displayDHCP = displayDHCP + "\n" + adapter.Description;
                    foreach (IPAddress address in addresses)
                    {
                        displayDHCP = displayDHCP + $"\nDhcp Address ............................ : {address.ToString()}";
                    }
                    Console.WriteLine();
                }
            }
            return displayDHCP;
        }
    }
}
