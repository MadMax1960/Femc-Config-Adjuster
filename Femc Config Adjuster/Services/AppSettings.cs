using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Femc_Config_Adjuster.Helpers
{
	public class Config
	{
		public string JsonFilePath { get; set; }

		public static Config LoadConfig(string filePath)
		{
			if (!File.Exists(filePath))
				return new Config();

			var json = File.ReadAllText(filePath);
			return JsonSerializer.Deserialize<Config>(json) ?? new Config();
		}

		public void SaveConfig(string filePath)
		{
			var options = new JsonSerializerOptions { WriteIndented = true };
			var json = JsonSerializer.Serialize(this, options);
			File.WriteAllText(filePath, json);
		}
	}
}
