using CommunityToolkit.Mvvm.ComponentModel;
using FemcConfig.Library.Utils;
using System.Text.Json;

namespace FemcConfig.Library.Config.Models;

public class ModConfig : ObservableObject
{
    private readonly string configFile;
    private readonly ReloadedModConfig modConfig;

    public ModConfig(string configFile)
    {
        this.configFile = configFile;
        try
        {
            this.modConfig = JsonUtils.DeserializeFile<ReloadedModConfig>(configFile);
        }
        catch (Exception ex)
        {
            var defaultConfig = new ReloadedModConfig();
            JsonUtils.SerializeFile(defaultConfig, configFile);
            this.modConfig = defaultConfig;
        }

        this.modConfig.PropertyChanged += (sender, args) =>
        {
            try
            {
                // TODO: Create some sort of backup incase of error.
                this.Save();
            }
            catch (Exception)
            {
                // TODO: Display error message.
            }
        };
    }

    public ReloadedModConfig Settings => this.modConfig;

    public void Save()
    {
        JsonUtils.SerializeFile(this.modConfig, this.configFile);
    }
}
