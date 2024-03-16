using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IComputerBuilder : IBuilder<Computer>
{
    IComputerBuilder WithMotherBoard(MotherBoard? motherBoard);
    IComputerBuilder WithCPU(CPU? cpu);
    IComputerBuilder WithCooler(Cooler? cooler);
    IComputerBuilder AddRAM(RAM? ram);
    IComputerBuilder WithComputerСase(ComputerСase? computerСase);
    IComputerBuilder WithPowerUnit(PowerUnit? powerUnit);
    IComputerBuilder AddGPU(GPU? gpu);
    IComputerBuilder AddSSD(SSD? ssd);
    IComputerBuilder AddHDD(HDD? hdd);
    IComputerBuilder WithWiFiAdapter(WiFiAdapter? wiFiAdapter);
}