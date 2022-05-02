using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace WakeDevice
{
    /// <summary>
    /// Represents target endpoint network data
    /// </summary>
    internal class TargetEndpoint
    {
        #region Fields
        private IPAddress _addressIP;
        private IPAddress _addressMask = IPAddress.Parse("255.255.255.0");
        private List<uint> _addressPorts = new() { 7, 9 };
        private PhysicalAddress _mac;
        #endregion;

        #region Properties
        public IPAddress AddressIP
        {
            get
            {
                return _addressIP;
            }
            private set
            {
                if (value != null)
                {
                    _addressIP = value;
                }
            }
        }
        public IPAddress? AddressMask
        {
            get
            {
                return _addressMask;
            }
            private set
            {
                if (value != null)
                {
                    _addressMask = value;
                }
            }
        }
        public List<uint>? AddressPorts
        {
            get
            {
                return _addressPorts;
            }
            private set
            {
                if (value != null)
                {
                    _addressPorts = value;
                }
            }
        }
        public PhysicalAddress Mac
        {
            get
            {
                return _mac;
            }
            private set
            {
                if (value != null)
                {
                    _mac = value;
                }
            }
        }
        #endregion;

        /// <summary>
        /// Initializes a new instance of <see cref="TargetEndpoint"/>
        /// </summary>
        /// <param name="mac"></param>
        /// <param name="ip"></param>
        /// <param name="mask"></param>
        /// <param name="ports"></param>
        /// <exception cref="ArgumentException"></exception>
        public TargetEndpoint(string mac, string ip, string? mask, List<uint>? ports)
        {

            if (!PhysicalAddress.TryParse(mac, out PhysicalAddress? parsedMac))
            {
                throw new ArgumentException("Invalid MAC address has been specified.");
            }
            Mac = parsedMac;

            if (!IPAddress.TryParse(ip, out IPAddress? parsedIp))
            {
                throw new ArgumentException("Invalid IP address has been specified.");
            }
            AddressIP = parsedIp;

            IPAddress? parsedMask = null;
            if (mask != null && !IPAddress.TryParse(mask, out parsedMask))
            {
                throw new ArgumentException("Invalid subnet mask has been specified.");
            }
            AddressMask = parsedMask;

            AddressPorts = ports;
        }
        
        /// <summary>
        /// Wakes target device using Wake On LAN mechanism
        /// </summary>
        /// <param name="packet"></param>
        /// <param name="repetitions"></param>
        public void Wake(MagicPacket packet, uint repetitions = 5)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            foreach (var port in AddressPorts)
            {
                IPAddress DestinationAddress = GetBroadcastAddress();
                IPEndPoint EndPoint = new(DestinationAddress, (int)port);

                for (int i = 0; i < repetitions; i++)
                {
                    // Send data to destination host
                    s.SendTo(packet.Payload, EndPoint);
                }

                Console.WriteLine();
                Console.WriteLine($"Magic packets ({repetitions}) sent to: {DestinationAddress}:{port}");
            }
            s.Dispose();
        }

        /// <summary>
        /// Generates broadcast address based on provided subnet mask
        /// </summary>
        /// <returns>IP address to send packets to</returns>
        private IPAddress GetBroadcastAddress()
        {
            byte[] broadcastIPBytes = new byte[4];
            byte[] hostBytes = _addressIP.GetAddressBytes();
            byte[] maskBytes = _addressMask.GetAddressBytes();
            for (int i = 0; i < 4; i++)
            {
                broadcastIPBytes[i] = (byte)(hostBytes[i] | (byte)~maskBytes[i]);
            }
            return new IPAddress(broadcastIPBytes);
        }
    }
}
