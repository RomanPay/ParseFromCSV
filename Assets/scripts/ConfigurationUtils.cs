using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    private static ConfigurationData _configuration;
    
    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public static float TeddyBearMoveUnitsPerSecond => _configuration.TeddyBearMoveUnitsPerSecond;

    /// <summary>
    /// Gets the cooldown seconds for shooting
    /// </summary>
    /// <value>cooldown seconds</value>
    public static float CooldownSeconds => _configuration.CooldownSeconds;

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        _configuration = new ConfigurationData();
        Debug.Log("_config");
    }
}
