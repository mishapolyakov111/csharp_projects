using System;
using System.CommandLine;
using System.Text;
using Itmo.ObjectOrientedProgramming.Lab4.CLCommands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public static class Program
{
    public static void Main()
    {
        var application = new FMS();

        var modeSelector = new LocalFileSystemSelector();
        var rootCommand = new RootCommand(description: "My FileSystem Application");

        rootCommand.AddCommand(new ClConnect(application, modeSelector));
        rootCommand.AddCommand(new CLDisconect(application));
        rootCommand.AddCommand(new ClTree(application));
        rootCommand.AddCommand(new ClFile(application));

        Console.OutputEncoding = Encoding.Unicode;

        Console.WriteLine(Environment.CurrentDirectory);
        while (true)
        {
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) continue;

            rootCommand.Invoke(input.Split(' '));
            if (!application.IsWorking) return;
        }
    }
}