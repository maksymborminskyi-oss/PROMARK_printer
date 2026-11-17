using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace UI_HRX
{
    public class HRX_Response
    {
        public string Command { get; }
        public string RawValue { get; }
        public string Message { get; }
        public bool IsSuccess { get; }
        public XDocument Document { get; }
        public XElement AnswerElement { get; }

        public HRX_Response(XDocument document, XElement answerElement)
        {
            Document = document ?? throw new ArgumentNullException(nameof(document));
            AnswerElement = answerElement ?? throw new ArgumentNullException(nameof(answerElement));

            Command = answerElement.Attribute("Command")?.Value ?? string.Empty;
            RawValue = answerElement.Attribute("Value")?.Value ?? string.Empty;
            Message = answerElement.Attribute("Message")?.Value ?? string.Empty;

            IsSuccess = string.Equals(RawValue, "OK", StringComparison.OrdinalIgnoreCase)
                     || string.Equals(RawValue, "Yes", StringComparison.OrdinalIgnoreCase);
        }
    }

    public class HRX_QueueStatus
    {
        public bool IsEnabled { get; set; }
        public int ItemCount { get; set; }
    }

    public class HRX_PrintConfig
    {
        public string Speed { get; set; }
        public string Delay { get; set; }
        public string Resolution { get; set; }
        public bool Encoder { get; set; }
        public bool DirectionLeftToRight { get; set; }
        public bool Rotation180 { get; set; }
        public PrintTrigger Trigger { get; set; }
        public string TriggerEvery { get; set; }
    }


    public static class HRX_Response_Parser
    {
        public static HRX_Response Parse(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                throw new ArgumentException("Порожня XML-відповідь.", nameof(xml));

            XDocument doc = XDocument.Parse(xml);
            XElement answer = doc.Root?.Element("ANSWER")
                ?? throw new FormatException("У відповіді відсутній тег <ANSWER>.");

            return new HRX_Response(doc, answer);
        }

        // Читає значення і з атрибута Value="...", і з тексту всередині тегу <TAG>...</TAG>
        // (наприклад, у мануалі <STATUS Value="No" />, а реальний принтер повертає <STATUS>No</STATUS>).
        public static string ReadTagValue(XElement parent, string tagName)
        {
            XElement element = parent?.Element(tagName);
            if (element == null)
                return null;

            string attrValue = element.Attribute("Value")?.Value;
            return !string.IsNullOrEmpty(attrValue) ? attrValue : element.Value;
        }

        public static List<string> ParseFormatList(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
                return new List<string>();

            return response.AnswerElement
                .Elements("FORMAT")
                .Select(el => el.Attribute("Value")?.Value)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .ToList();
        }

        public static List<string> ParseFontList(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
                return new List<string>();

            // Descendants знайде <FONT>, навіть якщо він лежить прямо в <PROTOCOL>, а не в <ANSWER>
            return response.Document
                .Descendants("FONT")
                .Select(el => el.Attribute("Value")?.Value)
                .Where(name => !string.IsNullOrWhiteSpace(name))
                .ToList();
        }

        public static List<PrinterVariable> ParseVariables(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
                return new List<PrinterVariable>();

            return response.AnswerElement
                .Elements("VARIABLE")
                .Select(el => new
                {
                    Name = el.Attribute("Name")?.Value,
                    Value = el.Attribute("Value")?.Value ?? string.Empty
                })
                .Where(x => !string.IsNullOrWhiteSpace(x.Name))
                .Select(x => new PrinterVariable(x.Name, x.Value))
                .ToList();
        }

        public static Dictionary<string, string> ParseCounters(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
                return new Dictionary<string, string>();

            // Варіант GET_COUNTER_LIST: <COUNTER Name="..." Value="..." />
            var namedCounters = response.AnswerElement
                .Elements("COUNTER")
                .Where(el => el.Attribute("Name") != null)
                .ToDictionary(
                    el => el.Attribute("Name").Value,
                    el => el.Attribute("Value")?.Value ?? string.Empty);

            if (namedCounters.Count > 0)
                return namedCounters;

            // Варіант GET_COUNTER: <COUNTER Value="..." /> та <CUSTOM_COUNTER Value="..." />
            var result = new Dictionary<string, string>();
            string total = ReadTagValue(response.AnswerElement, "COUNTER");
            string custom = ReadTagValue(response.AnswerElement, "CUSTOM_COUNTER");

            if (total != null) result["COUNTER"] = total;
            if (custom != null) result["CUSTOM_COUNTER"] = custom;
            return result;
        }

        public static List<KeyValuePair<string, string>> ParseErrorList(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
                return new List<KeyValuePair<string, string>>();

            return response.AnswerElement
                .Elements("ERRFLAG")
                .Select(el => new KeyValuePair<string, string>(
                    el.Attribute("Name")?.Value ?? string.Empty,
                    el.Attribute("Value")?.Value ?? string.Empty))
                .Where(pair => !string.IsNullOrWhiteSpace(pair.Key))
                .ToList();
        }

        public static string ParsePrintingStatus(string xml)
        {
            HRX_Response response = Parse(xml);
            return response.IsSuccess ? ReadTagValue(response.AnswerElement, "STATUS") : null;
        }

        public static string ParsePrintingFormat(string xml)
        {
            HRX_Response response = Parse(xml);
            return response.IsSuccess ? ReadTagValue(response.AnswerElement, "FORMAT") : null;
        }

        public static bool IsPositiveFlag(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            string trimmed = value.Trim();
            return string.Equals(trimmed, "Yes", StringComparison.OrdinalIgnoreCase)
                || string.Equals(trimmed, "True", StringComparison.OrdinalIgnoreCase)
                || trimmed == "1";
        }

        public static HRX_QueueStatus ParseQueueStatus(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
                return null;

            string enabledText = ReadTagValue(response.AnswerElement, "ENABLED");
            string countText = ReadTagValue(response.AnswerElement, "ITEMCOUNT");
            int.TryParse(countText, out int itemCount);

            return new HRX_QueueStatus
            {
                IsEnabled = IsPositiveFlag(enabledText),
                ItemCount = itemCount
            };
        }

        public static HRX_PrintConfig ParsePrintConfig(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
                return null;

            XElement ans = response.AnswerElement;
            string printMode = ReadTagValue(ans, "PRINTMODE") ?? string.Empty;
            PrintTrigger trigger = PrintTrigger.Photocell;
            if (Enum.TryParse(printMode.Trim(), ignoreCase: true, out PrintTrigger parsedTrigger))
                trigger = parsedTrigger;

            string triggerEvery = trigger == PrintTrigger.Distance
                ? ReadTagValue(ans, "DISTANCE")
                : trigger == PrintTrigger.Timer
                    ? ReadTagValue(ans, "TIMER")
                    : "0";

            return new HRX_PrintConfig
            {
                Speed = ReadTagValue(ans, "SPEED") ?? "0",
                Delay = ReadTagValue(ans, "DELAY") ?? "0",
                Resolution = ReadTagValue(ans, "RESOLUTION") ?? "300",
                Encoder = IsPositiveFlag(ReadTagValue(ans, "ENCODER")),
                DirectionLeftToRight = IsPositiveFlag(ReadTagValue(ans, "DIRECTION")),
                Rotation180 = IsPositiveFlag(ReadTagValue(ans, "ROTATION180")),
                Trigger = trigger,
                TriggerEvery = string.IsNullOrWhiteSpace(triggerEvery) ? "0" : triggerEvery
            };
        }

        public static string FormatSummary(string xml)
        {
            HRX_Response response = Parse(xml);
            if (!response.IsSuccess)
            {
                string reason = string.IsNullOrWhiteSpace(response.Message) ? response.RawValue : response.Message;
                return $"ПОМИЛКА ({response.Command}): {reason}";
            }

            switch (response.Command)
            {
                case "GET_FORMAT_LIST":
                {
                    List<string> formats = ParseFormatList(xml);
                    return formats.Count == 0
                        ? "Формати відсутні."
                        : $"Формати ({formats.Count}): {string.Join(", ", formats)}";
                }

                case "GET_VARIABLE_LIST":
                case "GET_PRINTING_VARIABLES":
                {
                    List<PrinterVariable> vars = ParseVariables(xml);
                    return vars.Count == 0
                        ? "Змінні у форматі відсутні."
                        : $"Змінні ({vars.Count}): {string.Join("; ", vars.Select(v => $"{v.Name}={v.Value}"))}";
                }

                case "GET_PRINTING_STATUS":
                    return $"Статус друку: {ParsePrintingStatus(xml) ?? "(невідомо)"}";

                case "GET_PRINTING_FORMAT":
                    return $"Поточний формат: {ParsePrintingFormat(xml) ?? "(не вибрано)"}";

                case "GET_COUNTER":
                case "COUNTERS":
                case "GET_COUNTER_LIST":
                {
                    Dictionary<string, string> counters = ParseCounters(xml);
                    return counters.Count == 0
                        ? "Лічильники відсутні."
                        : $"Лічильники: {string.Join("; ", counters.Select(kv => $"{kv.Key}={kv.Value}"))}";
                }

                case "GET_ERROR_LIST":
                {
                    List<KeyValuePair<string, string>> errors = ParseErrorList(xml);
                    return errors.Count == 0
                        ? "Активних помилок немає."
                        : $"Помилки: {string.Join("; ", errors.Select(er => $"{er.Key}={er.Value}"))}";
                }

                case "QUEUE_STATUS":
                {
                    HRX_QueueStatus qs = ParseQueueStatus(xml);
                    return qs == null
                        ? "Статус черги невідомий."
                        : $"Черга: {(qs.IsEnabled ? "Увімкнено" : "Вимкнено")}, завдань: {qs.ItemCount}";
                }

                default:
                    return $"OK ({response.Command})";
            }
        }
    }
}
