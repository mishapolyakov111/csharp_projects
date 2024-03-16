using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Stella : AbstractSpaceship
{
    public Stella()
        : base(new LightShell(), new LightDeflector(), new IEngine[] { new ImpulseEngineC(), new OmegaJumpEngine() })
    {
    }
}