using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
namespace WakeDevice
{
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

            if  (!IPAddress.TryParse(mask, out IPAddress? parsedMask))
            {
                throw new ArgumentException("Invalid subnet mask has been specified.");
            }
            AddressMask = parsedMask;

            AddressPorts = ports;
        }
    }
}
