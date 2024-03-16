using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

public class TreeGoToBinder : BinderBase<TreeGoTo>
{
    private readonly Argument<string> _path;

    public TreeGoToBinder(Argument<string> path)
    {
        _path = path;
    }

    protected override TreeGoTo GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new TreeGoTo(
            bindingContext.ParseResult.GetValueForArgument(_path));
    }
}