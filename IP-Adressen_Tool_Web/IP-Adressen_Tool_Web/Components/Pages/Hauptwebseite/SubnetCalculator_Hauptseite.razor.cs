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

            
        }

        
    }
}
