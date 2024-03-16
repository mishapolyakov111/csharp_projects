using Itmo.ObjectOrientedProgramming.Lab4.Comands;
using Itmo.ObjectOrientedProgramming.Lab4.Result;
using Itmo.ObjectOrientedProgramming.Lab4.Visitor;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class TreeList : ICommand
{
    private const string Ub = "Undefined behaviour";

    private IVisitor _visitor;

    public TreeList(int depth)
    {
        _visitor = new Visitor.Visitor(depth);
    }

    public ExecutionResult Execute(Context? context)
    {
        if (context is null) return new Failure(Ub);
        if (context.FileSystem is null) return new Failure(Ub);
        if (context.WorkingDirectory is null) return new Failure(Ub);

        context.WorkingDirectory.Accept(_visitor);
        return new Success(_visitor.ResultList);
    }
}