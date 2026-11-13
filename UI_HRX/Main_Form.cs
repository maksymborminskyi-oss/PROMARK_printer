using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_HRX.App
{
    public partial class Main_Form : Form
    {
        private Printer_Client_Settings printerClient = new Printer_Client_Settings();

        public Main_Form()
        {
            InitializeComponent();
            LoadSettingsToUI();
            if (command_cb.Items.Count > 0)
            {
                command_cb.SelectedIndex = 0;
            }
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
            // Якщо вже підключені — відключаємось при натисканні кнопки
            if (printerClient.IsConnected)
            {
                printerClient.Disconnect();
                conect_btn.Text = "Connect";
                ip_tb.Enabled = true;
                port_tb.Enabled = true;
                LogToTerminal("Відключено від принтера.");
                return;
            }

            // взать поля ip_tb и port_tb
            // проверить наличие данных в полях > Exeption
            // сделать парсинг (проверить отвечает ли IP и порт)
            // сформировать сообщение в терминал.
            try
            {
                string ipText = ip_tb.Text.Trim();
                string portText = port_tb.Text.Trim();

                if (string.IsNullOrWhiteSpace(ipText) || string.IsNullOrWhiteSpace(portText))
                {
                    throw new ArgumentException("Поля IP та Port не можуть бути порожніми.");
                }

                if (ipText.Split('.').Length != 4 || !IPAddress.TryParse(ipText, out IPAddress ipAddress))
                {
                    throw new FormatException($"Некоректний формат IP-адреси: '{ipText}'.");
                }

                if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
                {
                    throw new FormatException($"Некоректний порт: '{portText}'. Допустимий діапазон: 1–65535.");
                }

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

        private void LogToTerminal(string message)
        {
            terminal_tb.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
        }

        private void command_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = command_cb.SelectedItem?.ToString();
            format_tb.Enabled = selected == "GET_COUNTER_LIST" || selected == "GET_VARIABLE_LIST";
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

                var simpleCommands = new Dictionary<string, Action<HRX_Command_Builder>>
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
                    ["QUEUE_STATUS"] = b => b.Add_Queue_Status(),
                };

                if (simpleCommands.TryGetValue(selected, out var addAction))
                {
                    addAction(builder);
                }
                else if (selected == "GET_COUNTER_LIST")
                {
                    builder.Get_counter_List(format_tb.Text);
                }
                else if (selected == "GET_VARIABLE_LIST")
                {
                    builder.Add_Variable_List(format_tb.Text);
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

        public async Task SendCommand(HRX_Command_Builder builder) 
        {
            try
            {
                string cmdText = builder.Get_Command();
                LogToTerminal($"TX:{Environment.NewLine}{cmdText}");
                string response = await printerClient.SendAsync(builder);
                builder.AddHistory(cmdText);
                LogToTerminal($"RX:{Environment.NewLine}{response}");
            }
            catch (Exception ex)
            {
                LogToTerminal($"Помилка відправки: {ex.Message}");
            }
        }
    }
}
