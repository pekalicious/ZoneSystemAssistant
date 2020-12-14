using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace ZoneSystemAssistant
{
    public class Values
    {
        public static Values Instance { get; private set; }

        public string[] Ev;
        public string[] ShutterSpeeds;
        public string[] Apertures;

        public static void Load()
        {
            string jsonFileName = "values.json";

            var assembly = typeof(Values).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                var jsonString = reader.ReadToEnd();

                Instance = JsonConvert.DeserializeObject<Values>(jsonString);
            }
        }
    }
}
