namespace Itmo.ObjectOrientedProgramming.Lab4.Directory;

public class LocalDirectoryFactory : IDirectoryFactory
{
    public IDirectory Create(string relativePath, string workingDirectory)
    {
        return new LocalDirectory(relativePath, workingDirectory);
    }

    public IDirectory Create(string absolutePath)
    {
        return new LocalDirectory(absolutePath);
    }
}