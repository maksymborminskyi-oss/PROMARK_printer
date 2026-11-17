using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security;

namespace UI_HRX
{
    public enum PrintTrigger
    {
        Photocell,
        Distance,
        Timer
    }

    public class HRX_Command_Builder
    {
        private readonly List<string> commandHistory = new List<string>();
        private readonly List<string> command = new List<string>();

        private readonly Printer_Settings printerSettings;

        public IReadOnlyList<string> Commands => command.AsReadOnly();

        public HRX_Command_Builder(Printer_Settings printer_Settings)
        {
            printerSettings = printer_Settings ?? throw new ArgumentNullException(nameof(printer_Settings));
        }

        public void Clear() => command.Clear();

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= command.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі списку команд.");

            command.RemoveAt(index);
        }

        private void AppendOrInsert(string tag, int index)
        {
            if (index == -1)
            {
                command.Add(tag);
                return;
            }

            if (index < 0 || index > command.Count)
                throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі списку команд.");

            command.Insert(index, tag);
        }

        private string FormatOpeningAttributes(string extraArgs)
        {
            return string.IsNullOrWhiteSpace(extraArgs)
                ? printerSettings.TargetXmlAttribute
                : $"{extraArgs.Trim()} {printerSettings.TargetXmlAttribute}";
        }

        private void Add_Tag(string commandName, string extraArgs = "", int index = -1)
        {
            if (string.IsNullOrWhiteSpace(commandName))
                throw new ArgumentException("Назва команди не може бути порожньою.", nameof(commandName));

            string tag = $"<{commandName} {FormatOpeningAttributes(extraArgs)}/>";
            AppendOrInsert(tag, index);
        }

        private void Add_Container_Tag(string commandName, string extraArgs, IEnumerable<string> childTags, int index = -1)
        {
            if (string.IsNullOrWhiteSpace(commandName))
                throw new ArgumentException("Назва команди не може бути порожньою.", nameof(commandName));

            List<string> children = childTags?.ToList() ?? new List<string>();
            string openTag = $"<{commandName} {FormatOpeningAttributes(extraArgs)}>";
            string closeTag = $"</{commandName}>";

            string fullBlock = children.Count == 0
                ? $"{openTag}\r\n{closeTag}"
                : $"{openTag}\r\n{string.Join("\r\n", children)}\r\n{closeTag}";

            AppendOrInsert(fullBlock, index);
        }

        private static List<string> BuildVariableTags(IEnumerable<PrinterVariable> variables, bool requireUnit)
        {
            var result = new List<string>();
            if (variables == null)
                return result;

            foreach (PrinterVariable variable in variables)
            {
                if (variable == null)
                    throw new ArgumentException("Елемент списку змінних не може бути null.", nameof(variables));

                if (requireUnit && !variable.Unit.HasValue)
                    throw new ArgumentException($"Для змінної '{variable.Name}' у SET_DATE_OFFSET обов'язково потрібно вказати Unit.", nameof(variables));

                string safeName = SecurityElement.Escape(variable.Name);
                string safeValue = SecurityElement.Escape(variable.Value);

                string tag = requireUnit
                    ? $"<VARIABLE Name=\"{safeName}\" Value=\"{safeValue}\" Unit=\"{variable.Unit.Value}\" />"
                    : $"<VARIABLE Name=\"{safeName}\" Value=\"{safeValue}\" />";

                result.Add(tag);
            }

            return result;
        }

        private void Add_Format_Tag(string commandName, string format, int index = -1)
        {
            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentException("Назва формату не може бути порожньою.", nameof(format));

            string safeFormat = SecurityElement.Escape(format.Trim());
            Add_Tag(commandName, $"Format=\"{safeFormat}\"", index);
        }

        public string Get_Command()
        {
            if (command.Count == 0)
                throw new InvalidOperationException("Немає команд для формування пакета.");

            string body_text = string.Join("\r\n", command);
            return $"<PROTOCOL>\r\n{body_text}\r\n</PROTOCOL>";
        }


        public void Add_Printer_Info(int index = -1) => Add_Tag("GET_PRINTER_INFO", index: index);

