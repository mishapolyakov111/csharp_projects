using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Waclass : AbstractSpaceship
{
    public Waclass()
        : base(new MediumShell(), new LightDeflector(), new IEngine[] { new ImpulseEngineE(), new GammaJumpEngine() })
    {
    }
}