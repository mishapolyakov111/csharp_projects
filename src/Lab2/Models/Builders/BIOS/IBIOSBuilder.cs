using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IBIOSBuilder : IBuilder<BIOS>
{
    IBIOSBuilder WithType(string type);
    IBIOSBuilder WithName(string name);
    IBIOSBuilder WithVersion(string version);
    IBIOSBuilder AddSupportedProcessor(string processorName);
}