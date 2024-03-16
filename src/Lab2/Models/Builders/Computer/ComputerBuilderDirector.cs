using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class ComputerBuilderDirector : IComputerBuilderDirector
{
    private IComputerBuilder _builder = new ComputerBuilder();

    public Computer Construct(Configuration configuration, IRepository repository)
    {
        ArgumentNullException.ThrowIfNull(repository);
        ArgumentNullException.ThrowIfNull(configuration);

        MotherBoard? motherBoard = repository.FindComponent<MotherBoard>(configuration.MotherBoard);
        CPU? cpu = repository.FindComponent<CPU>(configuration.Cpu);
        Cooler? cooler = repository.FindComponent<Cooler>(configuration.Cooler);
        PowerUnit? power = repository.FindComponent<PowerUnit>(configuration.PowerInput);
        ComputerСase? computerCase = repository.FindComponent<ComputerСase>(configuration.ComputerCase);

        _builder.WithMotherBoard(motherBoard);
        _builder.WithCPU(cpu);
        _builder.WithCooler(cooler);
        _builder.WithPowerUnit(power);
        _builder.WithComputerСase(computerCase);

        foreach (string ramName in configuration.RAMs)
        {
            RAM? ram = repository.FindComponent<RAM>(ramName);
            _builder.AddRAM(ram);
        }

        foreach (string hddName in configuration.HDDs)
        {
            HDD? hdd = repository.FindComponent<HDD>(hddName);
            _builder.AddHDD(hdd);
        }

        foreach (string ssdName in configuration.HDDs)
        {
            SSD? ssd = repository.FindComponent<SSD>(ssdName);
            _builder.AddSSD(ssd);
        }

        foreach (string gpuName in configuration.GPUs)
        {
            GPU? gpu = repository.FindComponent<GPU>(gpuName);
            _builder.AddGPU(gpu);
        }

        Computer computer = _builder.Build();
        return computer;
    }
}