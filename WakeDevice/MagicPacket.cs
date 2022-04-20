using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;

namespace WakeDevice
{
    internal class MagicPacket
    {
        private byte[] _payload;

        public byte[] Payload
        {
            get
            {
                return _payload;
            }
            private set
            {
                    _payload = value; 
            }
        }

        MagicPacket(PhysicalAddress mac)
        {
            byte[] GeneratedPayload = new byte[320];
            byte[] Magic = { byte.Parse("255"), byte.Parse("255"), byte.Parse("255"),
                byte.Parse("255"), byte.Parse("255"), byte.Parse("255") };
            byte[] MacBytes = mac.GetAddressBytes();

            System.Buffer.BlockCopy(Magic, 0, GeneratedPayload, 0, 6);
            for (int i = 1; i <= 16; i++)
            {
                System.Buffer.BlockCopy(MacBytes, 0, GeneratedPayload, 6 * i, 6);
            }

            Payload = GeneratedPayload;
        }
    }
}
