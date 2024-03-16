using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClRename : Command
{
    private readonly Argument<string> _pathArgument = new("Path");
    private readonly Argument<string> _nameArgument = new("Name");

    public ClRename(FMS application)
        : base("rename", "Use to rename file")
    {
        AddArgument(_pathArgument);
        AddArgument(_nameArgument);
        this.SetHandler(
            command => application.ExecuteCommand(command),
            new FileRenameBinder(_pathArgument, _nameArgument));
    }
}