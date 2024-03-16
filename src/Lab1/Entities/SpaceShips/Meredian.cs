using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protectors.Deflectors;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Meredian : AbstractSpaceship
{
    public Meredian()
        : base(
            new MediumShell(),
            new AntiNitrineEmitter(new MediumDeflector()),
            new IEngine[] { new ImpulseEngineE() })
    {
    }
}