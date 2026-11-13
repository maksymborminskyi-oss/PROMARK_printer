namespace UI_HRX
{
    partial class Form_Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.save_btn = new System.Windows.Forms.Button();
            this.cancel_btn = new System.Windows.Forms.Button();
            this.groupBoxNetwork = new System.Windows.Forms.GroupBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.labelIp = new System.Windows.Forms.Label();
            this.groupBoxTarget = new System.Windows.Forms.GroupBox();
            this.tbPhName = new System.Windows.Forms.TextBox();
            this.cbPhName = new System.Windows.Forms.CheckBox();
            this.tbPhIndex = new System.Windows.Forms.TextBox();
            this.cbPhIndex = new System.Windows.Forms.CheckBox();
            this.tbBoardId = new System.Windows.Forms.TextBox();
            this.cbBoardId = new System.Windows.Forms.CheckBox();
            this.groupBoxNetwork.SuspendLayout();
            this.groupBoxTarget.SuspendLayout();
            this.SuspendLayout();
            // 
            // save_btn
            // 
            this.save_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_btn.Location = new System.Drawing.Point(310, 310);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(120, 34);
            this.save_btn.TabIndex = 2;
            this.save_btn.Text = "Зберегти";
            this.save_btn.UseVisualStyleBackColor = true;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // cancel_btn
            // 
            this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cancel_btn.Location = new System.Drawing.Point(440, 310);
            this.cancel_btn.Name = "cancel_btn";
            this.cancel_btn.Size = new System.Drawing.Size(120, 34);
            this.cancel_btn.TabIndex = 3;
            this.cancel_btn.Text = "Скасувати";
            this.cancel_btn.UseVisualStyleBackColor = true;
            this.cancel_btn.Click += new System.EventHandler(this.cancel_btn_Click);
            // 
            // groupBoxNetwork
            // 
            this.groupBoxNetwork.Controls.Add(this.tbPort);
            this.groupBoxNetwork.Controls.Add(this.labelPort);
            this.groupBoxNetwork.Controls.Add(this.tbIp);
            this.groupBoxNetwork.Controls.Add(this.labelIp);
            this.groupBoxNetwork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxNetwork.Location = new System.Drawing.Point(20, 16);
            this.groupBoxNetwork.Name = "groupBoxNetwork";
            this.groupBoxNetwork.Size = new System.Drawing.Size(540, 100);
            this.groupBoxNetwork.TabIndex = 0;
            this.groupBoxNetwork.TabStop = false;
            this.groupBoxNetwork.Text = "Мережа за замовчуванням";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(375, 42);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(130, 24);
            this.tbPort.TabIndex = 3;
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(325, 45);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(44, 18);
            this.labelPort.TabIndex = 2;
            this.labelPort.Text = "Порт:";
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(100, 42);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(200, 24);
            this.tbIp.TabIndex = 1;
            // 
            // labelIp
            // 
            this.labelIp.AutoSize = true;
            this.labelIp.Location = new System.Drawing.Point(15, 45);
            this.labelIp.Name = "labelIp";
            this.labelIp.Size = new System.Drawing.Size(79, 18);
            this.labelIp.TabIndex = 0;
            this.labelIp.Text = "IP-адреса:";
            // 
            // groupBoxTarget
            // 
            this.groupBoxTarget.Controls.Add(this.tbPhName);
            this.groupBoxTarget.Controls.Add(this.cbPhName);
            this.groupBoxTarget.Controls.Add(this.tbPhIndex);
            this.groupBoxTarget.Controls.Add(this.cbPhIndex);
            this.groupBoxTarget.Controls.Add(this.tbBoardId);
            this.groupBoxTarget.Controls.Add(this.cbBoardId);
            this.groupBoxTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxTarget.Location = new System.Drawing.Point(20, 130);
            this.groupBoxTarget.Name = "groupBoxTarget";
            this.groupBoxTarget.Size = new System.Drawing.Size(540, 160);
            this.groupBoxTarget.TabIndex = 1;
            this.groupBoxTarget.TabStop = false;
            this.groupBoxTarget.Text = "Ідентифікатор друкуючої головки (Target)";
            // 
            // tbPhName
            // 
            this.tbPhName.Location = new System.Drawing.Point(180, 115);
            this.tbPhName.Name = "tbPhName";
            this.tbPhName.Size = new System.Drawing.Size(325, 24);
            this.tbPhName.TabIndex = 5;
            // 
            // cbPhName
            // 
            this.cbPhName.AutoSize = true;
            this.cbPhName.Location = new System.Drawing.Point(18, 117);
            this.cbPhName.Name = "cbPhName";
            this.cbPhName.Size = new System.Drawing.Size(95, 22);
            this.cbPhName.TabIndex = 4;
            this.cbPhName.Text = "PH Name";
            this.cbPhName.UseVisualStyleBackColor = true;
            this.cbPhName.CheckedChanged += new System.EventHandler(this.TargetCheckBox_CheckedChanged);
            // 
            // tbPhIndex
            // 
            this.tbPhIndex.Location = new System.Drawing.Point(180, 75);
            this.tbPhIndex.Name = "tbPhIndex";
            this.tbPhIndex.Size = new System.Drawing.Size(325, 24);
            this.tbPhIndex.TabIndex = 3;
            // 
            // cbPhIndex
            // 
            this.cbPhIndex.AutoSize = true;
            this.cbPhIndex.Location = new System.Drawing.Point(18, 77);
            this.cbPhIndex.Name = "cbPhIndex";
            this.cbPhIndex.Size = new System.Drawing.Size(89, 22);
            this.cbPhIndex.TabIndex = 2;
            this.cbPhIndex.Text = "PH Index";
            this.cbPhIndex.UseVisualStyleBackColor = true;
            this.cbPhIndex.CheckedChanged += new System.EventHandler(this.TargetCheckBox_CheckedChanged);
            // 
            // tbBoardId
            // 
            this.tbBoardId.Location = new System.Drawing.Point(180, 35);
            this.tbBoardId.Name = "tbBoardId";
            this.tbBoardId.Size = new System.Drawing.Size(325, 24);
            this.tbBoardId.TabIndex = 1;
            // 
            // cbBoardId
            // 
            this.cbBoardId.AutoSize = true;
            this.cbBoardId.Location = new System.Drawing.Point(18, 37);
            this.cbBoardId.Name = "cbBoardId";
            this.cbBoardId.Size = new System.Drawing.Size(88, 22);
            this.cbBoardId.TabIndex = 0;
            this.cbBoardId.Text = "Board ID";
            this.cbBoardId.UseVisualStyleBackColor = true;
            this.cbBoardId.CheckedChanged += new System.EventHandler(this.TargetCheckBox_CheckedChanged);
            // 
            // Form_Setting
            // 
            this.AcceptButton = this.save_btn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel_btn;
            this.ClientSize = new System.Drawing.Size(582, 365);
            this.Controls.Add(this.groupBoxTarget);
            this.Controls.Add(this.groupBoxNetwork);
            this.Controls.Add(this.cancel_btn);
            this.Controls.Add(this.save_btn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Налаштування принтера";
            this.Load += new System.EventHandler(this.Form_Setting_Load);
            this.groupBoxNetwork.ResumeLayout(false);
            this.groupBoxNetwork.PerformLayout();
            this.groupBoxTarget.ResumeLayout(false);
            this.groupBoxTarget.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.Button cancel_btn;
        private System.Windows.Forms.GroupBox groupBoxNetwork;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.Label labelIp;
        private System.Windows.Forms.GroupBox groupBoxTarget;
        private System.Windows.Forms.TextBox tbPhName;
        private System.Windows.Forms.CheckBox cbPhName;
        private System.Windows.Forms.TextBox tbPhIndex;
        private System.Windows.Forms.CheckBox cbPhIndex;
        private System.Windows.Forms.TextBox tbBoardId;
        private System.Windows.Forms.CheckBox cbBoardId;
    }
}
