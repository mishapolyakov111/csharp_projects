using Itmo.ObjectOrientedProgramming.Lab4.Comands;
using Itmo.ObjectOrientedProgramming.Lab4.File;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRename : ICommand
{
    private const string UB = "File system is not connected";
    private const string FileNotExist = "File not found";

    private string _path;
    private string _newName;

    public FileRename(string path, string newName)
    {
        _path = path;
        _newName = newName;
    }

    public ExecutionResult Execute(Context? context)
    {
        if (context is null) return new Failure(UB);
        if (context.FileSystem is null) return new Failure(UB);
        if (context.WorkingDirectory is null) return new Failure(UB);

        IFile file = context.FileSystem.FileFactory.Create(_path, context.WorkingDirectory.AbsolutePath);

        if (!file.Exists)
        {
            return new Failure(FileNotExist);
        }

        context.FileSystem.RenameFile(file, _newName);
        return new Success($"The file {file.Name} was successfully renamed to {_newName}");
    }
}