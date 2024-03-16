using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.DataGenerators;

public class TreeGoToDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[]
        {
            new string[] { "tree", "goto", ".." },
            new Success(@"Tree successfully switched to C:\Users\misha"),
        },

        new object[]
        {
            new string[] { "tree", "goto", "aboba" },
            new Failure("Can't connect to this address"),
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}