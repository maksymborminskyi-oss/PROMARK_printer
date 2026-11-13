using System;
using System.Collections.Generic;
using System.Security;

namespace UI_HRX
{
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

        private void Add_Tag(string commandName, string extraArgs = "", int index = -1)
        {
            if (string.IsNullOrWhiteSpace(commandName))
                throw new ArgumentException("Назва команди не може бути порожньою.", nameof(commandName));

            string tag = string.IsNullOrWhiteSpace(extraArgs)
                ? $"<{commandName} {printerSettings.TargetXmlAttribute}/>"
                : $"<{commandName} {extraArgs.Trim()} {printerSettings.TargetXmlAttribute}/>";

            if (index == -1)
            {
                command.Add(tag);
            }
            else
            {
                if (index < 0 || index > command.Count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Індекс виходить за межі списку команд.");

                command.Insert(index, tag);
            }
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

        public IReadOnlyList<string> GetHistory() => commandHistory.AsReadOnly();

        public void AddHistory(string formedCommand)
        {
            if (!string.IsNullOrWhiteSpace(formedCommand))
                commandHistory.Add(formedCommand);
        }
    }
}
