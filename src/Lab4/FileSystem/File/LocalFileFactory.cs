namespace Itmo.ObjectOrientedProgramming.Lab4.File;

public class LocalFileFactory : IFileFactory
{
    public IFile Create(string relativePath, string workingDirectory)
    {
        return new LocalFile(relativePath, workingDirectory);
    }

    public IFile Create(string absolutePath)
    {
        return new LocalFile(absolutePath);
    }
}