using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IRAMBuilder : IBuilder<RAM>
{
    IRAMBuilder WithName(string name);
    IRAMBuilder WithMemorySize(int memorySize);
    IRAMBuilder AddSupportedJEDEC(JEDEC pair);
    IRAMBuilder AddSupportedXMP(XMP? xmpProfile);
    IRAMBuilder WithVersionDDR(string versionDDR);
    IRAMBuilder WithWattage(int wattage);
}