using System;
using System.CommandLine;
using System.CommandLine.Binding;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemSelector;

namespace Itmo.ObjectOrientedProgramming.Lab4.CLCommandBinders;

internal class ConnectBinder : BinderBase<Connect>
{
    private readonly ISelector _selector;
    private readonly Option<FileSystemMode> _modeOption;
    private readonly Argument<string> _addressArgument;

    public ConnectBinder(Option<FileSystemMode> modeOption, Argument<string> addressArgument, ISelector selector)
    {
        _modeOption = modeOption;
        _addressArgument = addressArgument;
        _selector = selector;
    }

    protected override Connect GetBoundValue(BindingContext bindingContext)
    {
        ArgumentNullException.ThrowIfNull(bindingContext);
        return new Connect(
            fileSystemMode: bindingContext.ParseResult.GetValueForOption(_modeOption),
            selector: _selector,
            address: bindingContext.ParseResult.GetValueForArgument(_addressArgument));
    }
}