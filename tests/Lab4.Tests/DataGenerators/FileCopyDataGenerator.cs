using System.Collections;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Result;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests.DataGenerators;

public class FileCopyDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new List<object[]>
    {
        new object[]
        {
            new string[] { "file", "copy", "Popa", "World" },
            new Success($"The file Popa has been successfully copied to the directory World"),
        },

        new object[]
        {
            new string[] { "file", "copy", "Popa", "aboba" },
            new Failure("Directory not found"),
        },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}