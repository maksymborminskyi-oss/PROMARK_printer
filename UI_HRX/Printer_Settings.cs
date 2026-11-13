using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace UI_HRX
{
    public class Printer_Settings
    {
        public string IP { get; set; } = "127.0.0.1";
        public int Port { get; set; } = 5900;

        public bool Board_Id { get; set; } = true;
        public bool PH_Index { get; set; } = false;
        public bool PH_Name { get; set; } = false;

        public string Board_Id_text { get; set; } = "0";
        public string PH_Index_text { get; set; } = "1";
        public string PH_Name_text { get; set; } = "PH#0";

        [JsonIgnore]
        public static string SettingsPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "settings.json");

        [JsonIgnore]
        public string TargetXmlAttribute
        {
            get
            {
                if (Board_Id) return $"BoardId=\"{Board_Id_text}\"";
                if (PH_Index) return $"Printhead=\"{PH_Index_text}\"";
                if (PH_Name) return $"PhName=\"{PH_Name_text}\"";
                return $"BoardId=\"{Board_Id_text}\"";
            }
        }

        public bool Validate(out string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(IP))
            {
                errorMessage = "IP-адреса не може бути порожньою.";
                return false;
            }

            if (IP.Split('.').Length != 4 || !IPAddress.TryParse(IP, out _))
            {
                errorMessage = $"Некоректний формат IP-адреси: '{IP}'.";
                return false;
            }

            if (Port < 1 || Port > 65535)
            {
                errorMessage = $"Некоректний порт: {Port}. Допустимий діапазон 1-65535.";
                return false;
            }

            if (!Board_Id && !PH_Index && !PH_Name)
            {
                errorMessage = "Оберіть хоча б один тип ідентифікатора друку (Board ID, PH Index або PH Name).";
                return false;
            }

            if (Board_Id && string.IsNullOrWhiteSpace(Board_Id_text))
            {
                errorMessage = "Значення Board ID не може бути порожнім.";
                return false;
            }

            if (PH_Index && string.IsNullOrWhiteSpace(PH_Index_text))
            {
                errorMessage = "Значення PH Index не може бути порожнім.";
                return false;
            }

            if (PH_Name && string.IsNullOrWhiteSpace(PH_Name_text))
            {
                errorMessage = "Значення PH Name не може бути порожнім.";
                return false;
            }

            errorMessage = string.Empty;
            return true;
        }

        public static Printer_Settings Load()
        {
            try
            {
                if (File.Exists(SettingsPath))
                {
                    string json = File.ReadAllText(SettingsPath);
                    var settings = JsonConvert.DeserializeObject<Printer_Settings>(json);
                    if (settings != null)
                        return settings;
                }
            }
            catch
            {
            }

            var defaultSettings = new Printer_Settings();
            defaultSettings.Save();
            return defaultSettings;
        }

        public void Save()
        {
            try
            {
                string json = JsonConvert.SerializeObject(this, Formatting.Indented);
                File.WriteAllText(SettingsPath, json);
            }
            catch (Exception ex)
            {
                throw new IOException($"Не вдалося зберегти налаштування у файл: {ex.Message}", ex);
            }
        }
    }
}
