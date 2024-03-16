using System.CommandLine;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClTree : Command
{
    public ClTree(FMS application)
        : base("tree")
    {
        AddCommand(new ClGoTo(application));
        AddCommand(new ClList(application));
    }
}