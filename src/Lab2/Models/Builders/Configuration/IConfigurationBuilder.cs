using Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Builders.Configuration;

public interface IConfigurationBuilder : IBuilder<Configurator.Configuration>, IMotherBoardNameBuilder, ICPUNameBuilder, ICoolerNameBuilder, IPowerInputNameBuilder, IComputerCaseNameBuilder, IRAMNameBuilder
{
    IConfigurationBuilder AddGPU(string gpuName);
    IConfigurationBuilder AddHDD(string hddName);
    IConfigurationBuilder AddSSD(string hddName);
}