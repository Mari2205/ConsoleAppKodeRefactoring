using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppKodeRefactoring
{
    class Program
    {
        static void Main()
        {
            PingAdr pingAdr = new PingAdr();
            DnsLookUp dnsLookUp = new DnsLookUp();
            DHCPServer dhcpServer = new DHCPServer();
            IpAdr ipAdr = new IpAdr();
            Ui ui = new Ui();

            //ip på en url
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("URL)");
            Console.Write("indtast Url :");
            string usrUrl = Console.ReadLine();
            ipAdr.GetUlrIp(usrUrl);

            ui.ContinueProcess("continue to Local Ping");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Local ping)");
            Console.WriteLine(pingAdr.LocalPing());

            ui.ContinueProcess("continue to DNS");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("DNS)");
            Console.Write("indtast en dns :");
            string usrDns = Console.ReadLine();
            string dnsHostName = dnsLookUp.GetHostnameFromIp(usrDns);
            Console.WriteLine(dnsHostName);
            string dnsLookUpAdr = dnsLookUp.GetIpFromHostname(dnsHostName);
            Console.WriteLine("Weee (Waste Electrical & Electronic Equipment) " + dnsLookUpAdr);
            string dnsAdresse = pingAdr.Traceroute(usrDns);
            Console.WriteLine("route*** " + dnsAdresse);

            ui.ContinueProcess("continue to DHCP");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("DHCP)");
            Console.WriteLine(dhcpServer.DisplayDhcpServerAddresses());

            ui.ContinueProcess("continue to Computerne");

            // pc´en detejeler
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Computerne");
            Console.Write("indtast computernavn :");
            string usrHostname = Console.ReadLine();
            Console.WriteLine(ipAdr.HostPcData(usrHostname));

            ui.ContinueProcess("exit");

        }
    }
}
