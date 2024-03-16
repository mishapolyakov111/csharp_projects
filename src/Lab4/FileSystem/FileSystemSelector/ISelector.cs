using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;

public interface ISelector
{
    void AddNext(ISelector link);

    IFileSystem? SelectFileSystem(FileSystemMode fileSystemMode);
}