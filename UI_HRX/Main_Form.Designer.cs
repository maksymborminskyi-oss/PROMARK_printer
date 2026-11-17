namespace UI_HRX.App
{
    partial class Main_Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.ip_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.port_tb = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.terminal_tb = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.conect_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.command_cb = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.format_tb = new System.Windows.Forms.ComboBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.clear_terminal_btn = new System.Windows.Forms.Button();
            this.params_gb = new System.Windows.Forms.GroupBox();
            this.lbl_no_params = new System.Windows.Forms.Label();
            this.pnl_format = new System.Windows.Forms.Panel();
            this.lbl_format_hint = new System.Windows.Forms.Label();
            this.pnl_status = new System.Windows.Forms.Panel();
            this.lbl_status_mode = new System.Windows.Forms.Label();
            this.printing_status_cb = new System.Windows.Forms.ComboBox();
            this.pnl_batch = new System.Windows.Forms.Panel();
            this.lbl_batch_format = new System.Windows.Forms.Label();
            this.batch_format_tb = new System.Windows.Forms.ComboBox();
            this.batch_load_vars_btn = new System.Windows.Forms.Button();
            this.batch_from_excel_btn = new System.Windows.Forms.Button();
            this.batch_add_var_btn = new System.Windows.Forms.Button();
            this.batch_clear_ui_btn = new System.Windows.Forms.Button();
            this.batch_clear_prn_btn = new System.Windows.Forms.Button();
            this.batch_vars_panel = new System.Windows.Forms.Panel();
            this.pnl_events = new System.Windows.Forms.Panel();
            this.lbl_events_ip = new System.Windows.Forms.Label();
            this.events_ip_tb = new System.Windows.Forms.TextBox();
            this.lbl_events_port = new System.Windows.Forms.Label();
            this.events_port_tb = new System.Windows.Forms.TextBox();
            this.events_status_chk = new System.Windows.Forms.CheckBox();
            this.pnl_format_vars = new System.Windows.Forms.Panel();
            this.lbl_fv_format = new System.Windows.Forms.Label();
            this.fv_format_tb = new System.Windows.Forms.ComboBox();
            this.fv_load_vars_btn = new System.Windows.Forms.Button();
            this.pnl_fv_options = new System.Windows.Forms.Panel();
            this.lbl_fv_qty = new System.Windows.Forms.Label();
            this.fv_quantity_nud = new System.Windows.Forms.NumericUpDown();
            this.fv_use_cache_chk = new System.Windows.Forms.CheckBox();
            this.lbl_fv_vars = new System.Windows.Forms.Label();
            this.fv_from_row_btn = new System.Windows.Forms.Button();
            this.fv_add_var_btn = new System.Windows.Forms.Button();
            this.fv_clear_vars_btn = new System.Windows.Forms.Button();
            this.fv_vars_panel = new System.Windows.Forms.Panel();
            this.pnl_print_config = new System.Windows.Forms.Panel();
            this.lbl_cfg_speed = new System.Windows.Forms.Label();
            this.cfg_speed_tb = new System.Windows.Forms.TextBox();
            this.lbl_cfg_delay = new System.Windows.Forms.Label();
            this.cfg_delay_tb = new System.Windows.Forms.TextBox();
            this.lbl_cfg_resolution = new System.Windows.Forms.Label();
            this.cfg_resolution_tb = new System.Windows.Forms.TextBox();
            this.lbl_cfg_trigger = new System.Windows.Forms.Label();
            this.cfg_trigger_cb = new System.Windows.Forms.ComboBox();
            this.lbl_cfg_trigger_every = new System.Windows.Forms.Label();
            this.cfg_trigger_every_tb = new System.Windows.Forms.TextBox();
            this.cfg_encoder_chk = new System.Windows.Forms.CheckBox();
            this.cfg_direction_chk = new System.Windows.Forms.CheckBox();
            this.cfg_rotation180_chk = new System.Windows.Forms.CheckBox();
            this.print_btn = new System.Windows.Forms.Button();
            this.pause_btn = new System.Windows.Forms.Button();
            this.right_split = new System.Windows.Forms.SplitContainer();
            this.load_excel_btn = new System.Windows.Forms.Button();
            this.excel_status_lbl = new System.Windows.Forms.Label();
            this.data_grid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.right_split)).BeginInit();
            this.right_split.Panel1.SuspendLayout();
            this.right_split.Panel2.SuspendLayout();
            this.right_split.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            this.params_gb.SuspendLayout();
            this.pnl_format.SuspendLayout();
            this.pnl_status.SuspendLayout();
            this.pnl_batch.SuspendLayout();
            this.pnl_events.SuspendLayout();
            this.pnl_format_vars.SuspendLayout();
            this.pnl_fv_options.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fv_quantity_nud)).BeginInit();
            this.pnl_print_config.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP";
            // 
            // ip_tb
            // 
            this.ip_tb.Location = new System.Drawing.Point(40, 12);
            this.ip_tb.Name = "ip_tb";
            this.ip_tb.Size = new System.Drawing.Size(240, 22);
            this.ip_tb.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(294, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // port_tb
            // 
            this.port_tb.Location = new System.Drawing.Point(332, 12);
            this.port_tb.Name = "port_tb";
            this.port_tb.Size = new System.Drawing.Size(90, 22);
            this.port_tb.TabIndex = 3;
            // 
            // conect_btn
            // 
            this.conect_btn.Location = new System.Drawing.Point(438, 8);
            this.conect_btn.Name = "conect_btn";
            this.conect_btn.Size = new System.Drawing.Size(110, 30);
            this.conect_btn.TabIndex = 4;
            this.conect_btn.Text = "Connect";
            this.conect_btn.UseVisualStyleBackColor = true;
            this.conect_btn.Click += new System.EventHandler(this.conect_btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(558, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Settings";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Open_Settings);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 16);
            this.label4.TabIndex = 6;
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
            "GET_EVENTS_CONFIG",
            "GET_COUNTER_LIST",
            "GET_VARIABLE_LIST",
            "QUEUE_STATUS",
            "QUEUE_ENABLE",
            "QUEUE_DISABLE",
            "QUEUE_CLEAR",
            "SET_PRINTING_STATUS",
            "SET_PRINTING_FORMAT",
            "SET_DATE_OFFSET",
            "SET_PRINT_CONFIG",
            "SET_EVENTS_CONFIG",
            "SET_VARIABLE_BATCH",
            "SET_VARIABLE_BATCH_CLEAR",
            "CMD_DELETE_FORMAT"});
            this.command_cb.Location = new System.Drawing.Point(12, 76);
            this.command_cb.MaxDropDownItems = 18;
            this.command_cb.Name = "command_cb";
            this.command_cb.Size = new System.Drawing.Size(320, 24);
            this.command_cb.TabIndex = 7;
            this.command_cb.SelectedIndexChanged += new System.EventHandler(this.command_cb_SelectedIndexChanged);
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(342, 73);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(110, 30);
            this.send_btn.TabIndex = 8;
            this.send_btn.Text = "Send";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
            // 
            // params_gb
            // 
            this.params_gb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.params_gb.Controls.Add(this.lbl_no_params);
            this.params_gb.Controls.Add(this.pnl_format);
            this.params_gb.Controls.Add(this.pnl_status);
            this.params_gb.Controls.Add(this.pnl_batch);
            this.params_gb.Controls.Add(this.pnl_events);
            this.params_gb.Controls.Add(this.pnl_format_vars);
            this.params_gb.Controls.Add(this.pnl_print_config);
            this.params_gb.Location = new System.Drawing.Point(12, 114);
            this.params_gb.Name = "params_gb";
            this.params_gb.Size = new System.Drawing.Size(440, 492);
            this.params_gb.TabIndex = 9;
            this.params_gb.TabStop = false;
            this.params_gb.Text = "Параметри команди";
            // 
            // lbl_no_params
            // 
            this.lbl_no_params.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_no_params.Location = new System.Drawing.Point(16, 30);
            this.lbl_no_params.Name = "lbl_no_params";
            this.lbl_no_params.Size = new System.Drawing.Size(358, 40);
            this.lbl_no_params.TabIndex = 0;
            this.lbl_no_params.Text = "Ця команда не потребує додаткових параметрів.";
            // 
            // pnl_format
            // 
            this.pnl_format.Controls.Add(this.label5);
            this.pnl_format.Controls.Add(this.format_tb);
            this.pnl_format.Controls.Add(this.lbl_format_hint);
            this.pnl_format.Location = new System.Drawing.Point(12, 24);
            this.pnl_format.Name = "pnl_format";
            this.pnl_format.Size = new System.Drawing.Size(366, 95);
            this.pnl_format.TabIndex = 1;
            this.pnl_format.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 8);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Format:";
            // 
            // format_tb
            // 
            this.format_tb.FormattingEnabled = true;
            this.format_tb.Location = new System.Drawing.Point(4, 28);
            this.format_tb.Name = "format_tb";
            this.format_tb.Size = new System.Drawing.Size(354, 24);
            this.format_tb.TabIndex = 1;
            // 
            // lbl_format_hint
            // 
            this.lbl_format_hint.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lbl_format_hint.Location = new System.Drawing.Point(4, 56);
            this.lbl_format_hint.Name = "lbl_format_hint";
            this.lbl_format_hint.Size = new System.Drawing.Size(354, 34);
            this.lbl_format_hint.TabIndex = 2;
            // 
            // pnl_status
            // 
            this.pnl_status.Controls.Add(this.lbl_status_mode);
            this.pnl_status.Controls.Add(this.printing_status_cb);
            this.pnl_status.Location = new System.Drawing.Point(12, 24);
            this.pnl_status.Name = "pnl_status";
            this.pnl_status.Size = new System.Drawing.Size(366, 80);
            this.pnl_status.TabIndex = 2;
            this.pnl_status.Visible = false;
            // 
            // lbl_status_mode
            // 
            this.lbl_status_mode.AutoSize = true;
            this.lbl_status_mode.Location = new System.Drawing.Point(4, 8);
            this.lbl_status_mode.Name = "lbl_status_mode";
            this.lbl_status_mode.Size = new System.Drawing.Size(166, 16);
            this.lbl_status_mode.TabIndex = 0;
            this.lbl_status_mode.Text = "Режим роботи принтера:";
            // 
            // printing_status_cb
            // 
            this.printing_status_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.printing_status_cb.FormattingEnabled = true;
            this.printing_status_cb.Items.AddRange(new object[] {
            "Yes (PRINT — друк)",
            "No (PAUSE — пауза)"});
            this.printing_status_cb.Location = new System.Drawing.Point(4, 28);
            this.printing_status_cb.Name = "printing_status_cb";
            this.printing_status_cb.Size = new System.Drawing.Size(240, 24);
            this.printing_status_cb.TabIndex = 1;
            // 
            // pnl_batch
            // 
            this.pnl_batch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_batch.Controls.Add(this.lbl_batch_format);
            this.pnl_batch.Controls.Add(this.batch_format_tb);
            this.pnl_batch.Controls.Add(this.batch_load_vars_btn);
            this.pnl_batch.Controls.Add(this.batch_from_excel_btn);
            this.pnl_batch.Controls.Add(this.batch_add_var_btn);
            this.pnl_batch.Controls.Add(this.batch_clear_ui_btn);
            this.pnl_batch.Controls.Add(this.batch_clear_prn_btn);
            this.pnl_batch.Controls.Add(this.batch_vars_panel);
            this.pnl_batch.Location = new System.Drawing.Point(12, 24);
            this.pnl_batch.Name = "pnl_batch";
            this.pnl_batch.Size = new System.Drawing.Size(416, 450);
            this.pnl_batch.TabIndex = 3;
            this.pnl_batch.Visible = false;
            // 
            // lbl_batch_format
            // 
            this.lbl_batch_format.AutoSize = true;
            this.lbl_batch_format.Location = new System.Drawing.Point(4, 6);
            this.lbl_batch_format.Name = "lbl_batch_format";
            this.lbl_batch_format.Size = new System.Drawing.Size(166, 16);
            this.lbl_batch_format.TabIndex = 0;
            this.lbl_batch_format.Text = "Назва формату (Format):";
            // 
            // batch_format_tb
            // 
            this.batch_format_tb.FormattingEnabled = true;
            this.batch_format_tb.Location = new System.Drawing.Point(4, 26);
            this.batch_format_tb.Name = "batch_format_tb";
            this.batch_format_tb.Size = new System.Drawing.Size(268, 24);
            this.batch_format_tb.TabIndex = 1;
            this.batch_format_tb.SelectionChangeCommitted += new System.EventHandler(this.batch_format_tb_SelectionChangeCommitted);
            // 
            // batch_load_vars_btn
            // 
            this.batch_load_vars_btn.Location = new System.Drawing.Point(278, 24);
            this.batch_load_vars_btn.Name = "batch_load_vars_btn";
            this.batch_load_vars_btn.Size = new System.Drawing.Size(134, 26);
            this.batch_load_vars_btn.TabIndex = 2;
            this.batch_load_vars_btn.Text = "Змінні формату";
            this.batch_load_vars_btn.UseVisualStyleBackColor = true;
            this.batch_load_vars_btn.Click += new System.EventHandler(this.batch_load_vars_btn_Click);
            // 
            // batch_from_excel_btn
            // 
            this.batch_from_excel_btn.Location = new System.Drawing.Point(4, 58);
            this.batch_from_excel_btn.Name = "batch_from_excel_btn";
            this.batch_from_excel_btn.Size = new System.Drawing.Size(112, 26);
            this.batch_from_excel_btn.TabIndex = 3;
            this.batch_from_excel_btn.Text = "Усі з Excel";
            this.batch_from_excel_btn.UseVisualStyleBackColor = true;
            this.batch_from_excel_btn.Click += new System.EventHandler(this.batch_from_excel_btn_Click);
            // 
            // batch_add_var_btn
            // 
            this.batch_add_var_btn.Location = new System.Drawing.Point(122, 58);
            this.batch_add_var_btn.Name = "batch_add_var_btn";
            this.batch_add_var_btn.Size = new System.Drawing.Size(94, 26);
            this.batch_add_var_btn.TabIndex = 4;
            this.batch_add_var_btn.Text = "+ Змінна";
            this.batch_add_var_btn.UseVisualStyleBackColor = true;
            this.batch_add_var_btn.Click += new System.EventHandler(this.batch_add_var_btn_Click);
            // 
            // batch_clear_ui_btn
            // 
            this.batch_clear_ui_btn.Location = new System.Drawing.Point(222, 58);
            this.batch_clear_ui_btn.Name = "batch_clear_ui_btn";
            this.batch_clear_ui_btn.Size = new System.Drawing.Size(92, 26);
            this.batch_clear_ui_btn.TabIndex = 5;
            this.batch_clear_ui_btn.Text = "Очистити";
            this.batch_clear_ui_btn.UseVisualStyleBackColor = true;
            this.batch_clear_ui_btn.Click += new System.EventHandler(this.batch_clear_ui_btn_Click);
            // 
            // batch_clear_prn_btn
            // 
            this.batch_clear_prn_btn.Location = new System.Drawing.Point(320, 58);
            this.batch_clear_prn_btn.Name = "batch_clear_prn_btn";
            this.batch_clear_prn_btn.Size = new System.Drawing.Size(92, 26);
            this.batch_clear_prn_btn.TabIndex = 6;
            this.batch_clear_prn_btn.Text = "Clear PRN";
            this.batch_clear_prn_btn.UseVisualStyleBackColor = true;
            this.batch_clear_prn_btn.Click += new System.EventHandler(this.batch_clear_prn_btn_Click);
            // 
            // batch_vars_panel
            // 
            this.batch_vars_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.batch_vars_panel.AutoScroll = true;
            this.batch_vars_panel.BackColor = System.Drawing.SystemColors.Window;
            this.batch_vars_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.batch_vars_panel.Location = new System.Drawing.Point(4, 92);
            this.batch_vars_panel.Name = "batch_vars_panel";
            this.batch_vars_panel.Size = new System.Drawing.Size(408, 350);
            this.batch_vars_panel.TabIndex = 7;
            // 
            // pnl_events
            // 
            this.pnl_events.Controls.Add(this.lbl_events_ip);
            this.pnl_events.Controls.Add(this.events_ip_tb);
            this.pnl_events.Controls.Add(this.lbl_events_port);
            this.pnl_events.Controls.Add(this.events_port_tb);
            this.pnl_events.Controls.Add(this.events_status_chk);
            this.pnl_events.Location = new System.Drawing.Point(12, 24);
            this.pnl_events.Name = "pnl_events";
            this.pnl_events.Size = new System.Drawing.Size(366, 155);
            this.pnl_events.TabIndex = 4;
            this.pnl_events.Visible = false;
            // 
            // lbl_events_ip
            // 
            this.lbl_events_ip.AutoSize = true;
            this.lbl_events_ip.Location = new System.Drawing.Point(4, 8);
            this.lbl_events_ip.Name = "lbl_events_ip";
            this.lbl_events_ip.Size = new System.Drawing.Size(108, 16);
            this.lbl_events_ip.TabIndex = 0;
            this.lbl_events_ip.Text = "UDP IP-адреса:";
            // 
            // events_ip_tb
            // 
            this.events_ip_tb.Location = new System.Drawing.Point(4, 28);
            this.events_ip_tb.Name = "events_ip_tb";
            this.events_ip_tb.Size = new System.Drawing.Size(220, 22);
            this.events_ip_tb.TabIndex = 1;
            // 
            // lbl_events_port
            // 
            this.lbl_events_port.AutoSize = true;
            this.lbl_events_port.Location = new System.Drawing.Point(4, 60);
            this.lbl_events_port.Name = "lbl_events_port";
            this.lbl_events_port.Size = new System.Drawing.Size(74, 16);
            this.lbl_events_port.TabIndex = 2;
            this.lbl_events_port.Text = "UDP Порт:";
            // 
            // events_port_tb
            // 
            this.events_port_tb.Location = new System.Drawing.Point(4, 80);
            this.events_port_tb.Name = "events_port_tb";
            this.events_port_tb.Size = new System.Drawing.Size(120, 22);
            this.events_port_tb.TabIndex = 3;
            // 
            // events_status_chk
            // 
            this.events_status_chk.AutoSize = true;
            this.events_status_chk.Checked = true;
            this.events_status_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.events_status_chk.Location = new System.Drawing.Point(4, 114);
            this.events_status_chk.Name = "events_status_chk";
            this.events_status_chk.Size = new System.Drawing.Size(268, 20);
            this.events_status_chk.TabIndex = 4;
            this.events_status_chk.Text = "Увімкнути надсилання подій (True)";
            this.events_status_chk.UseVisualStyleBackColor = true;
            // 
            // pnl_format_vars
            // 
            this.pnl_format_vars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnl_format_vars.Controls.Add(this.lbl_fv_format);
            this.pnl_format_vars.Controls.Add(this.fv_format_tb);
            this.pnl_format_vars.Controls.Add(this.fv_load_vars_btn);
            this.pnl_format_vars.Controls.Add(this.pnl_fv_options);
            this.pnl_format_vars.Controls.Add(this.lbl_fv_vars);
            this.pnl_format_vars.Controls.Add(this.fv_from_row_btn);
            this.pnl_format_vars.Controls.Add(this.fv_add_var_btn);
            this.pnl_format_vars.Controls.Add(this.fv_clear_vars_btn);
            this.pnl_format_vars.Controls.Add(this.fv_vars_panel);
            this.pnl_format_vars.Location = new System.Drawing.Point(12, 24);
            this.pnl_format_vars.Name = "pnl_format_vars";
            this.pnl_format_vars.Size = new System.Drawing.Size(416, 450);
            this.pnl_format_vars.TabIndex = 5;
            this.pnl_format_vars.Visible = false;
            // 
            // lbl_fv_format
            // 
            this.lbl_fv_format.AutoSize = true;
            this.lbl_fv_format.Location = new System.Drawing.Point(4, 6);
            this.lbl_fv_format.Name = "lbl_fv_format";
            this.lbl_fv_format.Size = new System.Drawing.Size(166, 16);
            this.lbl_fv_format.TabIndex = 0;
            this.lbl_fv_format.Text = "Назва формату (Format):";
            // 
            // fv_format_tb
            // 
            this.fv_format_tb.FormattingEnabled = true;
            this.fv_format_tb.Location = new System.Drawing.Point(4, 26);
            this.fv_format_tb.Name = "fv_format_tb";
            this.fv_format_tb.Size = new System.Drawing.Size(268, 24);
            this.fv_format_tb.TabIndex = 1;
            this.fv_format_tb.SelectionChangeCommitted += new System.EventHandler(this.fv_format_tb_SelectionChangeCommitted);
            // 
            // fv_load_vars_btn
            // 
            this.fv_load_vars_btn.Location = new System.Drawing.Point(278, 24);
            this.fv_load_vars_btn.Name = "fv_load_vars_btn";
            this.fv_load_vars_btn.Size = new System.Drawing.Size(134, 26);
            this.fv_load_vars_btn.TabIndex = 2;
            this.fv_load_vars_btn.Text = "Змінні формату";
            this.fv_load_vars_btn.UseVisualStyleBackColor = true;
            this.fv_load_vars_btn.Click += new System.EventHandler(this.fv_load_vars_btn_Click);
            // 
            // pnl_fv_options
            // 
            this.pnl_fv_options.Controls.Add(this.lbl_fv_qty);
            this.pnl_fv_options.Controls.Add(this.fv_quantity_nud);
            this.pnl_fv_options.Controls.Add(this.fv_use_cache_chk);
            this.pnl_fv_options.Location = new System.Drawing.Point(0, 54);
            this.pnl_fv_options.Name = "pnl_fv_options";
            this.pnl_fv_options.Size = new System.Drawing.Size(416, 52);
            this.pnl_fv_options.TabIndex = 3;
            // 
            // lbl_fv_qty
            // 
            this.lbl_fv_qty.AutoSize = true;
            this.lbl_fv_qty.Location = new System.Drawing.Point(4, 6);
            this.lbl_fv_qty.Name = "lbl_fv_qty";
            this.lbl_fv_qty.Size = new System.Drawing.Size(163, 16);
            this.lbl_fv_qty.TabIndex = 0;
            this.lbl_fv_qty.Text = "Quantity (0 = без паузи):";
            // 
            // fv_quantity_nud
            // 
            this.fv_quantity_nud.Location = new System.Drawing.Point(176, 4);
            this.fv_quantity_nud.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.fv_quantity_nud.Name = "fv_quantity_nud";
            this.fv_quantity_nud.Size = new System.Drawing.Size(90, 22);
            this.fv_quantity_nud.TabIndex = 1;
            // 
            // fv_use_cache_chk
            // 
            this.fv_use_cache_chk.AutoSize = true;
            this.fv_use_cache_chk.Location = new System.Drawing.Point(4, 28);
            this.fv_use_cache_chk.Name = "fv_use_cache_chk";
            this.fv_use_cache_chk.Size = new System.Drawing.Size(262, 20);
            this.fv_use_cache_chk.TabIndex = 2;
            this.fv_use_cache_chk.Text = "Використовувати кеш (useCache = true)";
            this.fv_use_cache_chk.UseVisualStyleBackColor = true;
            // 
            // lbl_fv_vars
            // 
            this.lbl_fv_vars.AutoSize = true;
            this.lbl_fv_vars.Location = new System.Drawing.Point(4, 110);
            this.lbl_fv_vars.Name = "lbl_fv_vars";
            this.lbl_fv_vars.Size = new System.Drawing.Size(296, 16);
            this.lbl_fv_vars.TabIndex = 4;
            this.lbl_fv_vars.Text = "Змінні (введіть значення або оберіть з Excel):";
            // 
            // fv_from_row_btn
            // 
            this.fv_from_row_btn.Location = new System.Drawing.Point(4, 130);
            this.fv_from_row_btn.Name = "fv_from_row_btn";
            this.fv_from_row_btn.Size = new System.Drawing.Size(140, 26);
            this.fv_from_row_btn.TabIndex = 5;
            this.fv_from_row_btn.Text = "Рядок з Excel";
            this.fv_from_row_btn.UseVisualStyleBackColor = true;
            this.fv_from_row_btn.Click += new System.EventHandler(this.fv_from_row_btn_Click);
            // 
            // fv_add_var_btn
            // 
            this.fv_add_var_btn.Location = new System.Drawing.Point(150, 130);
            this.fv_add_var_btn.Name = "fv_add_var_btn";
            this.fv_add_var_btn.Size = new System.Drawing.Size(134, 26);
            this.fv_add_var_btn.TabIndex = 6;
            this.fv_add_var_btn.Text = "+ Додати змінну";
            this.fv_add_var_btn.UseVisualStyleBackColor = true;
            this.fv_add_var_btn.Click += new System.EventHandler(this.fv_add_var_btn_Click);
            // 
            // fv_clear_vars_btn
            // 
            this.fv_clear_vars_btn.Location = new System.Drawing.Point(290, 130);
            this.fv_clear_vars_btn.Name = "fv_clear_vars_btn";
            this.fv_clear_vars_btn.Size = new System.Drawing.Size(122, 26);
            this.fv_clear_vars_btn.TabIndex = 7;
            this.fv_clear_vars_btn.Text = "Очистити";
            this.fv_clear_vars_btn.UseVisualStyleBackColor = true;
            this.fv_clear_vars_btn.Click += new System.EventHandler(this.fv_clear_vars_btn_Click);
            // 
            // fv_vars_panel
            // 
            this.fv_vars_panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fv_vars_panel.AutoScroll = true;
            this.fv_vars_panel.BackColor = System.Drawing.SystemColors.Window;
            this.fv_vars_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fv_vars_panel.Location = new System.Drawing.Point(4, 162);
            this.fv_vars_panel.Name = "fv_vars_panel";
            this.fv_vars_panel.Size = new System.Drawing.Size(408, 280);
            this.fv_vars_panel.TabIndex = 8;
            // 
            // pnl_print_config
            // 
            this.pnl_print_config.Controls.Add(this.lbl_cfg_speed);
            this.pnl_print_config.Controls.Add(this.cfg_speed_tb);
            this.pnl_print_config.Controls.Add(this.lbl_cfg_delay);
            this.pnl_print_config.Controls.Add(this.cfg_delay_tb);
            this.pnl_print_config.Controls.Add(this.lbl_cfg_resolution);
            this.pnl_print_config.Controls.Add(this.cfg_resolution_tb);
            this.pnl_print_config.Controls.Add(this.lbl_cfg_trigger);
            this.pnl_print_config.Controls.Add(this.cfg_trigger_cb);
            this.pnl_print_config.Controls.Add(this.lbl_cfg_trigger_every);
            this.pnl_print_config.Controls.Add(this.cfg_trigger_every_tb);
            this.pnl_print_config.Controls.Add(this.cfg_encoder_chk);
            this.pnl_print_config.Controls.Add(this.cfg_direction_chk);
            this.pnl_print_config.Controls.Add(this.cfg_rotation180_chk);
            this.pnl_print_config.Location = new System.Drawing.Point(12, 24);
            this.pnl_print_config.Name = "pnl_print_config";
            this.pnl_print_config.Size = new System.Drawing.Size(366, 270);
            this.pnl_print_config.TabIndex = 6;
            this.pnl_print_config.Visible = false;
            // 
            // lbl_cfg_speed
            // 
            this.lbl_cfg_speed.AutoSize = true;
            this.lbl_cfg_speed.Location = new System.Drawing.Point(4, 10);
            this.lbl_cfg_speed.Name = "lbl_cfg_speed";
            this.lbl_cfg_speed.Size = new System.Drawing.Size(52, 16);
            this.lbl_cfg_speed.TabIndex = 0;
            this.lbl_cfg_speed.Text = "Speed:";
            // 
            // cfg_speed_tb
            // 
            this.cfg_speed_tb.Location = new System.Drawing.Point(145, 8);
            this.cfg_speed_tb.Name = "cfg_speed_tb";
            this.cfg_speed_tb.Size = new System.Drawing.Size(110, 22);
            this.cfg_speed_tb.TabIndex = 1;
            this.cfg_speed_tb.Text = "30";
            // 
            // lbl_cfg_delay
            // 
            this.lbl_cfg_delay.AutoSize = true;
            this.lbl_cfg_delay.Location = new System.Drawing.Point(4, 40);
            this.lbl_cfg_delay.Name = "lbl_cfg_delay";
            this.lbl_cfg_delay.Size = new System.Drawing.Size(47, 16);
            this.lbl_cfg_delay.TabIndex = 2;
            this.lbl_cfg_delay.Text = "Delay:";
            // 
            // cfg_delay_tb
            // 
            this.cfg_delay_tb.Location = new System.Drawing.Point(145, 38);
            this.cfg_delay_tb.Name = "cfg_delay_tb";
            this.cfg_delay_tb.Size = new System.Drawing.Size(110, 22);
            this.cfg_delay_tb.TabIndex = 3;
            this.cfg_delay_tb.Text = "10";
            // 
            // lbl_cfg_resolution
            // 
            this.lbl_cfg_resolution.AutoSize = true;
            this.lbl_cfg_resolution.Location = new System.Drawing.Point(4, 70);
            this.lbl_cfg_resolution.Name = "lbl_cfg_resolution";
            this.lbl_cfg_resolution.Size = new System.Drawing.Size(114, 16);
            this.lbl_cfg_resolution.TabIndex = 4;
            this.lbl_cfg_resolution.Text = "Resolution (DPI):";
            // 
            // cfg_resolution_tb
            // 
            this.cfg_resolution_tb.Location = new System.Drawing.Point(145, 68);
            this.cfg_resolution_tb.Name = "cfg_resolution_tb";
            this.cfg_resolution_tb.Size = new System.Drawing.Size(110, 22);
            this.cfg_resolution_tb.TabIndex = 5;
            this.cfg_resolution_tb.Text = "300";
            // 
            // lbl_cfg_trigger
            // 
            this.lbl_cfg_trigger.AutoSize = true;
            this.lbl_cfg_trigger.Location = new System.Drawing.Point(4, 100);
            this.lbl_cfg_trigger.Name = "lbl_cfg_trigger";
            this.lbl_cfg_trigger.Size = new System.Drawing.Size(55, 16);
            this.lbl_cfg_trigger.TabIndex = 6;
            this.lbl_cfg_trigger.Text = "Trigger:";
            // 
            // cfg_trigger_cb
            // 
            this.cfg_trigger_cb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cfg_trigger_cb.FormattingEnabled = true;
            this.cfg_trigger_cb.Items.AddRange(new object[] {
            "Photocell",
            "Distance",
            "Timer"});
            this.cfg_trigger_cb.Location = new System.Drawing.Point(145, 98);
            this.cfg_trigger_cb.Name = "cfg_trigger_cb";
            this.cfg_trigger_cb.Size = new System.Drawing.Size(140, 24);
            this.cfg_trigger_cb.TabIndex = 7;
            // 
            // lbl_cfg_trigger_every
            // 
            this.lbl_cfg_trigger_every.AutoSize = true;
            this.lbl_cfg_trigger_every.Location = new System.Drawing.Point(4, 132);
            this.lbl_cfg_trigger_every.Name = "lbl_cfg_trigger_every";
            this.lbl_cfg_trigger_every.Size = new System.Drawing.Size(94, 16);
            this.lbl_cfg_trigger_every.TabIndex = 8;
            this.lbl_cfg_trigger_every.Text = "Trigger Every:";
            // 
            // cfg_trigger_every_tb
            // 
            this.cfg_trigger_every_tb.Location = new System.Drawing.Point(145, 130);
            this.cfg_trigger_every_tb.Name = "cfg_trigger_every_tb";
            this.cfg_trigger_every_tb.Size = new System.Drawing.Size(110, 22);
            this.cfg_trigger_every_tb.TabIndex = 9;
            this.cfg_trigger_every_tb.Text = "0";
            // 
            // cfg_encoder_chk
            // 
            this.cfg_encoder_chk.AutoSize = true;
            this.cfg_encoder_chk.Location = new System.Drawing.Point(4, 168);
            this.cfg_encoder_chk.Name = "cfg_encoder_chk";
            this.cfg_encoder_chk.Size = new System.Drawing.Size(262, 20);
            this.cfg_encoder_chk.TabIndex = 10;
            this.cfg_encoder_chk.Text = "Encoder увімкнено (ENCODER = TRUE)";
            this.cfg_encoder_chk.UseVisualStyleBackColor = true;
            // 
            // cfg_direction_chk
            // 
            this.cfg_direction_chk.AutoSize = true;
            this.cfg_direction_chk.Checked = true;
            this.cfg_direction_chk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cfg_direction_chk.Location = new System.Drawing.Point(4, 196);
            this.cfg_direction_chk.Name = "cfg_direction_chk";
            this.cfg_direction_chk.Size = new System.Drawing.Size(293, 20);
            this.cfg_direction_chk.TabIndex = 11;
            this.cfg_direction_chk.Text = "Напрямок Left -> Right (DIRECTION = TRUE)";
            this.cfg_direction_chk.UseVisualStyleBackColor = true;
            // 
            // cfg_rotation180_chk
            // 
            this.cfg_rotation180_chk.AutoSize = true;
            this.cfg_rotation180_chk.Location = new System.Drawing.Point(4, 224);
            this.cfg_rotation180_chk.Name = "cfg_rotation180_chk";
            this.cfg_rotation180_chk.Size = new System.Drawing.Size(277, 20);
            this.cfg_rotation180_chk.TabIndex = 12;
            this.cfg_rotation180_chk.Text = "Поворот на 180° (ROTATION_180 = TRUE)";
            this.cfg_rotation180_chk.UseVisualStyleBackColor = true;
            // 
            // right_split
            // 
            this.right_split.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.right_split.Location = new System.Drawing.Point(464, 48);
            this.right_split.Name = "right_split";
            this.right_split.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.right_split.Panel1.Controls.Add(this.label3);
            this.right_split.Panel1.Controls.Add(this.clear_terminal_btn);
            this.right_split.Panel1.Controls.Add(this.terminal_tb);
            this.right_split.Panel2.Controls.Add(this.load_excel_btn);
            this.right_split.Panel2.Controls.Add(this.excel_status_lbl);
            this.right_split.Panel2.Controls.Add(this.data_grid);
            this.right_split.Size = new System.Drawing.Size(584, 558);
            this.right_split.SplitterDistance = 280;
            this.right_split.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Terminal";
            // 
            // clear_terminal_btn
            // 
            this.clear_terminal_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.clear_terminal_btn.Location = new System.Drawing.Point(476, 2);
            this.clear_terminal_btn.Name = "clear_terminal_btn";
            this.clear_terminal_btn.Size = new System.Drawing.Size(108, 28);
            this.clear_terminal_btn.TabIndex = 11;
            this.clear_terminal_btn.Text = "Clear Log";
            this.clear_terminal_btn.UseVisualStyleBackColor = true;
            this.clear_terminal_btn.Click += new System.EventHandler(this.clear_terminal_btn_Click);
            // 
            // terminal_tb
            // 
            this.terminal_tb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.terminal_tb.BackColor = System.Drawing.SystemColors.Window;
            this.terminal_tb.DetectUrls = false;
            this.terminal_tb.Font = new System.Drawing.Font("Consolas", 9.5F);
            this.terminal_tb.Location = new System.Drawing.Point(0, 34);
            this.terminal_tb.Name = "terminal_tb";
            this.terminal_tb.ReadOnly = true;
            this.terminal_tb.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Both;
            this.terminal_tb.Size = new System.Drawing.Size(584, 244);
            this.terminal_tb.TabIndex = 12;
            this.terminal_tb.WordWrap = false;
            // 
            // load_excel_btn
            // 
            this.load_excel_btn.Location = new System.Drawing.Point(0, 4);
            this.load_excel_btn.Name = "load_excel_btn";
            this.load_excel_btn.Size = new System.Drawing.Size(160, 28);
            this.load_excel_btn.TabIndex = 0;
            this.load_excel_btn.Text = "Завантажити Excel...";
            this.load_excel_btn.UseVisualStyleBackColor = true;
            this.load_excel_btn.Click += new System.EventHandler(this.load_excel_btn_Click);
            // 
            // excel_status_lbl
            // 
            this.excel_status_lbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.excel_status_lbl.ForeColor = System.Drawing.SystemColors.GrayText;
            this.excel_status_lbl.Location = new System.Drawing.Point(168, 10);
            this.excel_status_lbl.Name = "excel_status_lbl";
            this.excel_status_lbl.Size = new System.Drawing.Size(412, 18);
            this.excel_status_lbl.TabIndex = 1;
            this.excel_status_lbl.Text = "Excel-файл не завантажено";
            // 
            // data_grid
            // 
            this.data_grid.AllowUserToAddRows = false;
            this.data_grid.AllowUserToDeleteRows = false;
            this.data_grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.data_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Location = new System.Drawing.Point(0, 38);
            this.data_grid.MultiSelect = false;
            this.data_grid.Name = "data_grid";
            this.data_grid.ReadOnly = true;
            this.data_grid.RowHeadersWidth = 42;
            this.data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_grid.Size = new System.Drawing.Size(584, 234);
            this.data_grid.TabIndex = 2;
            this.data_grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_grid_CellDoubleClick);
            // 
            // print_btn
            // 
            this.print_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.print_btn.Location = new System.Drawing.Point(818, 8);
            this.print_btn.Name = "print_btn";
            this.print_btn.Size = new System.Drawing.Size(110, 30);
            this.print_btn.TabIndex = 13;
            this.print_btn.Text = "Друк";
            this.print_btn.UseVisualStyleBackColor = true;
            this.print_btn.Click += new System.EventHandler(this.print_btn_Click);
            // 
            // pause_btn
            // 
            this.pause_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pause_btn.Location = new System.Drawing.Point(938, 8);
            this.pause_btn.Name = "pause_btn";
            this.pause_btn.Size = new System.Drawing.Size(110, 30);
            this.pause_btn.TabIndex = 14;
            this.pause_btn.Text = "Пауза";
            this.pause_btn.UseVisualStyleBackColor = true;
            this.pause_btn.Click += new System.EventHandler(this.pause_btn_Click);
            // 
            // Main_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 620);
            this.Controls.Add(this.pause_btn);
            this.Controls.Add(this.print_btn);
            this.Controls.Add(this.right_split);
            this.Controls.Add(this.params_gb);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.command_cb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.conect_btn);
            this.Controls.Add(this.port_tb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ip_tb);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(900, 540);
            this.Name = "Main_Form";
            this.Text = "HRX XML Protocol Tester";
            this.right_split.Panel1.ResumeLayout(false);
            this.right_split.Panel1.PerformLayout();
            this.right_split.Panel2.ResumeLayout(false);
            this.right_split.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.right_split)).EndInit();
            this.right_split.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            this.params_gb.ResumeLayout(false);
            this.pnl_format.ResumeLayout(false);
            this.pnl_format.PerformLayout();
            this.pnl_status.ResumeLayout(false);
            this.pnl_status.PerformLayout();
            this.pnl_batch.ResumeLayout(false);
            this.pnl_batch.PerformLayout();
            this.pnl_events.ResumeLayout(false);
            this.pnl_events.PerformLayout();
            this.pnl_format_vars.ResumeLayout(false);
            this.pnl_format_vars.PerformLayout();
            this.pnl_fv_options.ResumeLayout(false);
            this.pnl_fv_options.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fv_quantity_nud)).EndInit();
            this.pnl_print_config.ResumeLayout(false);
            this.pnl_print_config.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox ip_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox port_tb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox terminal_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button conect_btn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox command_cb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox format_tb;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Button clear_terminal_btn;
        private System.Windows.Forms.GroupBox params_gb;
        private System.Windows.Forms.Label lbl_no_params;
        private System.Windows.Forms.Panel pnl_format;
        private System.Windows.Forms.Label lbl_format_hint;
        private System.Windows.Forms.Panel pnl_status;
        private System.Windows.Forms.Label lbl_status_mode;
        private System.Windows.Forms.ComboBox printing_status_cb;
        private System.Windows.Forms.Panel pnl_batch;
        private System.Windows.Forms.Label lbl_batch_format;
        private System.Windows.Forms.ComboBox batch_format_tb;
        private System.Windows.Forms.Button batch_load_vars_btn;
        private System.Windows.Forms.Button batch_from_excel_btn;
        private System.Windows.Forms.Button batch_add_var_btn;
        private System.Windows.Forms.Button batch_clear_ui_btn;
        private System.Windows.Forms.Button batch_clear_prn_btn;
        private System.Windows.Forms.Panel batch_vars_panel;
        private System.Windows.Forms.Panel pnl_events;
        private System.Windows.Forms.Label lbl_events_ip;
        private System.Windows.Forms.TextBox events_ip_tb;
        private System.Windows.Forms.Label lbl_events_port;
        private System.Windows.Forms.TextBox events_port_tb;
        private System.Windows.Forms.CheckBox events_status_chk;
        private System.Windows.Forms.Panel pnl_format_vars;
        private System.Windows.Forms.Label lbl_fv_format;
        private System.Windows.Forms.ComboBox fv_format_tb;
        private System.Windows.Forms.Button fv_load_vars_btn;
        private System.Windows.Forms.Panel pnl_fv_options;
        private System.Windows.Forms.Label lbl_fv_qty;
        private System.Windows.Forms.NumericUpDown fv_quantity_nud;
        private System.Windows.Forms.CheckBox fv_use_cache_chk;
        private System.Windows.Forms.Label lbl_fv_vars;
        private System.Windows.Forms.Button fv_from_row_btn;
        private System.Windows.Forms.Button fv_add_var_btn;
        private System.Windows.Forms.Button fv_clear_vars_btn;
        private System.Windows.Forms.Panel fv_vars_panel;
        private System.Windows.Forms.Panel pnl_print_config;
        private System.Windows.Forms.Label lbl_cfg_speed;
        private System.Windows.Forms.TextBox cfg_speed_tb;
        private System.Windows.Forms.Label lbl_cfg_delay;
        private System.Windows.Forms.TextBox cfg_delay_tb;
        private System.Windows.Forms.Label lbl_cfg_resolution;
        private System.Windows.Forms.TextBox cfg_resolution_tb;
        private System.Windows.Forms.Label lbl_cfg_trigger;
        private System.Windows.Forms.ComboBox cfg_trigger_cb;
        private System.Windows.Forms.Label lbl_cfg_trigger_every;
        private System.Windows.Forms.TextBox cfg_trigger_every_tb;
        private System.Windows.Forms.CheckBox cfg_encoder_chk;
        private System.Windows.Forms.CheckBox cfg_direction_chk;
        private System.Windows.Forms.CheckBox cfg_rotation180_chk;
        private System.Windows.Forms.Button print_btn;
        private System.Windows.Forms.Button pause_btn;
        private System.Windows.Forms.SplitContainer right_split;
        private System.Windows.Forms.Button load_excel_btn;
        private System.Windows.Forms.Label excel_status_lbl;
        private System.Windows.Forms.DataGridView data_grid;
    }
}
