using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.File;

public interface IFile : IVisitable
{
    public string AbsolutePath { get; }
    bool Exists { get; }
}