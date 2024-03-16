using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Directory;

public interface IDirectory : IVisitable
{
    string AbsolutePath { get; }
    IEnumerable<IVisitable> Components { get; }
    bool Exists();
}