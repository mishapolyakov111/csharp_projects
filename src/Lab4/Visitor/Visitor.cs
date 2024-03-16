using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.File;

namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public class Visitor : IVisitor<IDirectory>, IVisitor<IFile>
{
    private int _depth;
    private int _maxDepth;
    private string _tree = string.Empty;

    public Visitor(int maxDepth = 0)
    {
        _maxDepth = maxDepth;
    }

    public string ResultList => _tree;

    public void Visit(IDirectory component)
    {
        ArgumentNullException.ThrowIfNull(component);
        string s = string.Concat(Enumerable.Repeat('\t', _depth));
        _tree += s + "\ud83d\udcc2" + component.Name + '\n';
        if (_depth >= _maxDepth) return;

        _depth += 1;

        foreach (IVisitable c in component.Components)
        {
            c.Accept(this);
        }

        _depth -= 1;
    }

    public void Visit(IFile component)
    {
        ArgumentNullException.ThrowIfNull(component);
        string s = string.Concat(Enumerable.Repeat('\t', _depth));
        _tree += s + "\ud83d\udcc4" + component.Name + '\n';
    }
}