using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaсes;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Route;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public static class FlightManager
{
    public static FlightResult Run(Route? route, AbstractSpaceship? spaceship)
    {
        ArgumentNullException.ThrowIfNull(route);
        ArgumentNullException.ThrowIfNull(spaceship);
        double? totalFuel = 0;
        double? totalTime = 0;
        Success success;

        foreach (ISpace segment in route.Segments)
        {
            FlightResult result = segment.TryFlyOn(spaceship);
            if (result is not Success)
            {
                return result;
            }

            // cast is bad thing in this case?
            success = (Success)result;
            totalTime += success.Time;
            totalFuel += success.Fuel;
        }

        return new Success(totalTime, totalFuel);
    }
}
