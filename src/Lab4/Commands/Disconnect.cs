using Itmo.ObjectOrientedProgramming.Lab4.Comands;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class Disconnect : ICommand
{
    private const string UB = "File system is not connected";
    private readonly FMS _app;

    public Disconnect(FMS app)
    {
        this._app = app;
    }

    public ExecutionResult Execute(Context? context)
    {
        if (context is null) return new Failure(UB);
        if (context.FileSystem is null) return new Failure(UB);
        if (context.WorkingDirectory is null) return new Failure(UB);

        context.WorkingDirectory = null;
        context.FileSystem = null;

        _app.Stop();
        return new Success("The program has been stopped successfully");
    }
}