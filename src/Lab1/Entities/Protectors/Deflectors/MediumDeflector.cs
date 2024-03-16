namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public class MediumDeflector : Deflector
{
    private const int MediumDeflectorHp = 250;

    public MediumDeflector()
        : base(MediumDeflectorHp)
    {
    }
}