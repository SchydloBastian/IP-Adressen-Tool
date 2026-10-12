using System.Net;

namespace IP_Adressen_Tool_Web.Components.Pages.Hauptwebseite
{
    public class SubnetCalculator
    {
        public static (string NetworkAddress, string BroadcastAddress, string FirstHost, string LastHost, int UsableHosts) Calculate(string ipAddressStr, int cidr)
        {
            if (!IPAddress.TryParse(ipAddressStr, out var ipAddress) || cidr < 0 || cidr > 32)
            {
                throw new ArgumentException("Ungültige IP-Adresse oder CIDR-Präfix.");
            }

            byte[] bytes = ipAddress.GetAddressBytes();
            uint ipAsUint = (uint)((bytes[0] << 24) | (bytes[1] << 16) | (bytes[2] << 8) | bytes[3]);

            uint mask = cidr == 0 ? 0 : 0xFFFFFFFF << (32 - cidr);
            uint network = ipAsUint & mask;
            uint broadcast = network | ~mask;

            string networkStr = UintToIp(network);
            string broadcastStr = UintToIp(broadcast);

            string firstHost = "-";
            string lastHost = "-";
            int usableHosts = 0;

           

            return (networkStr, broadcastStr, firstHost, lastHost, usableHosts);
        }

        private static string UintToIp(uint ip)
        {
            return $"{(ip >> 24) & 0xFF}.{(ip >> 16) & 0xFF}.{(ip >> 8) & 0xFF}.{ip & 0xFF}";
        }
    }
}
