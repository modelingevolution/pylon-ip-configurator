using System.Diagnostics;
using System.Text.Json;

namespace ModelingEvolution.PylonConfigurator;

public static class PylonConfigurator
{
    private const string Executable = "/usr/local/bin/pylon-ip-configurator";

    public static async Task<IReadOnlyList<PylonDevice>> ListDevicesAsync(CancellationToken ct = default)
    {
        var json = await RunAsync(["list"], ct);
        return JsonSerializer.Deserialize<List<PylonDevice>>(json) ?? [];
    }

    public static async Task<CommandResult> SetIpAsync(
        string mac,
        string ip,
        string subnet,
        string gateway,
        bool persistent = true,
        bool dhcp = false,
        string? name = null,
        CancellationToken ct = default)
    {
        var args = new List<string> { "set-ip", "--mac", mac, "--ip", ip, "--subnet", subnet, "--gateway", gateway };
        if (persistent) args.Add("--persistent");
        if (dhcp) args.Add("--dhcp");
        if (name is not null) { args.Add("--name"); args.Add(name); }

        var json = await RunAsync(args, ct);
        return JsonSerializer.Deserialize<CommandResult>(json)!;
    }

    public static async Task<CommandResult> ForceIpAsync(
        string mac,
        string ip,
        string subnet,
        string gateway,
        CancellationToken ct = default)
    {
        var json = await RunAsync(["force-ip", "--mac", mac, "--ip", ip, "--subnet", subnet, "--gateway", gateway], ct);
        return JsonSerializer.Deserialize<CommandResult>(json)!;
    }

    public static async Task<CommandResult> EnableDhcpAsync(
        string mac,
        string? name = null,
        CancellationToken ct = default)
    {
        var args = new List<string> { "dhcp", "--mac", mac };
        if (name is not null) { args.Add("--name"); args.Add(name); }

        var json = await RunAsync(args, ct);
        return JsonSerializer.Deserialize<CommandResult>(json)!;
    }

    private static async Task<string> RunAsync(IEnumerable<string> arguments, CancellationToken ct)
    {
        using var process = new Process();
        process.StartInfo = new ProcessStartInfo
        {
            FileName = Executable,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        foreach (var arg in arguments)
            process.StartInfo.ArgumentList.Add(arg);

        process.Start();

        var stdout = await process.StandardOutput.ReadToEndAsync(ct);
        var stderr = await process.StandardError.ReadToEndAsync(ct);

        await process.WaitForExitAsync(ct);

        if (process.ExitCode != 0 && string.IsNullOrWhiteSpace(stdout))
            throw new PylonConfiguratorException(process.ExitCode, stderr.Trim());

        return stdout;
    }
}
