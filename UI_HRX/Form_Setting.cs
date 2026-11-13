using System;
using System.Windows.Forms;

namespace UI_HRX
{
    public partial class Form_Setting : Form
    {
        private bool isUpdatingCheckboxes = false;

        public Form_Setting()
        {
            InitializeComponent();
        }

        private void Form_Setting_Load(object sender, EventArgs e)
        {
            LoadSettingsToUI();
        }

        private void LoadSettingsToUI()
        {
            var settings = Printer_Settings.Load();

            tbIp.Text = settings.IP;
            tbPort.Text = settings.Port.ToString();

            isUpdatingCheckboxes = true;
            cbBoardId.Checked = settings.Board_Id;
            cbPhIndex.Checked = settings.PH_Index;
            cbPhName.Checked = settings.PH_Name;
            isUpdatingCheckboxes = false;

            tbBoardId.Text = settings.Board_Id_text;
            tbPhIndex.Text = settings.PH_Index_text;
            tbPhName.Text = settings.PH_Name_text;

            UpdateTextBoxStates();
        }

        private void TargetCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isUpdatingCheckboxes) return;

            CheckBox changed = sender as CheckBox;
            if (changed == null) return;

            isUpdatingCheckboxes = true;

            if (changed.Checked)
            {
                // Дозволяємо лише один вибраний варіант
                if (changed == cbBoardId)
                {
                    cbPhIndex.Checked = false;
                    cbPhName.Checked = false;
                }
                else if (changed == cbPhIndex)
                {
                    cbBoardId.Checked = false;
                    cbPhName.Checked = false;
                }
                else if (changed == cbPhName)
                {
                    cbBoardId.Checked = false;
                    cbPhIndex.Checked = false;
                }
            }
            else
            {
                // Не дозволяємо зняти всі прапорці, хоча б один має бути обраний
                if (!cbBoardId.Checked && !cbPhIndex.Checked && !cbPhName.Checked)
                {
                    changed.Checked = true;
                }
            }

            isUpdatingCheckboxes = false;
            UpdateTextBoxStates();
        }

        private void UpdateTextBoxStates()
        {
            tbBoardId.Enabled = cbBoardId.Checked;
            tbPhIndex.Enabled = cbPhIndex.Checked;
            tbPhName.Enabled = cbPhName.Checked;
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            int.TryParse(tbPort.Text.Trim(), out int port);

            var settings = new Printer_Settings
            {
                IP = tbIp.Text.Trim(),
                Port = port,
                Board_Id = cbBoardId.Checked,
                PH_Index = cbPhIndex.Checked,
                PH_Name = cbPhName.Checked,
                Board_Id_text = tbBoardId.Text.Trim(),
                PH_Index_text = tbPhIndex.Text.Trim(),
                PH_Name_text = tbPhName.Text.Trim()
            };

            if (!settings.Validate(out string error))
            {
                MessageBox.Show(error, "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                settings.Save();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка збереження: {ex.Message}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
