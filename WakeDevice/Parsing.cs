using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace WakeDevice
{
    internal class Parsing
    {
        private string? _addressMac;
        private string? _addressIp;
        private List<uint>? _ports;
        private string? _subnetMask;
        private uint? _repetitions;

        public string? AddressMac
        {
            get
            {
                return _addressMac;
            }
            private set
            {
                _addressMac = value;
            }
        }
        public string? AddressIp
        {
            get
            {
                return _addressIp;
            }
            private set
            {
                _addressIp = value;
            }
        }
        public List<uint>? Ports
        {
            get
            {
                return _ports;
            }
            private set
            {
                if(value != null && value.Count != 0)
                {
                    _ports = value;
                }
            }
        }
        public string? SubnetMask
        {
            get
            {
                return _subnetMask;
            }
            private set
            {
                if(value != null)
                {
                    _subnetMask = value;
                }
            }
        }
        public uint? Repetitions
        {
            get
            {
                return _repetitions;
            }
            private set
            {   
                if(value != null && value > 0)
                {
                    _repetitions = value;
                }        
            }
        }

        public Parsing(string[] CommandLineArguments)
        {
            ParseInput(CommandLineArguments);
        }

        public void ParseInput(string[] args)
        {
            var result = Parser.Default.ParseArguments<InputArguments>(args)
            .WithParsed(options =>
            {

                if (!AreAllElementsUnique<IEnumerable>(options.Ports))
                {
                    throw new ArgumentException("One of the ports has been specified more than once.");
                }

                AddressIp = options.AddressIP;
                AddressMac = options.AddressMac;
                SubnetMask = options.SubnetMask;
                Repetitions = options.Repetitions;
                
                if(options.Ports != null)
                {
                    Ports = options.Ports.ToList();
                }
            });
        }

        private static bool AreAllElementsUnique<IEnumerable>(IEnumerable<uint> ?Collection)
        {
            if(Collection == null)
            {
                return true;
            }
           
            if (!Collection.GroupBy(x => x).All(g => g.Count() == 1))
            {
                return false;
            }
            return true;
        }
    }

    internal class InputArguments
    {
        [Value(index: 0, Required = true, HelpText = "Target MAC Address.", MetaName = "MAC Address")]
        public string? AddressMac { get; set; }

        [Value(index: 1, Required = true, HelpText = "Target IP Address.", MetaName = "IP Address")]
        public string? AddressIP { get; set; }

        [Option('m', Required = false, HelpText = "Target IP address subnet mask.")]
        public string? SubnetMask { get; set; }

        [Option('p', Required = false, HelpText = "Ports to send magic packets to.")]
        public IEnumerable<uint>? Ports { get; set; }

        [Option('r', Required = false, HelpText = "Number of packets to send for each port.")]
        public uint? Repetitions { get; set; }
    }
}
