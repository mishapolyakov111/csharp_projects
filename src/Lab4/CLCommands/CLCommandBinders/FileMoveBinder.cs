using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

public class FileMoveBinder : BinderBase<FileMove>
{
    private readonly Argument<string> _sourceArgument;
    private readonly Argument<string> _destinationArgument;

    public FileMoveBinder(Argument<string> destinationArgument, Argument<string> sourceArgument)
    {
        _destinationArgument = destinationArgument;
        _sourceArgument = sourceArgument;
    }

    protected override FileMove GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new FileMove(
            bindingContext.ParseResult.GetValueForArgument(_sourceArgument),
            bindingContext.ParseResult.GetValueForArgument(_destinationArgument));
    }
}