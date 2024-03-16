using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public class Computer : IBuilderDirector<IComputerBuilder>
{
    internal Computer(
        MotherBoard? motherBoard,
        CPU? cpu,
        Cooler? cooler,
        ComputerСase? computerCase,
        PowerUnit? powerUnit,
        WiFiAdapter? wiFiAdapter,
        IReadOnlyCollection<RAM> ram,
        IReadOnlyCollection<GPU> gpus,
        IReadOnlyCollection<SSD> ssds,
        IReadOnlyCollection<HDD> hdds)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(cpu);
        ArgumentNullException.ThrowIfNull(cooler);
        ArgumentNullException.ThrowIfNull(computerCase);
        ArgumentNullException.ThrowIfNull(powerUnit);

        MotherBoard = motherBoard;
        CPU = cpu;
        Cooler = cooler;
        ComputerCase = computerCase;
        PowerUnit = powerUnit;
        WiFiAdapter = wiFiAdapter;
        RAMs = ram;
        GPUs = gpus;
        SSDs = ssds;
        HDDs = hdds;
    }

    public MotherBoard MotherBoard { get; }
    public CPU CPU { get; }
    public Cooler Cooler { get; }
    public IReadOnlyCollection<RAM> RAMs { get; }
    public ComputerСase ComputerCase { get; }
    public PowerUnit PowerUnit { get; }

    public IReadOnlyCollection<GPU> GPUs { get; }
    public IReadOnlyCollection<SSD> SSDs { get; }
    public IReadOnlyCollection<HDD> HDDs { get; }
    public WiFiAdapter? WiFiAdapter { get; }

    public static Computer Build(Configuration configuration, IRepository repository) =>
        new ComputerBuilderDirector().Construct(configuration, repository);

    public ConfigurationResult GetConfigurationResult() => new Validator().GetConfigurationResult(this);

    public IComputerBuilder Direct(IComputerBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithCPU(CPU)
            .WithMotherBoard(MotherBoard)
            .WithCooler(Cooler)
            .WithComputerСase(ComputerCase)
            .WithPowerUnit(PowerUnit)
            .WithWiFiAdapter(WiFiAdapter);

        foreach (GPU gpu in GPUs)
        {
            builder.AddGPU(gpu);
        }

        foreach (RAM ram in RAMs)
        {
            builder.AddRAM(ram);
        }

        foreach (SSD ssd in SSDs)
        {
            builder.AddSSD(ssd);
        }

        foreach (HDD hdd in HDDs)
        {
            builder.AddHDD(hdd);
        }

        return builder;
    }
}