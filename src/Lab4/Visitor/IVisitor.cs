namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IVisitor
{
    string ResultList { get; }
}

public interface IVisitor<T> : IVisitor
    where T : IVisitable
{
    void Visit(T component);
}