﻿using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Windows;

namespace SerialCommJSON.Models
{
    public class SerialPortWrapper : BindableBase
    {
        private SerialPort m_SerialPort = null;

        private ObservableCollection<string> m_PortList = new();
        public ObservableCollection<string> PortList
        {
            get { return m_PortList; }
            set { SetProperty( ref m_PortList, value ); }
        }

        private string m_SelectedPort;
        public string SelectedPort
        {
            get { return m_SelectedPort; }
            set { SetProperty( ref m_SelectedPort, value ); }
        }

        public SerialPortWrapper( )
        {
            m_SerialPort = new SerialPort( );
            m_SerialPort.BaudRate = 9600;
            m_SerialPort.DataBits = 8;
            m_SerialPort.Parity = Parity.None;
            m_SerialPort.Encoding = Encoding.UTF8;
            m_SerialPort.WriteTimeout = 5000;
            m_SerialPort.ReadTimeout = 5000;

            m_SerialPort.DataReceived += ( sender, e ) =>
            {
                try
                {
                    Human human;
                    string message = m_SerialPort.ReadLine();
                    human = JsonSerializer.Deserialize<Human>( message );

                } catch ( Exception ex )
                {
                    MessageBox.Show( ex.Message );
                }
            };

            foreach ( var port in SerialPort.GetPortNames( ) )
            {
                PortList.Add( port );
            }
            SelectedPort = PortList.FirstOrDefault( );
        }

        public void Connect( )
        {
            try
            {
                m_SerialPort.PortName = SelectedPort;
                m_SerialPort.Open( );
            } catch ( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
        }

        public void Disconnect( )
        {
            try
            {
                m_SerialPort.Close( );
            } catch ( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
        }
    }
}
