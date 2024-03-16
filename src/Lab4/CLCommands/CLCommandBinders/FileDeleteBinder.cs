using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

public class FileDeleteBinder : BinderBase<FileDelete>
{
    private readonly Argument<string> _pathArgument;

    public FileDeleteBinder(Argument<string> pathArgument)
    {
        _pathArgument = pathArgument;
    }

    protected override FileDelete GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileDelete(
            bindingContext.ParseResult.GetValueForArgument(_pathArgument));
    }
}