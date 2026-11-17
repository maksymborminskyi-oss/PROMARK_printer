using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_HRX.App
{
    public partial class Main_Form : Form
    {
        private Printer_Client_Settings printerClient = new Printer_Client_Settings();
        private readonly List<VariableFieldRow> variableRows = new List<VariableFieldRow>();
        private readonly List<BatchFieldRow> batchRows = new List<BatchFieldRow>();

        private sealed class DateUnitOption
        {
            public DateOffsetUnit Unit { get; }
            public string Label { get; }

            public DateUnitOption(DateOffsetUnit unit, string label)
            {
                Unit = unit;
                Label = label;
            }

            public override string ToString() => Label;
        }

        private static readonly DateUnitOption[] DateUnitOptions =
        {
            new DateUnitOption(DateOffsetUnit.Sec, "Sec (сек)"),
            new DateUnitOption(DateOffsetUnit.Min, "Min (хв)"),
            new DateUnitOption(DateOffsetUnit.Hour, "Hour (год)"),
            new DateUnitOption(DateOffsetUnit.Day, "Day (дні)"),
            new DateUnitOption(DateOffsetUnit.Month, "Month (міс)"),
            new DateUnitOption(DateOffsetUnit.Year, "Year (рік)")
        };

        private sealed class VariableFieldRow
        {
            public Panel Card { get; set; }
            public Label NamePrefixLabel { get; set; }
            public Label NameLabel { get; set; }
            public Label HintLabel { get; set; }
            public TextBox NameBox { get; set; }
            public Label ValueLabel { get; set; }
            public TextBox ValueBox { get; set; }
            public Label UnitLabel { get; set; }
            public ComboBox UnitBox { get; set; }
            public Button FromTableButton { get; set; }
            public Button RemoveButton { get; set; }
            public string VariableName => (NameBox != null ? NameBox.Text : NameLabel?.Text ?? string.Empty).Trim();
        }

        private sealed class BatchFieldRow
        {
            public Panel Card { get; set; }
            public Label NamePrefixLabel { get; set; }
            public Label NameLabel { get; set; }
            public TextBox NameBox { get; set; }
            public Label CountLabel { get; set; }
            public Button FromColButton { get; set; }
            public Button RemoveButton { get; set; }
            public TextBox ValuesBox { get; set; }
            public string VariableName => (NameBox != null ? NameBox.Text : NameLabel?.Text ?? string.Empty).Trim();
        }

        private readonly Dictionary<string, Action<HRX_Command_Builder>> simpleCommands =
            new Dictionary<string, Action<HRX_Command_Builder>>
            {
                ["GET_PRINTER_INFO"] = b => b.Add_Printer_Info(),
                ["GET_PRINTING_STATUS"] = b => b.Add_Printing_Status(),
                ["GET_PRINTING_FORMAT"] = b => b.Add_Printing_Format(),
                ["GET_PRINTING_VARIABLES"] = b => b.Add_Printing_Variables(),
                ["GET_FORMAT_LIST"] = b => b.Add_Format_List(),
                ["GET_FONT_LIST"] = b => b.Add_Font_List(),
                ["GET_ERROR_LIST"] = b => b.Add_Error_List(),
                ["GET_COUNTER"] = b => b.Add_Counter(),
                ["GET_PRINT_CONFIG"] = b => b.Add_Print_Config(),
                ["GET_VERSIONS"] = b => b.Add_Versions(),
                ["GET_VARIABLE_BATCH_COUNT"] = b => b.Add_Variable_Batch_Count(),
                ["GET_EVENTS_CONFIG"] = b => b.Add_Events_config(),
                ["QUEUE_STATUS"] = b => b.Add_Queue_Status(),
                ["QUEUE_ENABLE"] = b => b.Add_Queue_enable(),
                ["QUEUE_DISABLE"] = b => b.Add_Queue_Disable(),
                ["QUEUE_CLEAR"] = b => b.Add_Queue_Clear(),
                ["SET_VARIABLE_BATCH_CLEAR"] = b => b.Add_SET_VARIABLE_BATCH_CLEAR(),
            };

        public Main_Form()
        {
            InitializeComponent();
            LoadSettingsToUI();

            fv_vars_panel.SizeChanged += (s, e) => LayoutVariableRows(IsDateOffsetCommand());
            batch_vars_panel.SizeChanged += (s, e) => LayoutBatchRows();

            if (printing_status_cb.Items.Count > 0)
                printing_status_cb.SelectedIndex = 0;

            if (cfg_trigger_cb.Items.Count > 0)
                cfg_trigger_cb.SelectedIndex = 0;

            if (command_cb.Items.Count > 0)
                command_cb.SelectedIndex = 0;
        }

        private void LoadSettingsToUI()
        {
            try
            {
                ip_tb.Text = printerClient.Settings.IP;
                port_tb.Text = printerClient.Settings.Port.ToString();
            }
            catch (Exception ex)
            {
                LogToTerminal($"Помилка завантаження налаштувань: {ex.Message}");
            }
        }

        private void Open_Settings(object sender, EventArgs e)
        {
            using (Form_Setting form_Setting = new Form_Setting())
            {
                if (form_Setting.ShowDialog() == DialogResult.OK)
                {
                    printerClient.Settings = Printer_Settings.Load();
                    LoadSettingsToUI();
                    LogToTerminal("Налаштування оновлено та збережено.");
                }
            }
        }

        private async void conect_btn_Click(object sender, EventArgs e)
        {
            if (printerClient.IsConnected)
            {
                printerClient.Disconnect();
                conect_btn.Text = "Connect";
                ip_tb.Enabled = true;
                port_tb.Enabled = true;
                LogToTerminal("Відключено від принтера.");
                return;
            }

            try
            {
                string ipText = ip_tb.Text.Trim();
                string portText = port_tb.Text.Trim();

                if (string.IsNullOrWhiteSpace(ipText) || string.IsNullOrWhiteSpace(portText))
                    throw new ArgumentException("Поля IP та Port не можуть бути порожніми.");

                if (ipText.Split('.').Length != 4 || !IPAddress.TryParse(ipText, out IPAddress ipAddress))
                    throw new FormatException($"Некоректний формат IP-адреси: '{ipText}'.");

                if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
                    throw new FormatException($"Некоректний порт: '{portText}'. Допустимий діапазон: 1–65535.");

                conect_btn.Enabled = false;
                LogToTerminal($"Підключення до {ipAddress}:{port}...");

                await printerClient.ConnectAsync(ipText, port);

                if (printerClient.IsConnected)
                {
                    conect_btn.Text = "Disconnect";
                    ip_tb.Enabled = false;
                    port_tb.Enabled = false;
                    LogToTerminal($"Успішно підключено до {ipAddress}:{port}.");

                    try
                    {
                        printerClient.Settings.IP = ipText;
                        printerClient.Settings.Port = port;
                        printerClient.Settings.Save();
                    }
                    catch { }
                }
            }
            catch (Exception ex)
            {
                printerClient.Disconnect();
                conect_btn.Text = "Connect";
                LogToTerminal($"Помилка: {ex.Message}");
            }
            finally
            {
                conect_btn.Enabled = true;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            printerClient?.Disconnect();
            base.OnFormClosing(e);
        }

        private void LogToTerminal(string message, Color? color = null)
        {
            string line = $"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}";
            terminal_tb.SelectionStart = terminal_tb.TextLength;
            terminal_tb.SelectionLength = 0;
            terminal_tb.SelectionColor = color ?? terminal_tb.ForeColor;
            terminal_tb.AppendText(line);
            terminal_tb.SelectionColor = terminal_tb.ForeColor;
            terminal_tb.ScrollToCaret();
        }

        private async void command_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = command_cb.SelectedItem?.ToString();

            lbl_no_params.Visible = false;
            pnl_format.Visible = false;
            pnl_status.Visible = false;
            pnl_batch.Visible = false;
            pnl_events.Visible = false;
            pnl_format_vars.Visible = false;
            pnl_print_config.Visible = false;

            if (selected == "GET_COUNTER_LIST" || selected == "GET_VARIABLE_LIST" || selected == "CMD_DELETE_FORMAT")
            {
                pnl_format.Visible = true;
                label5.Text = selected == "CMD_DELETE_FORMAT" ? "Name (файл формату):" : "Format:";
                lbl_format_hint.Text = selected == "CMD_DELETE_FORMAT"
                    ? "Увага: команда безповоротно видаляє формат (наприклад: format.ubf)."
                    : "Оберіть або вкажіть назву формату на принтері (наприклад: 111).";

                if (printerClient.IsConnected)
                    await LoadFormatsDropdownsAsync();
            }
            else if (selected == "SET_PRINTING_STATUS")
            {
                pnl_status.Visible = true;
            }
            else if (selected == "SET_VARIABLE_BATCH")
            {
                pnl_batch.Visible = true;
                if (printerClient.IsConnected)
                {
                    await LoadFormatsDropdownsAsync();
                    if (batchRows.Count == 0)
                        await LoadFormatVariablesAsync(batch_format_tb, batch_load_vars_btn, PopulateBatchVariableNames, silentIfEmpty: true);
                }
            }
            else if (selected == "SET_EVENTS_CONFIG")
            {
                pnl_events.Visible = true;
            }
            else if (selected == "SET_PRINTING_FORMAT" || selected == "SET_DATE_OFFSET")
            {
                bool showUnit = selected == "SET_DATE_OFFSET";
                pnl_format_vars.Visible = true;
                pnl_fv_options.Visible = !showUnit;
                lbl_fv_vars.Text = showUnit
                    ? "Зсув дат (число + одиниця часу від поточної дати):"
                    : "Змінні (введіть значення або оберіть з Excel):";
                fv_add_var_btn.Text = showUnit ? "+ Додати дату" : "+ Додати змінну";
                UpdateFormatVarsPanelPositions(showOptions: !showUnit);
                LayoutVariableRows(showUnit);

                if (printerClient.IsConnected)
                {
                    await LoadFormatsDropdownsAsync();
                    if (CountDefinedVariableRows() == 0)
                        await LoadFormatVariablesAsync(fv_format_tb, fv_load_vars_btn, PopulateVariableNamesOrder, silentIfEmpty: true);
                }
            }
            else if (selected == "SET_PRINT_CONFIG")
            {
                pnl_print_config.Visible = true;
            }
            else
            {
                lbl_no_params.Visible = true;
            }
        }

        private void clear_terminal_btn_Click(object sender, EventArgs e)
        {
            terminal_tb.Clear();
        }

        private async void send_btn_Click(object sender, EventArgs e)
        {
            if (!printerClient.IsConnected)
            {
                LogToTerminal("Спочатку підключіться до принтера.");
                return;
            }

            string selected = command_cb.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selected))
                return;

            send_btn.Enabled = false;
            try
            {
                var builder = new HRX_Command_Builder(printerClient.Settings);

                if (simpleCommands.TryGetValue(selected, out var addAction))
                {
                    addAction(builder);
                }
                else
                {
                    if (!BuildParameterizedCommand(selected, builder))
                        return;
                }

                await SendCommand(builder);
            }
            catch (Exception ex)
            {
                LogToTerminal($"Помилка формування команди: {ex.Message}");
            }
            finally
            {
                send_btn.Enabled = true;
            }
        }

        private bool BuildParameterizedCommand(string selected, HRX_Command_Builder builder)
        {
            switch (selected)
            {
                case "GET_COUNTER_LIST":
                    builder.Get_counter_List(format_tb.Text);
                    return true;

                case "GET_VARIABLE_LIST":
                    builder.Add_Variable_List(format_tb.Text);
                    return true;

                case "CMD_DELETE_FORMAT":
                {
                    string name = format_tb.Text.Trim();
                    if (string.IsNullOrWhiteSpace(name))
                        throw new ArgumentException("Вкажіть назву формату для видалення.");

                    DialogResult confirm = MessageBox.Show(
                        $"Видалити формат '{name}' з пам'яті принтера?",
                        "Підтвердження видалення",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (confirm != DialogResult.Yes)
                        return false;

                    builder.Add_CMD_DELETE_FORMAT(name);
                    return true;
                }

                case "SET_PRINTING_STATUS":
                    builder.Add_SET_PRINTING_STATUS(printing_status_cb.SelectedIndex == 0);
                    return true;

                case "SET_VARIABLE_BATCH":
                    AddBatchCommandsFromPanel(builder);
                    return true;

                case "SET_EVENTS_CONFIG":
                    if (!int.TryParse(events_port_tb.Text.Trim(), out int eventPort))
                        throw new FormatException("Некоректний UDP порт для подій.");
                    builder.Add_SET_EVENTS_CONFIG(events_ip_tb.Text, eventPort, events_status_chk.Checked);
                    return true;

                case "SET_PRINTING_FORMAT":
                {
                    List<PrinterVariable> vars = ReadVariablesFromGrid(requireUnit: false);
                    builder.Add_SET_PRINTING_FORMAT(
                        fv_format_tb.Text,
                        vars,
                        (int)fv_quantity_nud.Value,
                        fv_use_cache_chk.Checked);
                    return true;
                }

                case "SET_DATE_OFFSET":
                {
                    List<PrinterVariable> vars = ReadVariablesFromGrid(requireUnit: true);
                    builder.Add_SET_DATE_OFFSET(fv_format_tb.Text, vars);
                    return true;
                }

                case "SET_PRINT_CONFIG":
                    AddPrintConfigFromUi(builder);
                    return true;

                default:
                    throw new InvalidOperationException($"Невідома команда: {selected}");
            }
        }

        private int CountDefinedVariableRows()
        {
            return variableRows.Count(r => !string.IsNullOrWhiteSpace(r.VariableName));
        }

        private List<PrinterVariable> ReadVariablesFromGrid(bool requireUnit)
        {
            var result = new List<PrinterVariable>();

            foreach (VariableFieldRow row in variableRows)
            {
                string name = row.VariableName;
                string value = row.ValueBox.Text;

                if (string.IsNullOrWhiteSpace(name))
                {
                    if (string.IsNullOrWhiteSpace(value))
                        continue;

                    throw new ArgumentException("Вказано значення без назви змінної.");
                }

                if (string.IsNullOrEmpty(value))
                {
                    if (requireUnit)
                        continue;

                    throw new ArgumentException($"Введіть значення для змінної '{name}' або виберіть його з таблиці Excel.");
                }

                if (!requireUnit)
                {
                    result.Add(new PrinterVariable(name, value));
                    continue;
                }

                if (!(row.UnitBox.SelectedItem is DateUnitOption unitOption))
                    throw new FormatException($"Для змінної '{name}' оберіть одиницю часу (Unit).");

                result.Add(new PrinterVariable(name, value, unitOption.Unit));
            }

            if (requireUnit && result.Count == 0)
                throw new ArgumentException("Вкажіть зсув (значення) хоча б для однієї змінної дати.");

            return result;
        }

        private async Task LoadFormatsDropdownsAsync()
        {
            try
            {
                var builder = new HRX_Command_Builder(printerClient.Settings);
                builder.Add_Format_List();
                await SendCommandAndReturnAsync(builder);
            }
            catch (Exception ex)
            {
                LogToTerminal($"Не вдалося завантажити список форматів: {ex.Message}");
            }
        }

        private void UpdateFormatDropdowns(IReadOnlyList<string> formats)
        {
            UpdateSingleDropdown(format_tb, formats);
            UpdateSingleDropdown(fv_format_tb, formats);
            UpdateSingleDropdown(batch_format_tb, formats);
        }

        private static void UpdateSingleDropdown(ComboBox comboBox, IReadOnlyList<string> formats)
        {
            string currentText = comboBox.Text;
            comboBox.Items.Clear();

            foreach (string format in formats)
                comboBox.Items.Add(format);

            if (!string.IsNullOrWhiteSpace(currentText))
                comboBox.Text = currentText;
            else if (comboBox.Items.Count > 0)
                comboBox.SelectedIndex = 0;
        }

        private async void fv_format_tb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!printerClient.IsConnected)
                return;

            string selectedFormat = fv_format_tb.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedFormat))
                await LoadFormatVariablesAsync(fv_format_tb, fv_load_vars_btn, PopulateVariableNamesOrder, silentIfEmpty: false, overrideFormat: selectedFormat);
        }

        private async void fv_load_vars_btn_Click(object sender, EventArgs e)
        {
            if (!printerClient.IsConnected)
            {
                LogToTerminal("Спочатку підключіться до принтера.");
                return;
            }

            await LoadFormatVariablesAsync(fv_format_tb, fv_load_vars_btn, PopulateVariableNamesOrder, silentIfEmpty: false);
        }

        private async void batch_format_tb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!printerClient.IsConnected)
                return;

            string selectedFormat = batch_format_tb.SelectedItem?.ToString();
            if (!string.IsNullOrWhiteSpace(selectedFormat))
                await LoadFormatVariablesAsync(batch_format_tb, batch_load_vars_btn, PopulateBatchVariableNames, silentIfEmpty: false, overrideFormat: selectedFormat);
        }

        private async void batch_load_vars_btn_Click(object sender, EventArgs e)
        {
            if (!printerClient.IsConnected)
            {
                LogToTerminal("Спочатку підключіться до принтера.");
                return;
            }

            await LoadFormatVariablesAsync(batch_format_tb, batch_load_vars_btn, PopulateBatchVariableNames, silentIfEmpty: false);
        }

        private async Task LoadFormatVariablesAsync(
            ComboBox formatCombo,
            Button triggerButton,
            Action<IReadOnlyList<PrinterVariable>> onLoaded,
            bool silentIfEmpty,
            string overrideFormat = null)
        {
            triggerButton.Enabled = false;
            try
            {
                string formatName = (overrideFormat ?? formatCombo.Text).Trim();
                if (string.IsNullOrWhiteSpace(formatName))
                {
                    var fmtBuilder = new HRX_Command_Builder(printerClient.Settings);
                    fmtBuilder.Add_Printing_Format();
                    string fmtResponse = await SendCommandAndReturnAsync(fmtBuilder);
                    if (!string.IsNullOrWhiteSpace(fmtResponse))
                    {
                        formatName = HRX_Response_Parser.ParsePrintingFormat(fmtResponse)?.Trim();
                        if (!string.IsNullOrWhiteSpace(formatName))
                            formatCombo.Text = formatName;
                    }
                }

                if (string.IsNullOrWhiteSpace(formatName))
                {
                    if (!silentIfEmpty)
                        LogToTerminal("Вкажіть назву формату, щоб завантажити змінні.");
                    return;
                }

                var varBuilder = new HRX_Command_Builder(printerClient.Settings);
                varBuilder.Add_Variable_List(formatName);
                string varResponse = await SendCommandAndReturnAsync(varBuilder);
                if (string.IsNullOrWhiteSpace(varResponse))
                    return;

                HRX_Response parsed = HRX_Response_Parser.Parse(varResponse);
                if (!parsed.IsSuccess)
                    return;

                List<PrinterVariable> vars = HRX_Response_Parser.ParseVariables(varResponse);
                onLoaded(vars);

                if (vars.Count > 0)
                    LogToTerminal($"Завантажено {vars.Count} змінних формату '{formatName}'.");
            }
            catch (Exception ex)
            {
                LogToTerminal($"Не вдалося завантажити змінні формату: {ex.Message}");
            }
            finally
            {
                triggerButton.Enabled = true;
            }
        }

        private void ClearBatchRows()
        {
            batchRows.Clear();
            batch_vars_panel.Controls.Clear();
            batch_vars_panel.VerticalScroll.Value = 0;
        }

        private void PopulateBatchVariableNames(IReadOnlyList<PrinterVariable> vars)
        {
            ClearBatchRows();
            foreach (PrinterVariable variable in vars)
            {
                AddBatchFieldRow(variable.Name, Array.Empty<string>(), editableName: false);
            }

            if (batchRows.Count > 0)
                batchRows[0].ValuesBox.Focus();
        }

        private bool IsDateOffsetCommand() => command_cb.SelectedItem?.ToString() == "SET_DATE_OFFSET";

        private static int GetScrollPanelContentWidth(Panel panel)
        {
            return Math.Max(220, panel.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 12);
        }

        private static Button CreateRemoveRowButton()
        {
            return new Button
            {
                FlatStyle = FlatStyle.Flat,
                Font = new Font(SystemFonts.DefaultFont.FontFamily, 8F, FontStyle.Bold),
                Size = new Size(22, 20),
                TabStop = false,
                Text = "×",
                UseVisualStyleBackColor = true
            };
        }

        private void AddBatchFieldRow(string name, IReadOnlyList<string> values, bool editableName)
        {
            var card = new Panel
            {
                BackColor = SystemColors.ControlLightLight,
                BorderStyle = BorderStyle.FixedSingle
            };

            var row = new BatchFieldRow { Card = card };

            if (editableName)
            {
                row.NamePrefixLabel = new Label
                {
                    AutoSize = true,
                    Text = "Змінна:"
                };
                row.NameBox = new TextBox
                {
                    Text = name ?? string.Empty
                };
                card.Controls.Add(row.NamePrefixLabel);
                card.Controls.Add(row.NameBox);
            }
            else
            {
                row.NameLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font(Font, FontStyle.Bold),
                    Text = name
                };
                card.Controls.Add(row.NameLabel);
            }

            row.CountLabel = new Label
            {
                AutoSize = true,
                ForeColor = SystemColors.GrayText,
                Text = FormatBatchCountText(values.Count)
            };

            row.FromColButton = new Button
            {
                Size = new Size(96, 23),
                Text = "Колонка Excel",
                UseVisualStyleBackColor = true
            };

            row.RemoveButton = CreateRemoveRowButton();

            row.ValuesBox = new TextBox
            {
                Font = new Font("Consolas", 9F),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Lines = values.Select(LabelDataHelper.EncodeMultiline).ToArray()
            };

            row.ValuesBox.TextChanged += (s, e) =>
            {
                row.CountLabel.Text = FormatBatchCountText(ParseBatchRowValues(row.ValuesBox.Text).Count);
            };
            row.FromColButton.Click += (s, e) => FillBatchRowFromSelectedExcelColumn(row);
            row.RemoveButton.Click += (s, e) =>
            {
                batchRows.Remove(row);
                batch_vars_panel.Controls.Remove(card);
                card.Dispose();
                LayoutBatchRows();
            };

            card.Controls.Add(row.CountLabel);
            card.Controls.Add(row.FromColButton);
            card.Controls.Add(row.RemoveButton);
            card.Controls.Add(row.ValuesBox);

            batchRows.Add(row);
            batch_vars_panel.Controls.Add(card);
            LayoutBatchRows();
        }

        private void LayoutBatchRows()
        {
            int cardWidth = GetScrollPanelContentWidth(batch_vars_panel);
            const int cardHeight = 90;
            const int spacing = 6;
            int scrollY = batch_vars_panel.VerticalScroll.Value;

            for (int i = 0; i < batchRows.Count; i++)
            {
                BatchFieldRow row = batchRows[i];
                row.Card.Location = new Point(6, 6 + i * (cardHeight + spacing) - scrollY);
                row.Card.Size = new Size(cardWidth, cardHeight);

                row.RemoveButton.Location = new Point(cardWidth - 28, 5);
                row.FromColButton.Location = new Point(row.RemoveButton.Left - 4 - row.FromColButton.Width, 4);

                if (row.NameBox != null)
                {
                    row.NamePrefixLabel.Location = new Point(6, 8);
                    int nameLeft = row.NamePrefixLabel.Right + 4;
                    int countLeft = row.FromColButton.Left - 52;
                    row.NameBox.Location = new Point(nameLeft, 5);
                    row.NameBox.Size = new Size(Math.Max(60, countLeft - nameLeft - 6), 22);
                    row.CountLabel.Location = new Point(row.NameBox.Right + 6, 8);
                }
                else
                {
                    row.NameLabel.Location = new Point(6, 8);
                    row.CountLabel.Location = new Point(Math.Min(row.FromColButton.Left - 54, row.NameLabel.Right + 8), 8);
                }

                row.ValuesBox.Location = new Point(6, 30);
                row.ValuesBox.Size = new Size(Math.Max(120, cardWidth - 14), 52);
            }
        }

        private static string FormatBatchCountText(int count) => $"{count} знач.";

        private static List<string> ParseBatchRowValues(string rawText)
        {
            if (string.IsNullOrWhiteSpace(rawText))
                return new List<string>();

            string[] tokens = rawText.Contains('|')
                ? rawText.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries)
                : rawText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            return tokens
                .Select(v => LabelDataHelper.DecodeMultiline(v.Trim()))
                .Where(v => !string.IsNullOrWhiteSpace(v))
                .ToList();
        }

        private void AddBatchCommandsFromPanel(HRX_Command_Builder builder)
        {
            int added = 0;
            foreach (BatchFieldRow row in batchRows)
            {
                List<string> values = ParseBatchRowValues(row.ValuesBox.Text);
                string name = row.VariableName;

                if (values.Count == 0)
                    continue;

                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("Вказано список значень без назви змінної.");

                builder.Add_SET_VARIABLE_BATCH(name, values);
                added++;
            }

            if (added == 0)
                throw new ArgumentException("Додайте значення хоча б для однієї змінної (вручну або з Excel).");
        }

        private void FillBatchRowFromSelectedExcelColumn(BatchFieldRow row)
        {
            if (!(data_grid.DataSource is DataTable table) || data_grid.CurrentCell == null)
            {
                LogToTerminal("Завантажте Excel і клікніть будь-яку клітинку потрібної колонки.");
                return;
            }

            string colName = table.Columns[data_grid.CurrentCell.ColumnIndex].ColumnName;
            List<string> values = LabelDataHelper.ColumnToBatchValues(table, colName);
            row.ValuesBox.Lines = values.Select(LabelDataHelper.EncodeMultiline).ToArray();
            row.CountLabel.Text = FormatBatchCountText(values.Count);

            if (row.NameBox != null && string.IsNullOrWhiteSpace(row.NameBox.Text))
                row.NameBox.Text = colName;

            LogToTerminal($"Колонка '{colName}' ({values.Count} значень) -> '{row.VariableName}'.");
        }

        private void batch_from_excel_btn_Click(object sender, EventArgs e)
        {
            if (!(data_grid.DataSource is DataTable table) || table.Columns.Count == 0)
            {
                LogToTerminal("Спочатку завантажте Excel-файл.");
                return;
            }

            if (batchRows.Count == 0)
            {
                ClearBatchRows();
                foreach (DataColumn column in table.Columns)
                {
                    List<string> values = LabelDataHelper.ColumnToBatchValues(table, column.ColumnName);
                    AddBatchFieldRow(column.ColumnName, values, editableName: false);
                }
                LogToTerminal($"Завантажено всі {table.Columns.Count} колонок з Excel у пакет.");
                return;
            }

            bool matchedByName = false;
            foreach (BatchFieldRow row in batchRows)
            {
                string varName = row.VariableName;
                if (string.IsNullOrWhiteSpace(varName))
                    continue;

                DataColumn matched = table.Columns
                    .Cast<DataColumn>()
                    .FirstOrDefault(c => string.Equals(c.ColumnName, varName, StringComparison.OrdinalIgnoreCase));

                if (matched != null)
                {
                    List<string> values = LabelDataHelper.ColumnToBatchValues(table, matched.ColumnName);
                    row.ValuesBox.Lines = values.Select(LabelDataHelper.EncodeMultiline).ToArray();
                    matchedByName = true;
                }
            }

            if (!matchedByName)
            {
                int colIndex = 0;
                foreach (BatchFieldRow row in batchRows)
                {
                    if (colIndex >= table.Columns.Count)
                        break;

                    List<string> values = LabelDataHelper.ColumnToBatchValues(table, table.Columns[colIndex].ColumnName);
                    row.ValuesBox.Lines = values.Select(LabelDataHelper.EncodeMultiline).ToArray();
                    colIndex++;
                }
            }

            LogToTerminal("Значення колонок з Excel підставлено у змінні пакета.");
        }

        private void batch_add_var_btn_Click(object sender, EventArgs e)
        {
            AddBatchFieldRow(string.Empty, Array.Empty<string>(), editableName: true);
            batchRows.Last().NameBox.Focus();
        }

        private void batch_clear_ui_btn_Click(object sender, EventArgs e)
        {
            ClearBatchRows();
        }

        private async void batch_clear_prn_btn_Click(object sender, EventArgs e)
        {
            if (!printerClient.IsConnected)
            {
                LogToTerminal("Спочатку підключіться до принтера.");
                return;
            }

            batch_clear_prn_btn.Enabled = false;
            try
            {
                var builder = new HRX_Command_Builder(printerClient.Settings);
                builder.Add_SET_VARIABLE_BATCH_CLEAR();
                await SendCommandAndReturnAsync(builder);
            }
            finally
            {
                batch_clear_prn_btn.Enabled = true;
            }
        }

        private void ClearVariableRows()
        {
            variableRows.Clear();
            fv_vars_panel.Controls.Clear();
        }

        private void PopulateVariableNamesOrder(IReadOnlyList<PrinterVariable> vars)
        {
            ClearVariableRows();
            foreach (PrinterVariable variable in vars)
            {
                AddVariableFieldRow(variable.Name, string.Empty, editableName: false, hintText: $"На принтері: {variable.Value}");
            }

            if (variableRows.Count > 0)
                variableRows[0].ValueBox.Focus();
        }

        private void UpdateFormatVarsPanelPositions(bool showOptions)
        {
            int labelTop = showOptions ? pnl_fv_options.Bottom + 4 : pnl_fv_options.Top + 2;
            lbl_fv_vars.Top = labelTop;

            int btnTop = lbl_fv_vars.Bottom + 4;
            fv_from_row_btn.Top = btnTop;
            fv_add_var_btn.Top = btnTop;
            fv_clear_vars_btn.Top = btnTop;

            int panelTop = fv_from_row_btn.Bottom + 6;
            fv_vars_panel.Top = panelTop;
            fv_vars_panel.Height = Math.Max(120, pnl_format_vars.ClientSize.Height - panelTop - 6);
        }

        private void AddVariableFieldRow(string name, string value, bool editableName, string hintText = null)
        {
            var card = new Panel
            {
                BackColor = SystemColors.ControlLightLight,
                BorderStyle = BorderStyle.FixedSingle
            };

            var row = new VariableFieldRow { Card = card };

            if (editableName)
            {
                row.NamePrefixLabel = new Label { AutoSize = true };
                row.NameBox = new TextBox { Text = name ?? string.Empty };
                card.Controls.Add(row.NamePrefixLabel);
                card.Controls.Add(row.NameBox);
            }
            else
            {
                row.NameLabel = new Label
                {
                    AutoSize = true,
                    Font = new Font(Font, FontStyle.Bold),
                    Text = name
                };
                card.Controls.Add(row.NameLabel);

                if (!string.IsNullOrEmpty(hintText))
                {
                    row.HintLabel = new Label
                    {
                        AutoEllipsis = true,
                        AutoSize = false,
                        ForeColor = SystemColors.GrayText,
                        Height = 16,
                        Text = $"({hintText})"
                    };
                    card.Controls.Add(row.HintLabel);
                }
            }

            row.ValueLabel = new Label
            {
                AutoSize = true,
                Text = "Зсув:"
            };

            row.ValueBox = new TextBox
            {
                Font = new Font("Consolas", 9F),
                Text = value ?? string.Empty
            };

            row.UnitLabel = new Label
            {
                AutoSize = true,
                Text = "Од.:"
            };

            row.UnitBox = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                DropDownWidth = 115,
                FormattingEnabled = true
            };
            row.UnitBox.Items.AddRange(DateUnitOptions);
            row.UnitBox.SelectedIndex = 3;

            row.FromTableButton = new Button
            {
                Text = "З табл.",
                UseVisualStyleBackColor = true
            };
            row.FromTableButton.Click += (s, e) => FillVariableRowFromSelectedExcelCell(row);

            row.RemoveButton = CreateRemoveRowButton();
            row.RemoveButton.Click += (s, e) =>
            {
                variableRows.Remove(row);
                fv_vars_panel.Controls.Remove(card);
                card.Dispose();
                LayoutVariableRows(IsDateOffsetCommand());
            };

            card.Controls.Add(row.ValueLabel);
            card.Controls.Add(row.ValueBox);
            card.Controls.Add(row.UnitLabel);
            card.Controls.Add(row.UnitBox);
            card.Controls.Add(row.FromTableButton);
            card.Controls.Add(row.RemoveButton);

            variableRows.Add(row);
            fv_vars_panel.Controls.Add(card);
            LayoutVariableRows(IsDateOffsetCommand());
        }

        private void LayoutVariableRows(bool isDateOffset)
        {
            int cardWidth = GetScrollPanelContentWidth(fv_vars_panel);
            int cardHeight = isDateOffset ? 62 : 70;
            const int spacing = 6;
            int scrollY = fv_vars_panel.VerticalScroll.Value;

            for (int i = 0; i < variableRows.Count; i++)
            {
                VariableFieldRow row = variableRows[i];
                row.Card.Location = new Point(6, 6 + i * (cardHeight + spacing) - scrollY);
                row.Card.Size = new Size(cardWidth, cardHeight);

                row.RemoveButton.Location = new Point(cardWidth - 28, 5);

                if (row.NameBox != null)
                {
                    row.NamePrefixLabel.Text = isDateOffset ? "Поле дати:" : "Змінна:";
                    row.NamePrefixLabel.Location = new Point(6, 8);
                    int nameLeft = row.NamePrefixLabel.Right + 4;
                    row.NameBox.Location = new Point(nameLeft, 5);
                    row.NameBox.Size = new Size(Math.Max(80, row.RemoveButton.Left - nameLeft - 6), 22);
                }
                else
                {
                    row.NameLabel.Location = new Point(6, 7);
                    if (row.HintLabel != null)
                    {
                        int hintLeft = row.NameLabel.Right + 6;
                        row.HintLabel.Location = new Point(hintLeft, 7);
                        row.HintLabel.Width = Math.Max(0, row.RemoveButton.Left - hintLeft - 4);
                        row.HintLabel.Visible = row.HintLabel.Width > 35;
                    }
                }

                row.ValueLabel.Visible = isDateOffset;
                row.UnitLabel.Visible = isDateOffset;
                row.UnitBox.Visible = isDateOffset;

                if (isDateOffset)
                {
                    row.ValueBox.Multiline = false;
                    row.ValueBox.ScrollBars = ScrollBars.None;

                    row.FromTableButton.Size = new Size(56, 23);
                    row.FromTableButton.Location = new Point(cardWidth - 62, 30);

                    row.UnitBox.Size = new Size(84, 23);
                    row.UnitBox.Location = new Point(row.FromTableButton.Left - 90, 30);

                    row.UnitLabel.Location = new Point(row.UnitBox.Left - row.UnitLabel.Width - 2, 34);
                    row.ValueLabel.Location = new Point(6, 34);

                    int valLeft = row.ValueLabel.Right + 4;
                    row.ValueBox.Location = new Point(valLeft, 31);
                    row.ValueBox.Size = new Size(Math.Max(40, row.UnitLabel.Left - valLeft - 6), 22);
                }
                else
                {
                    row.ValueBox.Multiline = true;
                    row.ValueBox.ScrollBars = ScrollBars.Vertical;

                    row.FromTableButton.Size = new Size(58, 32);
                    row.FromTableButton.Location = new Point(cardWidth - 64, 30);

                    row.ValueBox.Location = new Point(6, 30);
                    row.ValueBox.Size = new Size(Math.Max(100, row.FromTableButton.Left - 12), 32);
                }
            }
        }

        private void FillVariableRowFromSelectedExcelCell(VariableFieldRow row)
        {
            if (data_grid.CurrentCell == null)
            {
                LogToTerminal("Оберіть клітинку в таблиці Excel знизу.");
                return;
            }

            row.ValueBox.Text = data_grid.CurrentCell.Value?.ToString() ?? string.Empty;
            row.ValueBox.Focus();
        }

        private void fv_add_var_btn_Click(object sender, EventArgs e)
        {
            AddVariableFieldRow(string.Empty, string.Empty, editableName: true);
            variableRows.Last().NameBox.Focus();
        }

        private void fv_from_row_btn_Click(object sender, EventArgs e) => ApplyExcelRowToVariablesGrid();

        private void data_grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            string selected = command_cb.SelectedItem?.ToString();
            if (selected != "SET_PRINTING_FORMAT" && selected != "SET_DATE_OFFSET")
                command_cb.SelectedItem = "SET_PRINTING_FORMAT";

            ApplyExcelRowToVariablesGrid();
        }

        private void ApplyExcelRowToVariablesGrid()
        {
            if (!(data_grid.CurrentRow?.DataBoundItem is DataRowView rowView))
            {
                LogToTerminal("Спочатку завантажте Excel та оберіть рядок у таблиці.");
                return;
            }

            DataRow excelRow = rowView.Row;
            if (variableRows.Count == 0)
            {
                ClearVariableRows();
                foreach (DataColumn column in excelRow.Table.Columns)
                {
                    AddVariableFieldRow(column.ColumnName, excelRow[column]?.ToString() ?? string.Empty, editableName: false);
                }
                LogToTerminal($"Підставлено рядок з Excel ({excelRow.Table.Columns.Count} змінних).");
                return;
            }

            bool matchedByName = false;
            foreach (VariableFieldRow row in variableRows)
            {
                string varName = row.VariableName;
                if (string.IsNullOrWhiteSpace(varName))
                    continue;

                DataColumn matchedColumn = excelRow.Table.Columns
                    .Cast<DataColumn>()
                    .FirstOrDefault(c => string.Equals(c.ColumnName, varName, StringComparison.OrdinalIgnoreCase));

                if (matchedColumn != null)
                {
                    row.ValueBox.Text = excelRow[matchedColumn]?.ToString() ?? string.Empty;
                    matchedByName = true;
                }
            }

            if (!matchedByName)
            {
                int colIndex = 0;
                foreach (VariableFieldRow row in variableRows)
                {
                    if (colIndex >= excelRow.Table.Columns.Count)
                        break;

                    row.ValueBox.Text = excelRow[colIndex]?.ToString() ?? string.Empty;
                    colIndex++;
                }
            }

            LogToTerminal("Значення з вибраного рядка Excel підставлено у поля змінних.");
        }

        private void fv_clear_vars_btn_Click(object sender, EventArgs e)
        {
            ClearVariableRows();
        }

        private void AddPrintConfigFromUi(HRX_Command_Builder builder)
        {
            double speed = ParseInvariantDouble(cfg_speed_tb.Text, "Speed");
            double delay = ParseInvariantDouble(cfg_delay_tb.Text, "Delay");
            double triggerEvery = ParseInvariantDouble(cfg_trigger_every_tb.Text, "Trigger Every");

            if (!int.TryParse(cfg_resolution_tb.Text.Trim(), out int resolution))
                throw new FormatException("Некоректне значення Resolution (очікується ціле число).");

            if (!Enum.TryParse(cfg_trigger_cb.SelectedItem?.ToString(), ignoreCase: true, out PrintTrigger trigger))
                throw new FormatException("Оберіть коректний тип тригера.");

            builder.Add_SET_PRINT_CONFIG(
                speed,
                delay,
                resolution,
                cfg_encoder_chk.Checked,
                cfg_direction_chk.Checked,
                cfg_rotation180_chk.Checked,
                trigger,
                triggerEvery);
        }

        private static double ParseInvariantDouble(string input, string fieldName)
        {
            string normalized = (input ?? string.Empty).Trim().Replace(',', '.');
            if (!double.TryParse(normalized, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                throw new FormatException($"Некоректне числове значення у полі '{fieldName}'.");

            return value;
        }

        private void load_excel_btn_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Title = "Виберіть файл Excel";
                dialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";

                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                try
                {
                    var source = new ExcelLabelDataSource(dialog.FileName);
                    DataTable table = source.LoadTable();
                    data_grid.DataSource = table;
                    excel_status_lbl.Text = $"{source.SourceName} ({table.Rows.Count} рядків, {table.Columns.Count} колонок)";
                    LogToTerminal($"Завантажено Excel '{source.SourceName}': {table.Rows.Count} рядків.");
                }
                catch (Exception ex)
                {
                    LogToTerminal($"Помилка читання Excel: {ex.Message}");
                    MessageBox.Show(ex.Message, "Помилка завантаження Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void print_btn_Click(object sender, EventArgs e) =>
            await SendPrintingStatusAsync(true);

        private async void pause_btn_Click(object sender, EventArgs e) =>
            await SendPrintingStatusAsync(false);

        private async Task SendPrintingStatusAsync(bool startPrinting)
        {
            if (!printerClient.IsConnected)
            {
                LogToTerminal("Спочатку підключіться до принтера.");
                return;
            }

            print_btn.Enabled = false;
            pause_btn.Enabled = false;
            try
            {
                var builder = new HRX_Command_Builder(printerClient.Settings);
                builder.Add_SET_PRINTING_STATUS(startPrinting);
                await SendCommand(builder);
            }
            catch (Exception ex)
            {
                LogToTerminal($"Помилка зміни статусу: {ex.Message}");
            }
            finally
            {
                print_btn.Enabled = true;
                pause_btn.Enabled = true;
            }
        }

        public Task SendCommand(HRX_Command_Builder builder) => SendCommandAndReturnAsync(builder);

        private async Task<string> SendCommandAndReturnAsync(HRX_Command_Builder builder)
        {
            try
            {
                string cmdText = builder.Get_Command();
                LogToTerminal($"TX:{Environment.NewLine}{cmdText}", Color.FromArgb(0, 102, 204));
                string response = await printerClient.SendAsync(builder);
                builder.AddHistory(cmdText);
                LogToTerminal($"RX:{Environment.NewLine}{response}");

                try
                {
                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        HRX_Response parsed = HRX_Response_Parser.Parse(response);
                        if (parsed.IsSuccess && parsed.Command == "GET_FORMAT_LIST")
                            UpdateFormatDropdowns(HRX_Response_Parser.ParseFormatList(response));
                    }
                }
                catch { }

                return response;
            }
            catch (Exception ex)
            {
                LogToTerminal($"Помилка відправки: {ex.Message}");
                return null;
            }
        }
    }
}
