using Itmo.ObjectOrientedProgramming.Lab4.Comands;
using Itmo.ObjectOrientedProgramming.Lab4.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

internal class Connect : ICommand
{
    private const string ConnectionError = "Can't connect to this address";
    private const string UB = "File system is not connected";
    private const string WrongSystemType = "There is no file system of this type";
    private const string ConnectionSuccess = "Successfully connected to ";

    private readonly string _address;
    private readonly ISelector _selector;
    private readonly FileSystemMode _fileSystemMode;

    public Connect(string address, ISelector selector, FileSystemMode fileSystemMode)
    {
        _address = address;
        _selector = selector;
        _fileSystemMode = fileSystemMode;
    }

    public ExecutionResult Execute(Context? context)
    {
        if (context == null) return new Failure(UB);

        IFileSystem? fileSystem = _selector.SelectFileSystem(_fileSystemMode);
        if (fileSystem == null) return new Failure(WrongSystemType);

        IDirectory directory = fileSystem.DirectoryFactory.Create(_address);
        if (!directory.Exists())
        {
            return new Failure(ConnectionError);
        }

        context.FileSystem = fileSystem;
        context.WorkingDirectory = directory;
        return new Success(ConnectionSuccess + _address);
    }
}