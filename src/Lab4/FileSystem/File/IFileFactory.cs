namespace Itmo.ObjectOrientedProgramming.Lab4.File;

public interface IFileFactory
{
    IFile Create(string relativePath, string workingDirectory);
    IFile Create(string absolutePath);
}