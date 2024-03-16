using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Repository;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class ThirdTestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[] { new Repository(), "Disclaimer of warranty obligations.\n", "CPU emits more heat than the cooler is able to dissipate.\n" },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}