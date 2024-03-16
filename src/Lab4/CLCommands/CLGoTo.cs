using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClGoTo : Command
{
    private readonly Argument<string> _pathArgument = new("Path");

    public ClGoTo(FMS application)
        : base(
            name: "goto",
            description: "Use to to switch file system address")
    {
        AddArgument(_pathArgument);
        this.SetHandler(
            command => application.ExecuteCommand(command),
            new TreeGoToBinder(_pathArgument));
    }
}