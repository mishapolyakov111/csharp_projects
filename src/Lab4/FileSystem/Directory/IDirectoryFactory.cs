namespace Itmo.ObjectOrientedProgramming.Lab4.Directory;

public interface IDirectoryFactory
{
    IDirectory Create(string relativePath, string workingDirectory);
    IDirectory Create(string absolutePath);
}