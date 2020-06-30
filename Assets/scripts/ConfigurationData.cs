using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data with default values
    static float _teddyBearMoveUnitsPerSecond = 5;
    static float _cooldownSeconds;

    #endregion

    #region Properties

    /// <summary>
    /// Gets the teddy bear move units per second
    /// </summary>
    /// <value>teddy bear move units per second</value>
    public float TeddyBearMoveUnitsPerSecond => _teddyBearMoveUnitsPerSecond;

    /// <summary>
    /// Gets the cooldown seconds for shooting
    /// </summary>
    /// <value>cooldown seconds</value>
    public float CooldownSeconds => _cooldownSeconds;

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // Read and save configuration data from file
        StreamReader input = null;
        try
        {
            // Create stream reader object
            input = File.OpenText(Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName));

            // Read in names and values
            string names = input.ReadLine();
            string values = input.ReadLine();

            // Set configuration data fields
            SetConfigurationDataFields(values);
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            // ignored
        }
        finally
        {
            // always close input file
            input?.Close();
        }
    }

    /// <summary>
    /// Sets the configuration data fields from the provided
    /// csv string
    /// </summary>
    /// <param name="csvValues">csv string of values</param>
    static void SetConfigurationDataFields(string csvValues)
    {
        // the code below assumes we know the order in which the
        // values appear in the string. We could do something more
        // complicated with the names and values, but that's not
        // necessary here
        string[] values = csvValues.Split(',');
        _teddyBearMoveUnitsPerSecond = float.Parse(values[0]);
        _cooldownSeconds = float.Parse(values[1], CultureInfo.InvariantCulture);
        Debug.Log("After parse " + _cooldownSeconds);
    }

    #endregion
}
