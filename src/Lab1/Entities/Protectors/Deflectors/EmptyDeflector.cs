namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protectors.Deflectors;

public class EmptyDeflector : Deflector
{
    private const int EmptyDeflectorHp = 0;

    public EmptyDeflector()
        : base(EmptyDeflectorHp)
    {
    }

    public EmptyDeflector(Deflector deflector)
        : base(deflector)
    {
    }
}