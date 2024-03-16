using Itmo.ObjectOrientedProgramming.Lab4.File;
using Itmo.ObjectOrientedProgramming.Lab4.Result;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Comands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileShow : ICommand
{
    private const string UB = "File system is not connected";
    private const string BadWritingMode = "Non-existent writing mode";
    private const string FileNotExist = "File not found";

    private WritingMode _mode;
    private string _path;
    private IPrinter? _printer;

    public FileShow(WritingMode mode, string path)
    {
        _mode = mode;
        _path = path;
    }

    public ExecutionResult Execute(Context? context)
    {
        if (context is null) return new Failure(UB);
        if (context.FileSystem is null) return new Failure(UB);
        if (context.WorkingDirectory is null) return new Failure(UB);

        // да-да, завязался, ленб развязывать
        if (_mode == WritingMode.Console)
        {
            _printer = new ConsolePrinter();
        }
        else
        {
            return new Failure(BadWritingMode);
        }

        IFile file = context.FileSystem.FileFactory.Create(_path, context.WorkingDirectory.AbsolutePath);

        if (!file.Exists)
        {
            return new Failure(FileNotExist);
        }

        _printer.Print(context.FileSystem.ReadFile(file));
        return new Success(string.Empty);
    }
}