        public void Add_Printing_Status(int index = -1) => Add_Tag("GET_PRINTING_STATUS", index: index);

        public void Add_Printing_Format(int index = -1) => Add_Tag("GET_PRINTING_FORMAT", index: index);

        public void Add_Printing_Variables(int index = -1) => Add_Tag("GET_PRINTING_VARIABLES", index: index);

        public void Add_Format_List(int index = -1) => Add_Tag("GET_FORMAT_LIST", index: index);

        public void Add_Font_List(int index = -1) => Add_Tag("GET_FONT_LIST", index: index);

        public void Add_Error_List(int index = -1) => Add_Tag("GET_ERROR_LIST", index: index);

        public void Add_Counter(int index = -1) => Add_Tag("GET_COUNTER", index: index);

        public void Add_Print_Config(int index = -1) => Add_Tag("GET_PRINT_CONFIG", index: index);

        public void Add_Versions(int index = -1) => Add_Tag("GET_VERSIONS", index: index);

        public void Add_Variable_Batch_Count(int index = -1) => Add_Tag("GET_VARIABLE_BATCH_COUNT", index: index);

        public void Add_Queue_Status(int index = -1) => Add_Tag("QUEUE_STATUS", index: index);

        public void Get_counter_List(string format, int index = -1) => Add_Format_Tag("GET_COUNTER_LIST", format, index);

        public void Add_Variable_List(string format, int index = -1) => Add_Format_Tag("GET_VARIABLE_LIST", format, index);

        public void Add_Events_config(int index = -1) => Add_Tag("GET_EVENTS_CONFIG", index: index);

        public void Add_Queue_enable(int index = -1) => Add_Tag("QUEUE_ENABLE", index: index);

        public void Add_Queue_Disable(int index = -1) => Add_Tag("QUEUE_DISABLE", index: index);

        public void Add_Queue_Clear(int index = -1) => Add_Tag("QUEUE_CLEAR", index: index);

        public void Add_CMD_DELETE_FORMAT(string formatName, int index = -1)
        {
            if (string.IsNullOrWhiteSpace(formatName))
                throw new ArgumentException("Назва формату не може бути порожньою.", nameof(formatName));

            string safeName = SecurityElement.Escape(formatName.Trim());
            Add_Tag("CMD_DELETE_FORMAT", $"Name=\"{safeName}\"", index: index);
        }

        public void Add_SET_VARIABLE_BATCH_CLEAR(int index = -1) => Add_Tag("SET_VARIABLE_BATCH_CLEAR", index: index);

        public void Add_SET_VARIABLE_BATCH(string variable, IEnumerable<string> values, int index = -1)
        {
            if (string.IsNullOrWhiteSpace(variable))
                throw new ArgumentException("Назва змінної не може бути порожньою.", nameof(variable));

            List<string> cleanValues = values?
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .Select(v => v.Trim())
                .ToList();

            if (cleanValues == null || cleanValues.Count == 0)
                throw new ArgumentException("Список значень змінної не може бути порожнім.", nameof(values));

            string safeVariable = SecurityElement.Escape(variable.Trim());
            string safeValues = SecurityElement.Escape(string.Join("|", cleanValues));

            Add_Tag("SET_VARIABLE_BATCH", $"Variable=\"{safeVariable}\" Values=\"{safeValues}\"", index: index);
        }

        public void Add_SET_PRINTING_STATUS(bool isPrinting, int index = -1)
        {
            string value = isPrinting ? "Yes" : "No";
            Add_Tag("SET_PRINTING_STATUS", $"Value=\"{value}\"", index: index);
        }

        public void Add_SET_EVENTS_CONFIG(string ip, int port, bool status, int index = -1)
        {
            if (string.IsNullOrWhiteSpace(ip) || !IPAddress.TryParse(ip.Trim(), out _))
                throw new ArgumentException("Некоректна IP-адреса.", nameof(ip));
            if (port < 1 || port > 65535)
                throw new ArgumentOutOfRangeException(nameof(port), "Порт має бути в діапазоні від 1 до 65535.");

            string safeIp = SecurityElement.Escape(ip.Trim());
            string statusValue = status ? "True" : "False";

            Add_Tag("SET_EVENTS_CONFIG", $"Address=\"{safeIp}\" Port=\"{port}\" Status=\"{statusValue}\"", index: index);
        }

