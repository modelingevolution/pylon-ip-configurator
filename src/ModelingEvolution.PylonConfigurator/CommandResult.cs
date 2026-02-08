using System.Text.Json.Serialization;

namespace ModelingEvolution.PylonConfigurator;

public sealed record CommandResult
{
    [JsonPropertyName("command")]
    public string Command { get; init; } = "";

    [JsonPropertyName("mac")]
    public string? Mac { get; init; }

    [JsonPropertyName("ip")]
    public string? Ip { get; init; }

    [JsonPropertyName("subnet")]
    public string? Subnet { get; init; }

    [JsonPropertyName("gateway")]
    public string? Gateway { get; init; }

    [JsonPropertyName("persistent")]
    public bool? Persistent { get; init; }

    [JsonPropertyName("dhcp")]
    public bool? Dhcp { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("success")]
    public bool Success { get; init; }

    [JsonPropertyName("error")]
    public string? Error { get; init; }
}
