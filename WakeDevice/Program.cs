using WakeDevice;

try
{
    Parsing Command = new(args);
    if (Command.AddressMac == null || Command.AddressIp == null)
    {
        return;
    }

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


//Build target object
//Build magic packet
//Perform device wake