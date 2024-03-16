using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

public class TreeListBinder : BinderBase<TreeList>
{
    private readonly Option<int> _depthOption;

    public TreeListBinder(Option<int> depthOption)
    {
        _depthOption = depthOption;
    }

    protected override TreeList GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new TreeList(
            depth: bindingContext.ParseResult.GetValueForOption(_depthOption));
    }
}