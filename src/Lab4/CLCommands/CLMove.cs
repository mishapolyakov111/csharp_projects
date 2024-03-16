using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClMove : Command
{
    private readonly Argument<string> _sourceArgument = new Argument<string>("source");
    private readonly Argument<string> _destinationArgument = new Argument<string>("destination");

    public ClMove(FMS application)
        : base("move", "Use to move file")
    {
        Add(_sourceArgument);
        Add(_destinationArgument);
        this.SetHandler(
            command => application.ExecuteCommand(command),
            new FileMoveBinder(sourceArgument: _sourceArgument, destinationArgument: _destinationArgument));
    }
}