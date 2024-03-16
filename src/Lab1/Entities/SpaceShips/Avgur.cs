using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Avgur : AbstractSpaceship
{
    public Avgur()
        : base(
            new HeavyShell(),
            new HeavyDeflector(),
            new IEngine[] { new ImpulseEngineE(), new AlphaJumpEngine() })
    {
    }
}