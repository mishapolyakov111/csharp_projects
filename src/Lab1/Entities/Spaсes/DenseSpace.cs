using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Engines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.CollisionResult;
using CrewDeath = Itmo.ObjectOrientedProgramming.Lab1.Models.CrewDeath;
using Success = Itmo.ObjectOrientedProgramming.Lab1.Models.Success;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaсes;

public class DenseSpace : ISpace
{
    private readonly IReadOnlyCollection<IDenseSpaceObstacle> _obstacles;
    private readonly int _pathLength;
    public DenseSpace(IDenseSpaceObstacle[] obstacles, int pathLength)
    {
        _obstacles = obstacles;
        _pathLength = pathLength;
    }

    public FlightResult TryFlyOn(AbstractSpaceship spaceship)
    {
        ArgumentNullException.ThrowIfNull(spaceship);

        // collide the ship with all obstacles
        bool crewFlashed = _obstacles.Select(spaceship.TryCollide).OfType<CrewFlashed>().Any();
        if (crewFlashed)
        {
            return new CrewDeath();
        }

        IEngine? selectedEngine = spaceship.Engines.FirstOrDefault(engine => engine is IJumpEngine);
        if (selectedEngine == null)
        {
            return new ShipDestruction();
        }

        double? time = selectedEngine.CalculateTime(_pathLength);
        double? fuel = selectedEngine.CalculateFuel(_pathLength);

        if (time is null || fuel is null)
        {
            return new ShipLoss();
        }

        return new Success(time, fuel);
    }
}