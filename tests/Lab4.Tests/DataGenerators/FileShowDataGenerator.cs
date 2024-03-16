using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.DataGenerators;

public class FileShowDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[]
        {
            new string[] { "file", "show", "Popa" },
            new Success(string.Empty),
        },

        new object[]
        {
            new string[] { "file", "show", "Sergay.txt" },
            new Failure("File not found"),
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}