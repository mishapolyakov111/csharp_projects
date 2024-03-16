using System.CommandLine;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class TestRootCommand : RootCommand
{
    public TestRootCommand(FMS application)
        : base(description: "My FileSystem Application")
    {
        var modeSelector = new LocalFileSystemSelector();

        AddCommand(new ClConnect(application, modeSelector));
        AddCommand(new CLDisconect(application));
        AddCommand(new ClTree(application));
        AddCommand(new ClFile(application));
    }
}