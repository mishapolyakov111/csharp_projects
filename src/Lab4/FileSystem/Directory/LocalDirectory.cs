using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.File;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Directory;

public class LocalDirectory : IDirectory
{
    public LocalDirectory(string relativePath, string workingDirectory)
    {
        AbsolutePath = Path.GetFullPath(relativePath, workingDirectory);
        var directoryInfo = new DirectoryInfo(AbsolutePath);
        Name = directoryInfo.Name;
    }

    public LocalDirectory(string absolutePath)
    {
        var directoryInfo = new DirectoryInfo(absolutePath);
        AbsolutePath = absolutePath;
        Name = directoryInfo.Name;
    }

    public string Name { get; }

    public string AbsolutePath { get; }

    public IEnumerable<IVisitable> Components
    {
        get
        {
            var directoryInfo = new DirectoryInfo(AbsolutePath);
            IEnumerable<IVisitable> first = directoryInfo.GetFiles()
                .Select(x => new LocalFile(x.FullName));
            IEnumerable<IVisitable> second = directoryInfo.GetDirectories()
                .Select(x => new LocalDirectory(x.FullName));
            return first.Concat(second);
        }
    }

    public bool Exists()
    {
        var directoryInfo = new DirectoryInfo(AbsolutePath);
        return directoryInfo.Exists;
    }

    public void Accept(IVisitor visitor)
    {
        if (visitor is IVisitor<IDirectory> v)
            v.Visit(this);
    }
}