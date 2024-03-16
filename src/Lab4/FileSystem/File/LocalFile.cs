using System.IO;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.File;

public class LocalFile : IFile
{
    public LocalFile(string absolutePath)
    {
        AbsolutePath = absolutePath;
        var fileInfo = new FileInfo(AbsolutePath);
        Name = fileInfo.Name;
    }

    public LocalFile(string relativePath, string workingDirectory)
    {
        AbsolutePath = Path.GetFullPath(relativePath, workingDirectory);
        var fileInfo = new FileInfo(AbsolutePath);
        Name = fileInfo.Name;
    }

    public string AbsolutePath { get; }

    public bool Exists => new FileInfo(AbsolutePath).Exists;

    public string Name { get; }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<IFile> v)
            v.Visit(this);
    }
}