# WakeDevice

## 📖About WakeDevice
WakeDevice is a cross-platform .NET based console/terminal app enabling
user to send Wake-On-LAN Magic Packets over the network. Entire program is
written in C# and utilizes .NET 6.

[More on Wake-On-LAN standard](https://en.wikipedia.org/wiki/Wake-on-LAN)

---

## 🚀Getting started


### Building WakeDevice
Build should be performed with [.NET SDK version 6.0](https://dotnet.microsoft.com/en-us/download)


#### Windows

To build project it is preferable to use Microsoft Visual Studio as it is
default IDE for .NET. Alternatively you may use Miscorosft Visual Studio Code
with C# extension installed. If you prefer using dotnet CLI, refer to
[.NET documentation](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-build).

---

### 🔥Using WakeDevice command

---

#### Linux Terminal

Having [command path set](https://opensource.com/article/17/6/set-path-linux),
simply type `WakeDevice <MAC address> <IP address>` to send magic packet using
default ports (7,9). If command path is not set, `cd` to folder containing
WakeDevice file and type `./WakeDevice <MAC address> <IP address>`.

To specify other ports append command with `-p port_number1 port_number2`
By default WakeDevice will send magic packet 5 times for each port.
To specify number of repetitions other than 5, append command with
`-r number_of_repetitons`.


#### Windows Command Prompt

Having [command path set](https://docs.microsoft.com/en-us/windows-server/administration/windows-commands/path),
simply type WakeDevice <MAC address> <IP address> to send magic packet
using default ports (7,9). If command path is not set, `cd` to folder
containing `.exe` file and type `WakeDevice.exe <MAC address> <IP address>`

To specify other ports append command with -p port_number1 port_number2 ...
By default WakeDevice will send magic packet 5 times for each port. \
To specify number of repetitions other than 5, append command with -r number_of_repetitons
