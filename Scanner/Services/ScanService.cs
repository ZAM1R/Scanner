using Scanner.Interfaces;
using Scanner.Model;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;

namespace Scanner.Services
{
    public class ScanService : IScanService
    {

        public async Task<ObservableCollection<Scan>> Scan(ObservableCollection<Scan> scannedIpList, string ip, int startPort, int endPort)
        {
            IPAddress ipa = (IPAddress)Dns.GetHostAddresses(ip)[0];
            for (int i = startPort; i <= endPort; i++)
            {

                try
                {
                    System.Net.Sockets.Socket sock = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, System.Net.Sockets.ProtocolType.Tcp);
                    sock.Connect(ipa, i);
                    if (sock.Connected == true)  // Port is in use and connection is successful
                        scannedIpList.Add(new Scan() { Ip = ip, Port = i, IsOpen = "Open" }); // MessageBox.Show("Port is Closed");
                    sock.Close();

                }
                catch (System.Net.Sockets.SocketException ex)
                {
                    if (ex.ErrorCode == 10061)  // Port is unused and could not establish connection 
                        scannedIpList.Add(new Scan() { Ip = ip, Port = i, IsOpen = "Closed" }); // MessageBox.Show("Port is Open!");
                    //else
                    //    MessageBox.Show(ex.Message);
                }
            }

            return scannedIpList;

        }
    }
}
