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

public class NitrineSpace : ISpace
{
    private const double NitrineSpaceDegradingСoefficient = 100;
    private readonly IReadOnlyCollection<INitrineSpaceObstacle> _obstacles;
    private readonly int _pathLength;
    public NitrineSpace(IReadOnlyCollection<INitrineSpaceObstacle> obstacles, int pathLength)
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

        IEngine? selectedEngine = spaceship.Engines.First(engine => engine is IImpulseEngine);
        if (selectedEngine == null)
        {
            return new ShipDestruction();
        }

        double? fuel = (selectedEngine is ImpulseEngineC)
            ? selectedEngine.CalculateFuel(_pathLength) * NitrineSpaceDegradingСoefficient
            : selectedEngine.CalculateFuel(_pathLength);
        double? time = selectedEngine.CalculateTime(_pathLength);
        return new Success(time, fuel);
    }
}