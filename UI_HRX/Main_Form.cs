using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI_HRX.App
{
    public partial class Main_Form : Form
    {

        public Main_Form()
        {
            InitializeComponent();
        }

        private void Open_Settings(object sender, EventArgs e)
        {   
            Form_Setting form_Setting = new Form_Setting();
            form_Setting.ShowDialog();
        }

        private void conect_btn_Click(object sender, EventArgs e)
        {
            // взать поля ip_tb и port_tb
            // проверить наличие данных в полях > Exeption
            // сделать парсинг (проверить отвечает ли IP и порт)
            // сформировать сообщение в терминал.
        }
    }
}
