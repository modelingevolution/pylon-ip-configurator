namespace ModelingEvolution.PylonConfigurator;

public sealed class PylonConfiguratorException(int exitCode, string message)
    : Exception($"pylon-ip-configurator exited with code {exitCode}: {message}")
{
    public int ExitCode { get; } = exitCode;
}
