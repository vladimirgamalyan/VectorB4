using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VectorB4
{
    /// <summary>
    /// Основной конфигурационный класс приложения.
    /// Строго типизирован: все параметры — enum.
    /// </summary>
    public class AppConfig
    {
        private static readonly string ConfigFilePath =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

        private static AppConfig _instance;

        public static AppConfig Instance
        {
            get
            {
                if (_instance == null)
                    throw new InvalidOperationException("AppConfig not loaded. Call AppConfig.Load() first.");
                return _instance;
            }
        }

        // === Перечисления параметров ===

        [JsonConverter(typeof(StringEnumConverter))]
        public enum FormatType
        {
            Mach3,
            Mach4
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum OrientationType
        {
            Hor,
            Ver
        }

        [JsonConverter(typeof(StringEnumConverter))]
        public enum RepeatsType
        {
            Zero,
            End
        }

        // === Поля конфигурации ===
        public FormatType Format { get; set; } = FormatType.Mach4;
        public OrientationType Orientation { get; set; } = OrientationType.Hor;
        public RepeatsType Repeats { get; set; } = RepeatsType.End;

        // === Методы ===

        public static void Load()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    var cfg = JsonConvert.DeserializeObject<AppConfig>(json);

                    if (cfg == null)
                        throw new InvalidDataException("Config file is empty or invalid.");

                    _instance = cfg;
                }
                else
                {
                    _instance = new AppConfig();
                    _instance.Save();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка загрузки конфигурации: " + ex.Message);
                _instance = new AppConfig();
                _instance.Save();
            }
        }

        public void Save()
        {
            try
            {
                var json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(ConfigFilePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка сохранения конфигурации: " + ex.Message);
            }
        }

        public override string ToString()
        {
            return string.Format("Format={0}, Orientation={1}, Repeats={2}",
                Format, Orientation, Repeats);
        }
    }
}
