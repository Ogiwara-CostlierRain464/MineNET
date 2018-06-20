using System;

namespace MineNET.Plugins
{
    [Flags]
    public enum PluginFlags
    {
        None = 0,
        Plugin = 1,
        Library = 2,
        Package,
        ApiVersionCheck = 4,
        UsePremisePlugins = 8,
        Fast = 16,
        Slow = 32,
        Normal = PluginFlags.Fast | PluginFlags.Slow,
    }
}
