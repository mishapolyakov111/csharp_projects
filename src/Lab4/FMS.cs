using System;
using Itmo.ObjectOrientedProgramming.Lab4.Comands;
using Itmo.ObjectOrientedProgramming.Lab4.Logger;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FMS
{
    private readonly Context _context = new();
    private readonly ILogger _logger;

    public FMS()
    {
        _logger = new ConsoleLogger();
        IsWorking = true;
    }

    public FMS(ILogger logger)
    {
        _logger = logger;
    }

    public bool IsWorking { get; private set; }

    public void ExecuteCommand(ICommand command)
    {
        ArgumentNullException.ThrowIfNull(command);
        _logger.Log(command.Execute(_context));
    }

    public void Stop()
    {
        IsWorking = false;
    }
}