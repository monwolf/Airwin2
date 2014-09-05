using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NativeWifi;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Diagnostics;
using AirWin;

namespace AirWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string URL = "http://www.bitsdelocos.es/donate.php";
        WifiAtackController cli;
    
        private void Form_Close(object sender, EventArgs e) {

            if (cli.IsBusy)
            {
                DialogResult resultDLG = MessageBox.Show("¿Se está ejecutando un ataque, desea guardarlo?", "Airwin", MessageBoxButtons.YesNo);
                if (resultDLG == DialogResult.Yes)
                {

                    try{
                        cli.saveAtack();
                    }
                    catch { MessageBox.Show("Error guardando progreso"); }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                cli = new WifiAtackController();
                comboBox1.Text = "Seleccione su tarjeta";
                foreach (string interfaz in cli.getInterfaceNames())
                {

                    comboBox1.Items.Add(interfaz);

                }

                if (comboBox1.Items.Count <= 0)
                {
                    btnScan.Enabled = false;
                    btnWardriving.Enabled = false;
                }

                //tbxResult.DataBindings.Add("Text", testBindingSource, "Key");
                cli.UnitChanged += cli_KeyChanged;
                cli.RunWorkerCompleted += this.bw_RunWorkerCompleted;
                cli.ProgressChanged += this.bw_ProgressChanged;
              
            }
            catch{
                
                MessageBox.Show("No se han podido obtener las interfaces wireless","Airwin");
            
            }

        }

        void cli_KeyChanged(object sender, EventArgs e)
        {
            UpdateTextBox((string)sender);
        }

        private void UpdateTextBox(string value) {
        
             if (this.tbxResult.InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateTextBox),new object[]{value});
                    
            }
            else
            {
                tbxResult.Text = value as string;
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool continuar = false;
            if (btnStart.Text == "Start")
            {
                if ( NativeWifi.WinApi.IsConnectedToInternet())
                {
                    MessageBox.Show("Está conectado a internet, esto puede dar falsos positivos. Por favor desconéctese e inténtelo de nuevo.","Airwin");
                }

                btnExport.Enabled = false;
                tbxResult.Enabled = true;
                tbxResult.Text = "";
                progressBar1.Enabled = true;
                lblInfo.Visible = false;
                tbxResult.Visible = false;
                lblProgress.Visible = true;
                progressBar1.Visible = true;
                timer1.Enabled = false;
                if (cli.isWlanSelected && !String.IsNullOrEmpty(txtNombreArchivo.Text))
                {
                    btnStart.Text = "Stop";
                    lblInfo.Text = "Probando:";
                    lblInfo.Visible = true;
                    if(cli.CanRestartAttac()){
                        DialogResult resultDLG = MessageBox.Show(" Se ha encontrado un ataque anterior salvado, desea continuarlo?", "Airwin", MessageBoxButtons.YesNo);
                        if (resultDLG == DialogResult.Yes) {
                            continuar = true;
                        }
                    }
                    cli.StartAttack(txtNombreArchivo.Text,continuar);
                }
                else
                {
               
                    MessageBox.Show(" Debes rellenar todos los campos", "Airwin");

                }
            }
            else { 
            
                //Guardar la informacion temporal en un archivo
                 DialogResult resultDLG = MessageBox.Show("¿Se está ejecutando un ataque, desea guardarlo?", "Airwin", MessageBoxButtons.YesNo);
                 if (resultDLG == DialogResult.Yes)
                 {
                    
                     try
                     {
                         cli.saveAtack();
                     }

                     catch { MessageBox.Show("Error guardando progreso."); }
                 }
                 btnStart.Text = "Start";

            }

        }
        private void actualizar()
        {

            WLanList.Clear();
            WLanList.Merge(cli.getWlanInfo());


        }
        private void scan_Click(object sender, EventArgs e)
        {
        

            if (comboBox1.SelectedItem!= null)
            {
                btnExport.Enabled = true;
                if (btnScan.Text == "Scan")
                {
                    btnScan.Text = "Stop";
                    lblInfo.Visible = false;
                    timer1.Enabled = true;
                    actualizar();
                }
                else
                {
                    btnScan.Text = "Scan";
                    timer1.Enabled = false;
                }
            }
            else {
                MessageBox.Show("Seleccione una interfaz de red", "Airwin",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
            }
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtNombreArchivo.Text = openFileDialog1.FileName;
            btnStart.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            actualizar();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(e.Link.LinkData.ToString());
            Process.Start(sInfo);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(URL);
            Process.Start(sInfo);

        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int interfaz = comboBox1.SelectedIndex;
            cli.setInterface(interfaz);

        }


        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnStart.Enabled = true;
            btnExport.Enabled = true;
            progressBar1.Visible = false;

            timer1.Enabled = false;
            btnScan.Text = "Scan";

            if (!cli.WorkerCancelled)
            {

                if (cli.isConnected)
                {
                    Thread.Sleep(1000);
                    lblInfo.Visible = true;
                    lblInfo.Text = "La clave es:";
                    tbxResult.Visible = true;                    
                    /** Guardar resultats despres d'un atac bo */
                    DialogResult resultDLG = MessageBox.Show("¿Desea guardar los resultados?", "Airwin", MessageBoxButtons.YesNo);
                    if (resultDLG == DialogResult.Yes)
                    {
                        cli.saveResults();
                    }

                }
                else tbxResult.Text = "No se encontro la clave";
            }
            else cli.WorkerCancelled = false;

            progressBar1.Value = 0;
            lblProgress.Visible = false;
            btnStart.Text = "Start";
            MessageBox.Show("La aplicación ha terminado. Recuerda que aunque sea una aplicación gratuita siempre viene bien una donación para mantener el software.", "Airwin",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            if (cli.WorkerFirstTime == false)
            {

                progressBar1.Maximum = (int)cli.MaxProgres;

            }
            tbxResult.Visible = true;
            progressBar1.Step = 1;
            progressBar1.PerformStep();


        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {

            SaveFileDialog X = new SaveFileDialog();
            X.OverwritePrompt = true;
                      
            X.AddExtension=true;
            X.DefaultExt=".xml";
            X.Filter = "Comma Separated Values|*.csv | XML  file|*.xml ";
            X.ShowDialog(); 

            if (X.FileName != "")
            {
                cli.exportWlanInfo(X.FileName);
            }
        }

        private void grdWlans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!cli.IsBusy)
            {
                DataRowView currentDataRowView = (DataRowView)grdWlans.CurrentRow.DataBoundItem;
                DataSets.WlanInfo.WLANSRow row = currentDataRowView.Row as DataSets.WlanInfo.WLANSRow;
                cli.SelectedWlan =(DataSets.WlanInfo.WLANSRow) row.Table.NewRow();
                cli.SelectedWlan.ItemArray = (object[])row.ItemArray.Clone();

                if (cli.SelectedWlan != null)
                {
                    btnStart.Enabled = true;
                }
                txtEssid.Text = row.ESSID;
            }
        }

        private void numericDelay_ValueChanged(object sender, EventArgs e)
        {
            cli.delay = Convert.ToInt32(numericDelay.Value);
        }

        private void ShowWardriving() {

            using (WarDrivingcs fromWard = new WarDrivingcs()) {

                fromWard.cli = this.cli;
                fromWard.ShowDialog();
                
            }
        
        }

        private void btnWardriving_Click(object sender, EventArgs e)
        {
            ShowWardriving();
        }
    }
}