using Prism.Commands;
using Scanner.Interfaces;
using Scanner.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scanner.ViewModels
{
    public class MainViewModel : BaseViewModel
    {

        public DelegateCommand StartScanCommand { get; private set; }
        private readonly IScanService _scanService;

        public MainViewModel(IScanService scanService)
        {

            StartScanCommand = new DelegateCommand(StartScan);

            _scanService = scanService;
            ScannedIpList = new() { };
          
        }

        public async void StartScan()
        {
            ScannedIpList = await _scanService.Scan(ScannedIpList, _ip, _startPort, _endPort);
        }

        public string _ip;
        public string Ip { get => _ip; set { SetProperty(ref _ip, value); } }


        public int _startPort;
        public int StartPort { get => _startPort; set { SetProperty(ref _startPort, value); } }


        public int _endPort;
        public int EndPort { get => _endPort; set { SetProperty(ref _endPort, value); } }


        public ObservableCollection<Scan> _scannedIpList;
        public ObservableCollection<Scan> ScannedIpList { get => _scannedIpList; set { SetProperty(ref _scannedIpList, value); } }

    }
}
