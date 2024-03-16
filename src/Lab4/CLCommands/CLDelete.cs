using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClDelete : Command
{
    private readonly Argument<string> _path = new("Path", "Path to file");

    public ClDelete(FMS application)
        : base("delete", "Use to delete file")
    {
        AddArgument(_path);
        this.SetHandler(
            command => application.ExecuteCommand(command),
            new FileDeleteBinder(_path));
    }
}