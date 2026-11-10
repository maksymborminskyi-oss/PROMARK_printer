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
            this.label1.Location = new System.Drawing.Point(12, 16);
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
            this.button1.Location = new System.Drawing.Point(763, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Open_Settings);
            // 
            // terminal_tb
            // 
            this.terminal_tb.Location = new System.Drawing.Point(37, 50);
            this.terminal_tb.Multiline = true;
            this.terminal_tb.Name = "terminal_tb";
            this.terminal_tb.Size = new System.Drawing.Size(834, 473);
            this.terminal_tb.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Terminal";
            // 
            // conect_btn
            // 
            this.conect_btn.Location = new System.Drawing.Point(635, 10);
            this.conect_btn.Name = "conect_btn";
            this.conect_btn.Size = new System.Drawing.Size(107, 32);
            this.conect_btn.TabIndex = 7;
            this.conect_btn.Text = "Conected";
            this.conect_btn.UseVisualStyleBackColor = true;
            this.conect_btn.Click += new System.EventHandler(this.conect_btn_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 571);
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
    }
}

