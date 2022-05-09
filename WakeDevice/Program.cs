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
    if (Command.Repetitions == null)
    {
        Endpoint.Wake(Packet.Payload);
        return;
    }
    Endpoint.Wake(Packet.Payload, Command.Repetitions);
}
catch (Exception ex)
{
    Console.WriteLine("Fatal error occured.");

#if DEBUG 
    Console.WriteLine();
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
#endif

    return;
}