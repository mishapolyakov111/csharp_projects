namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;

public abstract class DeflectorModification : Deflector
{
    protected DeflectorModification(Deflector deflector)
        : base(deflector)
    {
        Deflector = deflector;
    }

    public Deflector Deflector { get; protected set; }
}