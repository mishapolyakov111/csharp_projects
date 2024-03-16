using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.DataGenerators;

public class FileMoveDataGenerator : IEnumerable<object[]>
{
private readonly List<object[]> _data = new List<object[]>
{
    new object[]
    {
        new string[] { "file", "move", "SomeStuff", "World" },
        new Success("The file SomeStuff has been successfully moved to the directory World"),
    },

    new object[]
    {
        new string[] { "file", "move", "Popa", "aboba" },
        new Failure("Directory not found"),
    },
};

public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}