using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class WiFiAdapter : IBuilderDirector<IWiFiAdapterBuilder>
{
    public WiFiAdapter(
        string? name,
        string? wiFiVersion,
        string? bluetoothVersion,
        string? pciVersion,
        int wattage)
    {
        ArgumentNullException.ThrowIfNull(wiFiVersion);
        ArgumentNullException.ThrowIfNull(bluetoothVersion);
        ArgumentNullException.ThrowIfNull(pciVersion);
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        WiFiVersion = wiFiVersion;
        BluetoothVersion = bluetoothVersion;
        PCIVersion = pciVersion;
        Wattage = wattage;
    }

    public string Name { get; }
    public string WiFiVersion { get; }
    public string? BluetoothVersion { get; }
    public string PCIVersion { get; }
    public int Wattage { get; }

    public IWiFiAdapterBuilder Direct(IWiFiAdapterBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);
        builder.WithWattage(Wattage)
            .WithPCIVersion(PCIVersion)
            .WithBluetoothVersion(BluetoothVersion)
            .WithWiFiVersion(WiFiVersion);

        return builder;
    }
}