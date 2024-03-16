using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

public class FileShowBinder : BinderBase<FileShow>
{
    private readonly Option<WritingMode> _modeOption;
    private readonly Argument<string> _pathArgument;

    public FileShowBinder(Argument<string> pathArgument, Option<WritingMode> modeOption)
    {
        _pathArgument = pathArgument;
        _modeOption = modeOption;
    }

    protected override FileShow GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileShow(
            mode: bindingContext.ParseResult.GetValueForOption(_modeOption),
            path: bindingContext.ParseResult.GetValueForArgument(_pathArgument));
    }
}