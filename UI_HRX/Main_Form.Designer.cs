namespace UI_HRX.App
{
    partial class Main_Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.ip_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.port_tb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.terminal_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.conect_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.command_cb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.format_tb = new System.Windows.Forms.TextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.clear_terminal_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip_tb
            // 
            this.ip_tb.Location = new System.Drawing.Point(37, 10);
            this.ip_tb.Name = "ip_tb";
            this.ip_tb.Size = new System.Drawing.Size(376, 22);
            this.ip_tb.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(435, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // port_tb
            // 
            this.port_tb.Location = new System.Drawing.Point(472, 10);
            this.port_tb.Name = "port_tb";
            this.port_tb.Size = new System.Drawing.Size(138, 22);
            this.port_tb.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(763, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Open_Settings);
            // 
            // terminal_tb
            // 
            this.terminal_tb.Location = new System.Drawing.Point(37, 112);
            this.terminal_tb.Multiline = true;
            this.terminal_tb.Name = "terminal_tb";
            this.terminal_tb.ReadOnly = true;
            this.terminal_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.terminal_tb.Size = new System.Drawing.Size(834, 420);
            this.terminal_tb.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Terminal";
            // 
            // conect_btn
            // 
            this.conect_btn.Location = new System.Drawing.Point(635, 8);
            this.conect_btn.Name = "conect_btn";
            this.conect_btn.Size = new System.Drawing.Size(107, 30);
            this.conect_btn.TabIndex = 4;
            this.conect_btn.Text = "Connect";
            this.conect_btn.UseVisualStyleBackColor = true;
            this.conect_btn.Click += new System.EventHandler(this.conect_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Command";
            // 
            // command_cb
            // 
            this.command_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.command_cb.FormattingEnabled = true;
            this.command_cb.Items.AddRange(new object[] {
            "GET_PRINTER_INFO",
            "GET_PRINTING_STATUS",
            "GET_PRINTING_FORMAT",
            "GET_PRINTING_VARIABLES",
            "GET_FORMAT_LIST",
            "GET_FONT_LIST",
            "GET_ERROR_LIST",
            "GET_COUNTER",
            "GET_PRINT_CONFIG",
            "GET_VERSIONS",
            "GET_VARIABLE_BATCH_COUNT",
            "QUEUE_STATUS",
            "GET_COUNTER_LIST",
            "GET_VARIABLE_LIST"});
            this.command_cb.Location = new System.Drawing.Point(110, 52);
            this.command_cb.Name = "command_cb";
            this.command_cb.Size = new System.Drawing.Size(270, 24);
            this.command_cb.TabIndex = 6;
            this.command_cb.SelectedIndexChanged += new System.EventHandler(this.command_cb_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Format";
            // 
            // format_tb
            // 
            this.format_tb.Enabled = false;
            this.format_tb.Location = new System.Drawing.Point(456, 52);
            this.format_tb.Name = "format_tb";
            this.format_tb.Size = new System.Drawing.Size(154, 22);
            this.format_tb.TabIndex = 7;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(635, 48);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(107, 30);
            this.send_btn.TabIndex = 8;
            this.send_btn.Text = "Send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // clear_terminal_btn
            // 
            this.clear_terminal_btn.Location = new System.Drawing.Point(763, 48);
            this.clear_terminal_btn.Name = "clear_terminal_btn";
            this.clear_terminal_btn.Size = new System.Drawing.Size(108, 30);
            this.clear_terminal_btn.TabIndex = 13;
            this.clear_terminal_btn.Text = "Clear Log";
            this.clear_terminal_btn.UseVisualStyleBackColor = true;
            this.clear_terminal_btn.Click += new System.EventHandler(this.clear_terminal_btn_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 571);
            this.Controls.Add(this.clear_terminal_btn);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.format_tb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.command_cb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.conect_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.terminal_tb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.port_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ip_tb);
            this.Name = "Main_Form";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox port_tb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox terminal_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button conect_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox command_cb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox format_tb;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Button clear_terminal_btn;
    }
}
