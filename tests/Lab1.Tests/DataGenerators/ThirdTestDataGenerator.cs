using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Success = Itmo.ObjectOrientedProgramming.Lab1.Models.Success;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class ThirdTestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { new Waclass(), typeof(ShipDestruction) },
        new object[] { new Avgur(), typeof(Success) },
        new object[] { new Meredian(), typeof(Success) },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}