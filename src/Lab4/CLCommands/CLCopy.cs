using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClCopy : Command
{
    private readonly Argument<string> _sourceArgument = new Argument<string>("source");
    private readonly Argument<string> _destinationArgument = new Argument<string>("destination");

    public ClCopy(FMS application)
        : base("copy", "Use to copy file")
    {
        Add(_sourceArgument);
        Add(_destinationArgument);
        this.SetHandler(
            command => application.ExecuteCommand(command),
            new FileCopyBinder(sourceArgument: _sourceArgument, destinationArgument: _destinationArgument));
    }
}