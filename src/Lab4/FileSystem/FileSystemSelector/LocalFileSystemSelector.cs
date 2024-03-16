using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;

public class LocalFileSystemSelector : SelectorBase
{
    public override IFileSystem? SelectFileSystem(FileSystemMode fileSystemMode)
    {
        if (fileSystemMode == FileSystemMode.Local)
        {
            return new LocalFileSystem();
        }

        Next?.SelectFileSystem(fileSystemMode);
        return null;
    }
}