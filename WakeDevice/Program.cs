using WakeDevice;

try
{
    Parsing Command = new(args);
    if (Command.AddressMac == null || Command.AddressIp == null)
    {
        return;
    }
    TargetEndpoint Endpoint = new(Command.AddressMac, Command.AddressIp, Command.SubnetMask, Command.Ports);
    MagicPacket Packet = new(Endpoint.Mac);
}
catch (Exception ex)
{
    Console.WriteLine("Fatal error occured.");

#if DEBUG 
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
#endif

    return;
}


//Perform device wake