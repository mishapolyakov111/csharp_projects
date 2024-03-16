using Itmo.ObjectOrientedProgramming.Lab4.Comands;
using Itmo.ObjectOrientedProgramming.Lab4.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeGoTo : ICommand
{
    private const string ConnectionError = "Can't connect to this address";
    private const string Ub = "File system isn't connected";
    private const string Success = "Tree successfully switched to ";

    private readonly string _path;

    public TreeGoTo(string path)
    {
        _path = path;
    }

    public ExecutionResult Execute(Context? context)
    {
        if (context is null) return new Failure(Ub);
        if (context.FileSystem is null) return new Failure(Ub);
        if (context.WorkingDirectory is null) return new Failure(Ub);

        IDirectory directory = context.FileSystem.DirectoryFactory.Create(_path, context.WorkingDirectory.AbsolutePath);
        if (!directory.Exists())
        {
            return new Failure(ConnectionError);
        }

        context.WorkingDirectory = directory;
        return new Success(Success + directory.AbsolutePath);
    }
}