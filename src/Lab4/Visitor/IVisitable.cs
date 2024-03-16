namespace Itmo.ObjectOrientedProgramming.Lab4.Visitor;

public interface IVisitable
{
    string Name { get; }
    void Accept(IVisitor visitor);
}