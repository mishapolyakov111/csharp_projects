using Itmo.ObjectOrientedProgramming.Lab4.FileSystem;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;

public abstract class SelectorBase : ISelector
{
    protected ISelector? Next { get; private set; }

    public void AddNext(ISelector link)
    {
        if (Next is null)
        {
            Next = link;
        }
        else
        {
            Next.AddNext(link);
        }
    }

    public abstract IFileSystem? SelectFileSystem(FileSystemMode fileSystemMode);
}
