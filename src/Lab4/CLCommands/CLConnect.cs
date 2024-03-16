using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClConnect : Command
{
    private readonly Argument<string> _addressArgument = new(
        name: "Address",
        description: "Address of connection to FileSystem");

    private readonly Option<FileSystemMode> _modeOption = new(
        name: "-m",
        description: "Mode of File System");

    public ClConnect(FMS application, ISelector selector)
        : base("connect", "Use for connection to File System")
    {
        AddOption(_modeOption);
        AddArgument(_addressArgument);
        this.SetHandler(
            command => application?.ExecuteCommand(command),
            new ConnectBinder(_modeOption, _addressArgument,  selector));
    }
}