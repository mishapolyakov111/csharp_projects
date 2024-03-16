using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoard : IBuilderDirector<IMotherBoardBuilder>
{
    public MotherBoard(
        string? name,
        string? socket,
        string? ddrVersion,
        string? formFactor,
        int pciLineNumber,
        int sataPortsNumber,
        int ramNumber,
        IEnumerable<int> supportedRamFraquencies,
        XMP? supportedXmp,
        BIOS? bios)
    {
        ArgumentNullException.ThrowIfNull(socket);
        ArgumentNullException.ThrowIfNull(ddrVersion);
        ArgumentNullException.ThrowIfNull(formFactor);
        ArgumentNullException.ThrowIfNull(bios);
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        Socket = socket;
        DDRVersion = ddrVersion;
        FormFactor = formFactor;
        PCILineNumber = pciLineNumber;
        SATAPortsNumber = sataPortsNumber;
        RAMNumber = ramNumber;
        SupportedRAMFraquencies = supportedRamFraquencies;
        SupportedXmp = supportedXmp;
        Bios = bios;
    }

    public string Name { get; }
    public string Socket { get; }
    public string DDRVersion { get; }
    public string FormFactor { get; }
    public int PCILineNumber { get; }
    public int SATAPortsNumber { get; }
    public int RAMNumber { get; }
    public IEnumerable<int> SupportedRAMFraquencies { get; }
    public XMP? SupportedXmp { get; }
    public BIOS Bios { get; }

    public IMotherBoardBuilder Direct(IMotherBoardBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithSocket(Socket)
            .WithDDRVersion(DDRVersion)
            .WithFormFactor(FormFactor)
            .WithPCILineNumber(PCILineNumber)
            .WithSATAPortsNumber(SATAPortsNumber)
            .WithRAMNumber(RAMNumber)
            .WithBios(Bios)
            .WithSupportedXmp(SupportedXmp);

        foreach (int ramFraquency in SupportedRAMFraquencies)
        {
            builder.AddSupportedRAMFraquencies(ramFraquency);
        }

        return builder;
    }
}