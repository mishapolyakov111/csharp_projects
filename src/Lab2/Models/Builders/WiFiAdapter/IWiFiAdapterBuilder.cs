using Itmo.ObjectOrientedProgramming.Lab2.Models.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public interface IWiFiAdapterBuilder : IBuilder<WiFiAdapter>
{
    IWiFiAdapterBuilder WithName(string name);
    IWiFiAdapterBuilder WithWiFiVersion(string wifiVersion);
    IWiFiAdapterBuilder WithBluetoothVersion(string? bluetoothVersion);
    IWiFiAdapterBuilder WithPCIVersion(string pciVersion);
    IWiFiAdapterBuilder WithWattage(int wattage);
}