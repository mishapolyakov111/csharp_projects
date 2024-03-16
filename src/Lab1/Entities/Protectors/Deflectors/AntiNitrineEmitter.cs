using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Protectors.Deflectors;

public class AntiNitrineEmitter : DeflectorModification
{
    public AntiNitrineEmitter(Deflector deflector)
        : base(deflector)
    {
    }

    public override CollisionResult Collision(IObstacle obstacle)
    {
        if (obstacle is INitrineSpaceObstacle)
        {
            return new Success();
        }

        return Deflector.Collision(obstacle);
    }
}