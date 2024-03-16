using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommands;

public class CLDisconect : Command
{
    public CLDisconect(FMS application)
        : base("disconnect", "Use to disconnect from file system and stop programme")
    {
        this.SetHandler(() => application.ExecuteCommand(new Disconnect(application)));
    }
}