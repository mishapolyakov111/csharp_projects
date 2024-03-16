using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class XMP
{
    public XMP(IReadOnlyCollection<int> timings, int frequency, int voltage)
    {
        Timings = timings;
        Frequency = frequency;
        Voltage = voltage;
    }

    public IReadOnlyCollection<int> Timings { get; }
    public int Voltage { get; }
    public int Frequency { get; }
}