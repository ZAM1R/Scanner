using Scanner.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Scanner.Interfaces
{
    public interface IScanService
    {
        Task<ObservableCollection<Scan>> Scan(ObservableCollection<Scan> scannedIpList, string ip, int startPort, int endPort);
    }
}
