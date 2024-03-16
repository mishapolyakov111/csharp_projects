using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protectors.Deflectors;

public class PhotonicDeflector : DeflectorModification
{
    private const int NumberOfReflectedFlashes = 3;
    private int _reflectedFlashes;

    public PhotonicDeflector(Deflector deflector)
        : base(deflector)
    {
        _reflectedFlashes = NumberOfReflectedFlashes;
    }

    public override CollisionResult Collision(IObstacle obstacle)
    {
        if (obstacle is PhotonicFlash)
        {
            _reflectedFlashes -= 1;
            if (_reflectedFlashes < 0)
            {
                return new CrewFlashed();
            }

            return new Success();
        }

        return Deflector.Collision(obstacle);
    }
}