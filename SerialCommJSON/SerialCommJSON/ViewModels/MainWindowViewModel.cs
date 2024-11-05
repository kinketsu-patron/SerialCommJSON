using Prism.Commands;
using Prism.Mvvm;
using SerialCommJSON.Models;
using System.Collections.ObjectModel;

namespace SerialCommJSON.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private SerialPortWrapper m_SerialPortWrapper = null;

        public DelegateCommand ConnectCommand { get; }
        public DelegateCommand DisconnectCommand { get; }

        public ObservableCollection<string> PortList
        {
            get { return m_SerialPortWrapper.PortList; }
            set { m_SerialPortWrapper.PortList = value; }
        }

        public string SelectedPort
        {
            get { return m_SerialPortWrapper.SelectedPort; }
            set { m_SerialPortWrapper.SelectedPort = value; }
        }

        public MainWindowViewModel( )
        {
            m_SerialPortWrapper = new SerialPortWrapper( );

            m_SerialPortWrapper.PropertyChanged += ( sender, e ) => RaisePropertyChanged( e.PropertyName );

            ConnectCommand = new DelegateCommand( Connect_Click );
            DisconnectCommand = new DelegateCommand( Disconnect_Click );
        }

        private void Connect_Click( )
        {
            m_SerialPortWrapper.Connect( );
        }

        private void Disconnect_Click( )
        {
            m_SerialPortWrapper.Disconnect( );
        }
    }
}
