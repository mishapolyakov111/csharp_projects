using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Spaсes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Route;

public class Route
{
    public Route(IReadOnlyCollection<ISpace> segments)
    {
        Segments = segments;
    }

    public IReadOnlyCollection<ISpace> Segments { get; }
}