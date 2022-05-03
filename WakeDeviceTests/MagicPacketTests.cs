using Microsoft.VisualStudio.TestTools.UnitTesting;
using WakeDevice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace WakeDevice.Tests
{
    [TestClass()]
    public class MagicPacketTests
    {
        [TestMethod()]
        [Timeout(1000)]
        public void MagicPacket_Verify_Generated_Payload()
        {
            PhysicalAddress Mac = PhysicalAddress.Parse("DD:F1:A1:A3:3E:C9");
            
            //Proper byte array generated for input mac
            byte[] ExpectedPayload = new byte[] { 255, 255, 255, 255, 255, 255,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                221, 241, 161, 163, 62, 201, 221, 241, 161, 163, 62, 201,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
                0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            MagicPacket Packet = new(Mac);
            byte[] ActualPayload = Packet.Payload;


            Assert.AreEqual(320, ActualPayload.Length);

            byte[] Difference = new byte[320];
            for(int i = 0; i < 320; i++)
            {
                Difference[i] = (byte)(ExpectedPayload[i] - ActualPayload[i]);
            }

            foreach(var value in Difference)
            {
                Assert.AreEqual(0 , value);
            }
            
        }
    }
}