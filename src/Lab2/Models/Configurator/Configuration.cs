using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models.Configurator;

public class Configuration
{
    public Configuration(
        string? motherBoard,
        string? cpu,
        string? cooler,
        string? powerInput,
        string? computerCase,
        IEnumerable<string> raMs,
        IEnumerable<string> hdDs,
        IEnumerable<string> ssDs,
        IEnumerable<string> gpUs)
    {
        ArgumentNullException.ThrowIfNull(motherBoard);
        ArgumentNullException.ThrowIfNull(cpu);
        ArgumentNullException.ThrowIfNull(cooler);
        ArgumentNullException.ThrowIfNull(powerInput);
        ArgumentNullException.ThrowIfNull(computerCase);

        MotherBoard = motherBoard;
        Cpu = cpu;
        Cooler = cooler;
        PowerInput = powerInput;
        ComputerCase = computerCase;
        RAMs = raMs;
        HDDs = hdDs;
        SSDs = ssDs;
        GPUs = gpUs;
    }

    public static IMotherBoardNameBuilder Build => new ConfigurationBuilder();

    public string MotherBoard { get; }
    public string Cpu { get; }
    public string Cooler { get; }
    public string PowerInput { get; }
    public string ComputerCase { get; }
    public IEnumerable<string> RAMs { get; }
    public IEnumerable<string> HDDs { get; }
    public IEnumerable<string> SSDs { get; }
    public IEnumerable<string> GPUs { get; }
}