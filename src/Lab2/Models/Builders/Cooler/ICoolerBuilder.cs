using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface ICoolerBuilder : IBuilder<Cooler>
{
    ICoolerBuilder WithName(string name);
    ICoolerBuilder WithSize(int size);
    ICoolerBuilder AddSupportedSockets(string socket);
    ICoolerBuilder WithMaxTDP(int tdp);
}