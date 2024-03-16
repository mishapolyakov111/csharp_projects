using Itmo.ObjectOrientedProgramming.Lab4.Comands;
using Itmo.ObjectOrientedProgramming.Lab4.File;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDelete : ICommand
{
    private const string UB = "File system is not connected";
    private const string FileNotExist = "File not found";

    private string _path;

    public FileDelete(string path)
    {
        _path = path;
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

        context.FileSystem.DeleteFile(file);
        return new Success($"The file {file.Name} has been successfully deleted");
    }
}