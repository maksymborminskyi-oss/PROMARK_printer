using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UI_HRX
{
    public class Printer_Client_Settings
    {
        private TcpClient tcpClient;
        private NetworkStream networkStream;

        public Printer_Settings Settings { get; set; } = new Printer_Settings();

        public bool IsConnected => tcpClient != null && tcpClient.Connected;

        public Printer_Client_Settings()
        {
            Settings = Printer_Settings.Load();
        }

        public async Task<bool> ConnectAsync(string ip, int port)
        {
            Disconnect();

            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync(IPAddress.Parse(ip), port);
            networkStream = tcpClient.GetStream();

            return IsConnected;
        }

        public void Disconnect()
        {
            try
            {
                networkStream?.Close();
                tcpClient?.Close();
            }
            catch
            {
                // Ігноруємо помилки при закритті з'єднання
            }
            finally
            {
                networkStream = null;
                tcpClient = null;
            }
        }

        public async Task<string> SendAsync(HRX_Command_Builder command)
        {
            if (!IsConnected || networkStream == null)
            {
                throw new InvalidOperationException("Немає активного підключення до принтера.");
            }

            string commandText = command.Get_Command();
            byte[] textBytes = Encoding.UTF8.GetBytes(commandText);
            byte[] packet = new byte[textBytes.Length + 8];

            packet[0] = 0x27;
            packet[1] = 0x01;
            packet[2] = 0x27;
            packet[3] = 0x02;

            Array.Copy(textBytes, 0, packet, 4, textBytes.Length);

            packet[packet.Length - 4] = 0x27;
            packet[packet.Length - 3] = 0x03;
            packet[packet.Length - 2] = 0x27;
            packet[packet.Length - 1] = 0x04;

            await networkStream.WriteAsync(packet, 0, packet.Length);

            byte[] responseBuffer = new byte[4096];
            int bytesRead = await networkStream.ReadAsync(responseBuffer, 0, responseBuffer.Length);

            if (bytesRead > 0)
            {
                return Encoding.UTF8.GetString(responseBuffer, 0, bytesRead);
            }

            return string.Empty;
        }

        public async Task<bool> Savesettings_json()
        {
            Settings.Save();
            return await Task.FromResult(true);
        }
    }
}
