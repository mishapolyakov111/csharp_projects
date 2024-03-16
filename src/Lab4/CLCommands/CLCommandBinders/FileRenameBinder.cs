using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

public class FileRenameBinder : BinderBase<FileRename>
{
    private readonly Argument<string> _pathArgument;
    private readonly Argument<string> _nameArgument;

    public FileRenameBinder(Argument<string> pathArgument, Argument<string> nameArgument)
    {
        _pathArgument = pathArgument;
        _nameArgument = nameArgument;
    }

    protected override FileRename GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileRename(
            bindingContext.ParseResult.GetValueForArgument(_pathArgument),
            bindingContext.ParseResult.GetValueForArgument(_nameArgument));
    }
}