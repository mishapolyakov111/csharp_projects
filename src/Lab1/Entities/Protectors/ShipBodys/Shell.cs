using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities;

public abstract class Shell
{
    private int _hitPoints;

    protected Shell(int hitPoints)
    {
        _hitPoints = hitPoints;
    }

    public CollisionResult AbsorbDamage(int damage)
    {
        if (damage < 0)
        {
            throw new ArgumentException("Damage must be positive " + nameof(damage));
        }

        int remainingDamage = damage > _hitPoints ? damage - _hitPoints : 0;

        _hitPoints = damage > _hitPoints ? 0 : _hitPoints - damage;

        return remainingDamage == 0 ? new Success() : new Destruction(remainingDamage);
    }
}