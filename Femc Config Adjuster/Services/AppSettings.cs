using System;
using System.IO;
using System.Text.Json;

namespace Femc_Config_Adjuster.Helpers
{
	public class Config
	{
		public string JsonFilePath { get; set; }

		// Method to load config from JSON file
		public static Config LoadConfig(string filePath)
		{
			if (!File.Exists(filePath))
				return new Config { JsonFilePath = filePath };

			var json = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<Config>(json) ?? new Config { JsonFilePath = filePath };
		}

		// Method to save config to JSON file
		public void SaveConfig(string filePath)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			var json = JsonSerializer.Serialize(this, options);
			File.WriteAllText(filePath, json);
		}

		// Example method to update or add a property
		public void UpdateProperty(string propertyName, string propertyValue)
		{
			switch (propertyName.ToLower())
			{
				case "jsonfilepath":
					this.JsonFilePath = propertyValue;
					break;
				// Might need more cases here, but easy to add
				default:
					throw new ArgumentException($"Property '{propertyName}' not found.");
			}
			SaveConfig(JsonFilePath); // Saves config after updating the property
		}
	}
}
