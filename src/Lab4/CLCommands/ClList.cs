using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClList : Command
{
    private readonly Option<int> _depthOption = new(
        name: "-d",
        description: "Depth of tree list",
        getDefaultValue: () => 0);

    public ClList(FMS application)
        : base(
            name: "list",
            description: "Use to see file system tree")
    {
        AddOption(_depthOption);
        this.SetHandler(
            command => application.ExecuteCommand(command),
            new TreeListBinder(_depthOption));
    }
}