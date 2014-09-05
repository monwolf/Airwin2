using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Device.Location;

namespace AirWin
{
    partial class WarDrivingcs
    {

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private DataSets.WlanInfo ds;
        private GeoCoordinateWatcher watcher;


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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.ds = new AirWin.DataSets.WlanInfo();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.scanningTimer = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.eSSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bSSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cipherDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.powerDbmDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cli = new AirWin.WifiAtackController();
            ((System.ComponentModel.ISupportInitialize)(this.ds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ds
            // 
            this.ds.DataSetName = "WlanInfo";
            this.ds.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.chart1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.chart1.BackSecondaryColor = System.Drawing.Color.White;
            this.chart1.BorderlineColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            this.chart1.BorderlineWidth = 0;
            chartArea1.Area3DStyle.Inclination = 15;
            chartArea1.Area3DStyle.IsClustered = true;
            chartArea1.Area3DStyle.IsRightAngleAxes = false;
            chartArea1.Area3DStyle.Perspective = 10;
            chartArea1.Area3DStyle.Rotation = 10;
            chartArea1.Area3DStyle.WallWidth = 0;
            chartArea1.AxisX.LabelAutoFitStyle = ((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)(((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) 
            | System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap)));
            chartArea1.AxisX.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisX.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisX.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea1.AxisX.ScrollBar.Size = 10D;
            chartArea1.AxisY.LabelStyle.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            chartArea1.AxisY.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.AxisY.ScrollBar.LineColor = System.Drawing.Color.Black;
            chartArea1.AxisY.ScrollBar.Size = 10D;
            chartArea1.BackColor = System.Drawing.Color.Gainsboro;
            chartArea1.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.TopBottom;
            chartArea1.BackSecondaryColor = System.Drawing.Color.White;
            chartArea1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            chartArea1.BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.CursorX.IsUserEnabled = true;
            chartArea1.CursorX.IsUserSelectionEnabled = true;
            chartArea1.CursorY.IsUserEnabled = true;
            chartArea1.CursorY.IsUserSelectionEnabled = true;
            chartArea1.Name = "Default";
            chartArea1.ShadowColor = System.Drawing.Color.Transparent;
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Bold);
            legend1.IsTextAutoFit = false;
            legend1.Name = "Default";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 145);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(712, 327);
            this.chart1.TabIndex = 0;
            title1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Bold);
            title1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(59)))), ((int)(((byte)(105)))));
            title1.Name = "Title1";
            title1.ShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            title1.ShadowOffset = 3;
            title1.Text = "Power(dBm)";
            this.chart1.Titles.Add(title1);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eSSIDDataGridViewTextBoxColumn,
            this.bSSIDDataGridViewTextBoxColumn,
            this.authDataGridViewTextBoxColumn,
            this.cipherDataGridViewTextBoxColumn,
            this.powerDbmDataGridViewTextBoxColumn});
            this.dataGridView1.DataMember = "WLANS";
            this.dataGridView1.DataSource = this.ds;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(544, 134);
            this.dataGridView1.TabIndex = 1;
            // 
            // scanningTimer
            // 
            this.scanningTimer.Interval = 1000;
            this.scanningTimer.Tick += new System.EventHandler(this.scanningTimer_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(562, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(94, 28);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "Start";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // eSSIDDataGridViewTextBoxColumn
            // 
            this.eSSIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.eSSIDDataGridViewTextBoxColumn.DataPropertyName = "ESSID";
            this.eSSIDDataGridViewTextBoxColumn.HeaderText = "ESSID";
            this.eSSIDDataGridViewTextBoxColumn.Name = "eSSIDDataGridViewTextBoxColumn";
            this.eSSIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bSSIDDataGridViewTextBoxColumn
            // 
            this.bSSIDDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bSSIDDataGridViewTextBoxColumn.DataPropertyName = "BSSID";
            this.bSSIDDataGridViewTextBoxColumn.HeaderText = "BSSID";
            this.bSSIDDataGridViewTextBoxColumn.Name = "bSSIDDataGridViewTextBoxColumn";
            this.bSSIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // authDataGridViewTextBoxColumn
            // 
            this.authDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.authDataGridViewTextBoxColumn.DataPropertyName = "Auth";
            this.authDataGridViewTextBoxColumn.HeaderText = "Auth";
            this.authDataGridViewTextBoxColumn.Name = "authDataGridViewTextBoxColumn";
            this.authDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cipherDataGridViewTextBoxColumn
            // 
            this.cipherDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.cipherDataGridViewTextBoxColumn.DataPropertyName = "Cipher";
            this.cipherDataGridViewTextBoxColumn.HeaderText = "Cipher";
            this.cipherDataGridViewTextBoxColumn.Name = "cipherDataGridViewTextBoxColumn";
            this.cipherDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // powerDbmDataGridViewTextBoxColumn
            // 
            this.powerDbmDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.powerDbmDataGridViewTextBoxColumn.DataPropertyName = "PowerDbm";
            this.powerDbmDataGridViewTextBoxColumn.HeaderText = "PowerDbm";
            this.powerDbmDataGridViewTextBoxColumn.Name = "powerDbmDataGridViewTextBoxColumn";
            this.powerDbmDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cli
            // 
            this.cli.continueAttack = false;
            this.cli.Key = null;
            this.cli.WorkerCancelled = false;
            this.cli.WorkerReportsProgress = true;
            this.cli.WorkerSupportsCancellation = true;
            // 
            // WarDrivingcs
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(712, 472);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.chart1);
            this.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "WarDrivingcs";
            this.Load += new System.EventHandler(this.WarDrivingcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal WifiAtackController cli;
        private DataGridView dataGridView1;
        private Timer scanningTimer;
        private Button btnStop;
        private DataGridViewTextBoxColumn eSSIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bSSIDDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn authDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cipherDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn powerDbmDataGridViewTextBoxColumn;

    }
}