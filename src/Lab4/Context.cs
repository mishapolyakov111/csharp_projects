using Itmo.ObjectOrientedProgramming.Lab4.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Context
{
    public Context()
    {
        FileSystem = null;
        WorkingDirectory = null;
    }

    public Context(IFileSystem fileSystem, IDirectory workingDirectory)
    {
        FileSystem = fileSystem;
        WorkingDirectory = workingDirectory;
    }

    public IFileSystem? FileSystem { get; set; }
    public IDirectory? WorkingDirectory { get; set; }
}