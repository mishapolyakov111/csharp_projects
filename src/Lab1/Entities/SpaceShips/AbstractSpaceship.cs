using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Protectors.Deflectors;
using Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public abstract class AbstractSpaceship
{
    private Deflector _deflector;

    protected AbstractSpaceship(Shell shell, Deflector deflector, IReadOnlyCollection<IEngine> engines)
    {
        Shell = shell;
        _deflector = deflector;
        Engines = engines;
    }

    public Shell Shell { get; }
    public IReadOnlyCollection<IEngine> Engines { get; }

    public CollisionResult TryCollide(IObstacle? obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);
        CollisionResult result = _deflector.Collision(obstacle);

        return result.RemainingDamage == 0 ? result : Shell.AbsorbDamage(result.RemainingDamage);
    }

    public void SetPhotonicDeflector()
    {
        _deflector = new PhotonicDeflector(_deflector);
    }

    public void SetAntiNitrineEmitter()
    {
        _deflector = new AntiNitrineEmitter(_deflector);
    }
}
