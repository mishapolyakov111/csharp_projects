using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaсes;

public interface ISpace
{
    FlightResult TryFlyOn(AbstractSpaceship spaceship);
}