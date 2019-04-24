using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FilterBuilder.Enum;
using Newtonsoft.Json;

namespace FilterBuilder.Model {
    public class Translator {
        public Translator(Language id, string title) {
            Id = id;
            Title = title;
            Icon = $"pack://application:,,,/FilterBuilder;component/Resources/Images/{id}.png";

            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"FilterBuilder.Resources.Translations.{id}.json");
            if (stream == null) throw new FileNotFoundException($"FilterBuilder.Resources.Translations.{id}.json");
            Translations = JsonConvert.DeserializeObject<Dictionary<string, string>>(new StreamReader(stream).ReadToEnd());
        }

        public Language Id { get; }
        public string Icon { get; }
        public string Title { get; }
        public Dictionary<string, string> Translations { get; }

        public string Translate(string token) {
            return Translations[token];
        }
    }
}