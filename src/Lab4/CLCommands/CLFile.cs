using System.CommandLine;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class ClFile : Command
{
    public ClFile(FMS application)
        : base("file", string.Empty)
    {
        AddCommand(new ClShow(application));
        AddCommand(new ClMove(application));
        AddCommand(new ClCopy(application));
        AddCommand(new ClDelete(application));
        AddCommand(new ClRename(application));
    }
}