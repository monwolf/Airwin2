namespace AirWin
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnScan = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblDiccionario = new System.Windows.Forms.Label();
            this.txtNombreArchivo = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblRed = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.numericDelay = new System.Windows.Forms.NumericUpDown();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnExplorar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblInfo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblInterfaces = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.tbxResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEssid = new System.Windows.Forms.TextBox();
            this.grdWlans = new System.Windows.Forms.DataGridView();
            this.eSSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cipherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerDbmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WLanList = new AirWin.DataSets.WlanInfo();
            this.btnWardriving = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWlans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WLanList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(326, 12);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 2;
            this.btnScan.Text = "Scan";
            this.btnScan.UseVisualStyleBackColor = true;
            this.btnScan.Click += new System.EventHandler(this.scan_Click);
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(407, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblDiccionario
            // 
            this.lblDiccionario.AutoSize = true;
            this.lblDiccionario.Location = new System.Drawing.Point(240, 324);
            this.lblDiccionario.Name = "lblDiccionario";
            this.lblDiccionario.Size = new System.Drawing.Size(60, 13);
            this.lblDiccionario.TabIndex = 6;
            this.lblDiccionario.Text = "Diccionario";
            // 
            // txtNombreArchivo
            // 
            this.txtNombreArchivo.Location = new System.Drawing.Point(301, 322);
            this.txtNombreArchivo.Name = "txtNombreArchivo";
            this.txtNombreArchivo.Size = new System.Drawing.Size(100, 20);
            this.txtNombreArchivo.TabIndex = 7;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(248, 84);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(233, 23);
            this.progressBar1.TabIndex = 8;
            this.progressBar1.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(245, 68);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(52, 13);
            this.lblProgress.TabIndex = 9;
            this.lblProgress.Text = "Progreso:";
            this.lblProgress.Visible = false;
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(12, 94);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(102, 13);
            this.lblRed.TabIndex = 10;
            this.lblRed.Text = "Seleccione una red:";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(90, 323);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(57, 13);
            this.lblDelay.TabIndex = 11;
            this.lblDelay.Text = "Delay(seg)";
            // 
            // numericDelay
            // 
            this.numericDelay.Location = new System.Drawing.Point(155, 323);
            this.numericDelay.Name = "numericDelay";
            this.numericDelay.Size = new System.Drawing.Size(79, 20);
            this.numericDelay.TabIndex = 12;
            this.numericDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericDelay.ValueChanged += new System.EventHandler(this.numericDelay_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "diccionario.txt";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnExplorar
            // 
            this.btnExplorar.Location = new System.Drawing.Point(407, 322);
            this.btnExplorar.Name = "btnExplorar";
            this.btnExplorar.Size = new System.Drawing.Size(55, 23);
            this.btnExplorar.TabIndex = 14;
            this.btnExplorar.Text = "Explorar";
            this.btnExplorar.UseVisualStyleBackColor = true;
            this.btnExplorar.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(91, 351);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(65, 13);
            this.lblInfo.TabIndex = 15;
            this.lblInfo.Text = "La clave es:";
            this.lblInfo.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = global::AirWin.Properties.Resources.Donate;
            this.pictureBox1.Image = global::AirWin.Properties.Resources.Donate;
            this.pictureBox1.InitialImage = global::AirWin.Properties.Resources.Donate;
            this.pictureBox1.Location = new System.Drawing.Point(343, 348);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 27);
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblInterfaces
            // 
            this.lblInterfaces.AutoSize = true;
            this.lblInterfaces.Location = new System.Drawing.Point(9, 17);
            this.lblInterfaces.Name = "lblInterfaces";
            this.lblInterfaces.Size = new System.Drawing.Size(147, 13);
            this.lblInterfaces.TabIndex = 18;
            this.lblInterfaces.Text = "Seleccione su interfaz de red:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(15, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(255, 21);
            this.comboBox1.TabIndex = 19;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(407, 41);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "Exportar";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tbxResult
            // 
            this.tbxResult.Enabled = false;
            this.tbxResult.Location = new System.Drawing.Point(162, 348);
            this.tbxResult.Name = "tbxResult";
            this.tbxResult.Size = new System.Drawing.Size(138, 20);
            this.tbxResult.TabIndex = 21;
            this.tbxResult.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "ESSID";
            // 
            // txtEssid
            // 
            this.txtEssid.Enabled = false;
            this.txtEssid.Location = new System.Drawing.Point(57, 69);
            this.txtEssid.Name = "txtEssid";
            this.txtEssid.Size = new System.Drawing.Size(125, 20);
            this.txtEssid.TabIndex = 23;
            // 
            // grdWlans
            // 
            this.grdWlans.AllowUserToAddRows = false;
            this.grdWlans.AllowUserToDeleteRows = false;
            this.grdWlans.AllowUserToOrderColumns = true;
            this.grdWlans.AllowUserToResizeRows = false;
            this.grdWlans.AutoGenerateColumns = false;
            this.grdWlans.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdWlans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWlans.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eSSIDDataGridViewTextBoxColumn,
            this.bSSIDDataGridViewTextBoxColumn,
            this.authDataGridViewTextBoxColumn,
            this.cipherDataGridViewTextBoxColumn,
            this.powerDbmDataGridViewTextBoxColumn});
            this.grdWlans.DataMember = "WLANS";
            this.grdWlans.DataSource = this.WLanList;
            this.grdWlans.Location = new System.Drawing.Point(12, 113);
            this.grdWlans.MultiSelect = false;
            this.grdWlans.Name = "grdWlans";
            this.grdWlans.ReadOnly = true;
            this.grdWlans.Size = new System.Drawing.Size(469, 196);
            this.grdWlans.TabIndex = 24;
            this.grdWlans.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdWlans_CellContentClick);
            // 
            // eSSIDDataGridViewTextBoxColumn
            // 
            this.eSSIDDataGridViewTextBoxColumn.DataPropertyName = "ESSID";
            this.eSSIDDataGridViewTextBoxColumn.HeaderText = "ESSID";
            this.eSSIDDataGridViewTextBoxColumn.Name = "eSSIDDataGridViewTextBoxColumn";
            this.eSSIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bSSIDDataGridViewTextBoxColumn
            // 
            this.bSSIDDataGridViewTextBoxColumn.DataPropertyName = "BSSID";
            this.bSSIDDataGridViewTextBoxColumn.HeaderText = "BSSID";
            this.bSSIDDataGridViewTextBoxColumn.Name = "bSSIDDataGridViewTextBoxColumn";
            this.bSSIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // authDataGridViewTextBoxColumn
            // 
            this.authDataGridViewTextBoxColumn.DataPropertyName = "Auth";
            this.authDataGridViewTextBoxColumn.HeaderText = "Auth";
            this.authDataGridViewTextBoxColumn.Name = "authDataGridViewTextBoxColumn";
            this.authDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cipherDataGridViewTextBoxColumn
            // 
            this.cipherDataGridViewTextBoxColumn.DataPropertyName = "Cipher";
            this.cipherDataGridViewTextBoxColumn.HeaderText = "Cipher";
            this.cipherDataGridViewTextBoxColumn.Name = "cipherDataGridViewTextBoxColumn";
            this.cipherDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // powerDbmDataGridViewTextBoxColumn
            // 
            this.powerDbmDataGridViewTextBoxColumn.DataPropertyName = "PowerDbm";
            this.powerDbmDataGridViewTextBoxColumn.HeaderText = "PowerDbm";
            this.powerDbmDataGridViewTextBoxColumn.Name = "powerDbmDataGridViewTextBoxColumn";
            this.powerDbmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // WLanList
            // 
            this.WLanList.DataSetName = "WlanInfo";
            this.WLanList.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnWardriving
            // 
            this.btnWardriving.Location = new System.Drawing.Point(326, 41);
            this.btnWardriving.Name = "btnWardriving";
            this.btnWardriving.Size = new System.Drawing.Size(75, 23);
            this.btnWardriving.TabIndex = 25;
            this.btnWardriving.Text = "WarDriving";
            this.btnWardriving.UseVisualStyleBackColor = true;
            this.btnWardriving.Click += new System.EventHandler(this.btnWardriving_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 387);
            this.Controls.Add(this.btnWardriving);
            this.Controls.Add(this.grdWlans);
            this.Controls.Add(this.txtEssid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxResult);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblInterfaces);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnExplorar);
            this.Controls.Add(this.numericDelay);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txtNombreArchivo);
            this.Controls.Add(this.lblDiccionario);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnScan);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Airwin2";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Close);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericDelay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdWlans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WLanList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblDiccionario;
        private System.Windows.Forms.TextBox txtNombreArchivo;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblDelay;
        private System.Windows.Forms.NumericUpDown numericDelay;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnExplorar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblInterfaces;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox tbxResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEssid;
        private System.Windows.Forms.DataGridView grdWlans;
        private DataSets.WlanInfo WLanList;
        private System.Windows.Forms.DataGridViewTextBoxColumn eSSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bSSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn authDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cipherDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn powerDbmDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnWardriving;
    }
}

