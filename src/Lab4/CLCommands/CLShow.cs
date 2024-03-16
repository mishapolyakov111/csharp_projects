using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClShow : Command
{
    private Argument<string> _pathArgument = new("Path", "Path to file");
    private Option<WritingMode> _modeOprion = new("-m", "Use it to choose where to output the contents of the file");

    public ClShow(FMS application)
        : base(
            name: "show",
            description: "Use to see file content")
    {
        AddArgument(_pathArgument);
        AddOption(_modeOprion);
        this.SetHandler(
            command => application.ExecuteCommand(command),
            new FileShowBinder(_pathArgument, _modeOprion));
    }
}