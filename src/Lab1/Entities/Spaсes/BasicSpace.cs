using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;
using Success = Itmo.ObjectOrientedProgramming.Lab1.Models.Success;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaсes;

public class BasicSpace : ISpace
{
    private readonly IReadOnlyCollection<IBasicSpaceObstacle> _obstacles;
    private readonly int _pathLength;
    public BasicSpace(IReadOnlyCollection<IBasicSpaceObstacle> obstacles, int pathLength)
    {
        _obstacles = obstacles;
        _pathLength = pathLength;
    }

    public FlightResult TryFlyOn(AbstractSpaceship spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        // collide the ship with all obstacles
        bool shipDestructed = _obstacles.Select(spaceship.TryCollide).OfType<Destruction>().Any();
        if (shipDestructed)
        {
            return new ShipDestruction();
        }

        if (spaceship.Engines.OfType<IImpulseEngine>().Any() is false)
        {
            return new ShipDestruction();
        }

        IEngine? selectedEngine = spaceship.Engines.First(engine => engine is IImpulseEngine);
        return new Success(selectedEngine.CalculateTime(_pathLength), selectedEngine.CalculateFuel(_pathLength));
    }
}