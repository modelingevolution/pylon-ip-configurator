using System.Text.Json.Serialization;

namespace ModelingEvolution.PylonConfigurator;

public sealed record PylonDevice
{
    [JsonPropertyName("friendlyName")]
    public string FriendlyName { get; init; } = "";

    [JsonPropertyName("fullName")]
    public string FullName { get; init; } = "";

    [JsonPropertyName("vendorName")]
    public string VendorName { get; init; } = "";

    [JsonPropertyName("deviceClass")]
    public string DeviceClass { get; init; } = "";

    [JsonPropertyName("serialNumber")]
    public string? SerialNumber { get; init; }

    [JsonPropertyName("modelName")]
    public string? ModelName { get; init; }

    [JsonPropertyName("deviceVersion")]
    public string? DeviceVersion { get; init; }

    [JsonPropertyName("userDefinedName")]
    public string? UserDefinedName { get; init; }

    [JsonPropertyName("ipAddress")]
    public string? IpAddress { get; init; }

    [JsonPropertyName("subnetMask")]
    public string? SubnetMask { get; init; }

    [JsonPropertyName("defaultGateway")]
    public string? DefaultGateway { get; init; }

    [JsonPropertyName("macAddress")]
    public string? MacAddress { get; init; }

    [JsonPropertyName("interface")]
    public string? Interface { get; init; }

    [JsonPropertyName("subnetAddress")]
    public string? SubnetAddress { get; init; }

    [JsonPropertyName("ipConfig")]
    public PylonIpConfig? IpConfig { get; init; }
}

public sealed record PylonIpConfig
{
    [JsonPropertyName("persistentIpActive")]
    public bool PersistentIpActive { get; init; }

    [JsonPropertyName("dhcpActive")]
    public bool DhcpActive { get; init; }

    [JsonPropertyName("autoIpActive")]
    public bool AutoIpActive { get; init; }

    [JsonPropertyName("persistentIpSupported")]
    public bool PersistentIpSupported { get; init; }

    [JsonPropertyName("dhcpSupported")]
    public bool DhcpSupported { get; init; }

    [JsonPropertyName("autoIpSupported")]
    public bool AutoIpSupported { get; init; }
}
