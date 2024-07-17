﻿using CommunityToolkit.Mvvm.ComponentModel;
using FemcConfig.Library.Utils;

namespace FemcConfig.Library.Config.Models;

public class ModConfig : ObservableObject
{
    private readonly string configFile;
    private readonly ReloadedModConfig modConfig;

    public ModConfig(string configFile)
    {
        this.configFile = configFile;
        this.modConfig = JsonUtils.DeserializeFile<ReloadedModConfig>(configFile);
    }

    public void Save()
    {
        JsonUtils.SerializeFile(this.modConfig, this.configFile);
    }
}