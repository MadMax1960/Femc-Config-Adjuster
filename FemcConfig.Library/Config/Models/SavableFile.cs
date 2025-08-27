using CommunityToolkit.Mvvm.ComponentModel;
using FemcConfig.Library.Utils;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace FemcConfig.Library.Config.Models;

public class SavableFile<TConfig> : ObservableObject
    where TConfig : INotifyPropertyChanged, new()
{
    private readonly string file;
    private readonly TConfig modConfig;
    private readonly object saveLock = new();

    public SavableFile(string file)
    {
        this.file = file;

        try
        {
            this.modConfig = JsonUtils.DeserializeFile<TConfig>(file);
        }
        catch (Exception)
        {
            var defaultConfig = new TConfig();
            JsonUtils.SerializeFile(defaultConfig, file);
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

        SubscribeToCollectionChanges(this.modConfig);
    }

    private void SubscribeToCollectionChanges(object config)
    {
        foreach (var property in config.GetType().GetProperties())
        {
            if (property.PropertyType.IsGenericType &&
                property.PropertyType.GetGenericTypeDefinition() == typeof(ObservableCollection<>))
            {
                var collection = property.GetValue(config) as INotifyCollectionChanged;
                if (collection != null)
                {
                    collection.CollectionChanged += (sender, args) =>
                    {
                        // Trigger PropertyChanged for the collection property
                        OnPropertyChanged(property.Name);

                        // Save the config to file
                        try
                        {
                            this.Save();
                        }
                        catch (Exception)
                        {
                            // TODO: Display error message.
                        }
                    };
                }
            }
        }
    }

    public TConfig Settings => this.modConfig;

    public void Save()
    {
        lock (saveLock)
        {
            JsonUtils.SerializeFile(this.modConfig, this.file);
        }
    }
}
