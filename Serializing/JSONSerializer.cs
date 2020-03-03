﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using MediaClass;

namespace Serializing
{
    public class JSONSerializer
    {
        string folder = Environment.ExpandEnvironmentVariables(@"%AppData%\Media-Database\");
        string filePath = Environment.ExpandEnvironmentVariables(@"%AppData%\Media-Database\database.json");

        public void Serialize(MediaList list)
        {
            Directory.CreateDirectory(folder);

            using (StreamWriter file = File.CreateText(filePath))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(file, list);
            }
        }

        public MediaList Deserialize()
        {
            MediaList fromFile = new MediaList();

            if (File.Exists(filePath))
            {
                using (StreamReader file = File.OpenText(filePath))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    fromFile = (MediaList)serializer.Deserialize(file, typeof(MediaList));
                }
            }

            return fromFile;
        }
    }
}
