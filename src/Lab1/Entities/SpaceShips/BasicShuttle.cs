using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protectors.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class BasicShuttle : AbstractSpaceship
{
    public BasicShuttle()
        : base(new LightShell(), new PhotonicDeflector(new HeavyDeflector()), new[] { new ImpulseEngineC() })
    {
    }
}