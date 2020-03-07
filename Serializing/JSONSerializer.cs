using MediaClass;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperClasses
{
	public class JSONSerializer
	{
		string folder = Environment.ExpandEnvironmentVariables(@"%AppData%\Media-Database\");
		string filePath = Environment.ExpandEnvironmentVariables(@"%AppData%\Media-Database\settings.json");

		public void Serialize(MediaList list, Settings settings)
		{
			if (settings.MyFolder != null)
			{
				Directory.CreateDirectory(settings.MyFolder);
				var path = Path.Combine(settings.MyFolder, "database.json");

				using (StreamWriter file = File.CreateText(path))
				{
					JsonSerializer serializer = new JsonSerializer();
					serializer.Formatting = Formatting.Indented;
					serializer.Serialize(file, list);
				}
			}
		}

		public MediaList Deserialize(Settings settings)
		{
			MediaList fromFile = new MediaList();

			if (settings.MyFolder != null)
			{
				var path = Path.Combine(settings.MyFolder, "database.json");

				if (File.Exists(path))
				{
					using (StreamReader file = File.OpenText(path))
					{
						JsonSerializer serializer = new JsonSerializer();
						fromFile = (MediaList)serializer.Deserialize(file, typeof(MediaList));
					}
				}
			}
			return fromFile;
		}

		public void SerializeSettings(Settings settings)
		{
			Directory.CreateDirectory(folder);

			using (StreamWriter file = File.CreateText(filePath))
			{
				JsonSerializer serializer = new JsonSerializer();
				serializer.Formatting = Formatting.Indented;
				serializer.Serialize(file, settings);
			}
		}

		public Settings DeserializeSettings()
		{
			Settings fromFile = new Settings();

			if (File.Exists(filePath))
			{
				using (StreamReader file = File.OpenText(filePath))
				{
					JsonSerializer serializer = new JsonSerializer();
					fromFile = (Settings)serializer.Deserialize(file, typeof(Settings));
				}
			}
			else
			{
				Directory.CreateDirectory(folder);
				using (StreamWriter file = File.CreateText(filePath))
				{
					JsonSerializer serializer = new JsonSerializer();
					serializer.Formatting = Formatting.Indented;
					serializer.Serialize(file, fromFile);
				}
			}
			return fromFile;
		}
	}
}
