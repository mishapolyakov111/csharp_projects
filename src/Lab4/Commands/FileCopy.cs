using Itmo.ObjectOrientedProgramming.Lab4.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.File;
using Itmo.ObjectOrientedProgramming.Lab4.Result;
using ICommand = Itmo.ObjectOrientedProgramming.Lab4.Comands.ICommand;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileCopy : ICommand
{
    private const string UB = "File system is not connected";
    private const string FileNotExist = "File not found";
    private const string DirectoryNotExist = "Directory not found";

    private string _source;
    private string _destination;

    public FileCopy(string source, string destination)
    {
        _source = source;
        _destination = destination;
    }

    public ExecutionResult Execute(Context? context)
    {
        if (context is null) return new Failure(UB);
        if (context.FileSystem is null) return new Failure(UB);
        if (context.WorkingDirectory is null) return new Failure(UB);

        IFile file = context.FileSystem.FileFactory.Create(_source, context.WorkingDirectory.AbsolutePath);

        if (!file.Exists)
        {
            return new Failure(FileNotExist);
        }

        IDirectory directory =
            context.FileSystem.DirectoryFactory.Create(_destination, context.WorkingDirectory.AbsolutePath);

        if (!directory.Exists())
        {
            return new Failure(DirectoryNotExist);
        }

        context.FileSystem.CopyFile(file, directory);
        return new Success($"The file {file.Name} has been successfully copied to the directory {directory.Name}");
    }
}