        public void Add_SET_DATE_OFFSET(string format, IEnumerable<PrinterVariable> variables, int index = -1)
        {
            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentException("Назва формату не може бути порожньою.", nameof(format));

            List<string> variableTags = BuildVariableTags(variables, requireUnit: true);
            if (variableTags.Count == 0)
                throw new ArgumentException("Команда SET_DATE_OFFSET повинна містити хоча б одну змінну.", nameof(variables));

            string safeFormat = SecurityElement.Escape(format.Trim());
            Add_Container_Tag("SET_DATE_OFFSET", $"Format=\"{safeFormat}\"", variableTags, index: index);
        }

        private static string FormatNonNegativeNumber(double value, string paramName)
        {
            if (double.IsNaN(value) || double.IsInfinity(value) || value < 0)
                throw new ArgumentOutOfRangeException(paramName, "Значення параметра не може бути від'ємним або некоректним.");

            return value.ToString(CultureInfo.InvariantCulture);
        }

        public void Add_SET_PRINT_CONFIG(
            double speed,
            double delay,
            int resolution,
            bool encoder,
            bool directionLeftToRight,
            bool rotation180,
            PrintTrigger trigger,
            double triggerEvery,
            int index = -1)
        {
            if (resolution <= 0)
                throw new ArgumentOutOfRangeException(nameof(resolution), "Роздільна здатність має бути більшою за 0.");
            if (!Enum.IsDefined(typeof(PrintTrigger), trigger))
                throw new ArgumentOutOfRangeException(nameof(trigger), "Некоректний тип тригера друку.");

            string speedText = FormatNonNegativeNumber(speed, nameof(speed));
            string delayText = FormatNonNegativeNumber(delay, nameof(delay));
            string triggerEveryText = FormatNonNegativeNumber(triggerEvery, nameof(triggerEvery));
            string triggerText = trigger.ToString().ToLowerInvariant();

            Add_Container_Tag("PRINT_CONFIG", "", new[]
            {
                $"<SPEED>{speedText}</SPEED>",
                $"<DELAY>{delayText}</DELAY>",
                $"<RESOLUTION>{resolution}</RESOLUTION>",
                $"<ENCODER>{(encoder ? "TRUE" : "FALSE")}</ENCODER>",
                $"<DIRECTION>{(directionLeftToRight ? "TRUE" : "FALSE")}</DIRECTION>",
                $"<ROTATION_180>{(rotation180 ? "TRUE" : "FALSE")}</ROTATION_180>",
                $"<TRIGGER>{triggerText}</TRIGGER>",
                $"<TRIGGER_EVERY>{triggerEveryText}</TRIGGER_EVERY>"
            }, index: index);
        }

        public void Add_SET_PRINTING_FORMAT(
            string format,
            IEnumerable<PrinterVariable> variables = null,
            int quantity = 0,
            bool useCache = false,
            int index = -1)
        {
            if (string.IsNullOrWhiteSpace(format))
                throw new ArgumentException("Назва формату не може бути порожньою.", nameof(format));
            if (quantity < 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Кількість відбитків не може бути від'ємною.");

            List<string> variableTags = BuildVariableTags(variables, requireUnit: false);
            string safeFormat = SecurityElement.Escape(format.Trim());
            string cacheAttr = useCache ? "true" : "false";

            Add_Container_Tag(
                "SET_PRINTING_FORMAT",
                $"Format=\"{safeFormat}\" Quantity=\"{quantity}\" useCache=\"{cacheAttr}\"",
                variableTags,
                index: index);
        }

        public IReadOnlyList<string> GetHistory() => commandHistory.AsReadOnly();

        public void AddHistory(string formedCommand)
        {
            if (!string.IsNullOrWhiteSpace(formedCommand))
                commandHistory.Add(formedCommand);
        }
    }
}
