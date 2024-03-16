using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class Deflector
{
    private int _hitPoints;

    protected Deflector(int hitPoints)
    {
        _hitPoints = hitPoints;
    }

    protected Deflector(Deflector deflector)
    {
        ArgumentNullException.ThrowIfNull(deflector);
        _hitPoints = deflector._hitPoints;
    }

    public virtual CollisionResult Collision(IObstacle obstacle)
    {
        ArgumentNullException.ThrowIfNull(obstacle);
        int remainingDamage = AbsorbDamage(obstacle.TotalDamage);

        if (obstacle is PhotonicFlash)
        {
            return new CrewFlashed();
        }

        if (remainingDamage > 0)
        {
            return new Destruction(remainingDamage);
        }

        return new Success();
    }

    protected int AbsorbDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage must be positive");
        }

        int remainingDamage = damage > _hitPoints ? damage - _hitPoints : 0;

        _hitPoints = damage > _hitPoints ? 0 : _hitPoints - damage;
        return remainingDamage;
    }
}