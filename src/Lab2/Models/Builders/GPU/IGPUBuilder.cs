using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IGPUBuilder : IBuilder<GPU>
{
    IGPUBuilder WithName(string name);
    IGPUBuilder WithLegth(int length);
    IGPUBuilder WithWidth(int width);
    IGPUBuilder WithFrequency(int frequency);
    IGPUBuilder WithWattage(int wattage);
    IGPUBuilder WithVersionPCI(string versionPCI);
}