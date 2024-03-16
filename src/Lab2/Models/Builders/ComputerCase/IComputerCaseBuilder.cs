using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IComputerCaseBuilder : IBuilder<ComputerСase>
{
    IComputerCaseBuilder WithWidth(int width);
    IComputerCaseBuilder WithHeight(int height);
    IComputerCaseBuilder WithLength(int length);
    IComputerCaseBuilder WithMaxGPULength(int gpuLength);
    IComputerCaseBuilder WithMaxGPUWidth(int gpuWidth);
    IComputerCaseBuilder WithMotherBoardFormFactor(string formFactor);
    IComputerCaseBuilder WithName(string name);
}