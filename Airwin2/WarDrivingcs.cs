using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Device.Location;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace AirWin
{
    public partial class WarDrivingcs : Form
    {
        private bool GeoWatcherEnabled = false;
        decimal MaxPower = Decimal.MinValue;
        decimal MinPower=Decimal.MaxValue;
        public WarDrivingcs()
        {
            InitializeComponent();
            //scanningTimer.Enabled = true;
            watcher = new GeoCoordinateWatcher();
//            this.dataGridView1.Sort(powerDbmDataGridViewTextBoxColumn, ListSortDirection.Descending);




            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisY.ScaleView.Zoomable = false;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;


        }
        double xValue=0;

        private void scanningTimer_Tick(object sender, EventArgs e)
        
        {
            ds.AcceptChanges();
            ds.BeginInit();
            DataSets.WlanInfo tmp =cli.getWlanInfo();            
            ds.WLANS.Load(tmp.WLANS.CreateDataReader(), LoadOption.OverwriteChanges);
            ds.EndInit();
            foreach (DataSets.WlanInfo.WLANSRow row in tmp.WLANS.Rows) {
                DataSets.WlanInfo.WARDRIVINGRow newRow =  ds.WARDRIVING.NewWARDRIVINGRow();
                newRow.BSSID = row.BSSID;
                newRow.PowerDbm = row.PowerDbm;
                newRow.TimeStamp = DateTime.Now;
                if (GeoWatcherEnabled && watcher.Position.Location.IsUnknown != true)
                {
                    newRow.Latitud = watcher.Position.Location.Latitude;
                    newRow.Longitud = watcher.Position.Location.Longitude;
                }
                else
                {
                    newRow.Latitud = 0;
                    newRow.Longitud = 0;
                }
                
                ds.WARDRIVING.AddWARDRIVINGRow(newRow);

               string bssid = row.BSSID;
               Series serie=chart1.Series.FindByName(bssid);

               if (serie==null) {
                   serie = new Series(bssid);
                   serie.Legend = "Default";
                   serie.LegendText = bssid;
                   serie.ChartType=SeriesChartType.FastLine;
                   chart1.Series.Add(serie);
               }
               chart1.Series[bssid].Points.AddXY(xValue,row.PowerDbm);
               MaxPower = Math.Max(MaxPower, row.PowerDbm);
               MinPower = Math.Min(MinPower, row.PowerDbm);


               chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(MaxPower)+5;
               chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(MinPower)-5;
            
            }

       xValue++;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (btnStop.Text == "Start")
            {
                btnStop.Text = "Stop";
                scanningTimer.Enabled = true;
            }
            else
            {
                btnStop.Text = "Start";
                scanningTimer.Enabled = false;
            }
        }

        private void WarDrivingcs_Load(object sender, EventArgs e)
        {
            GeoWatcherEnabled = watcher.TryStart(false, // Do not suppress permissions prompt.
   TimeSpan.FromMilliseconds(10000)); // Wait 10s to start.


            ds.AcceptChanges();
            ds.BeginInit();
            DataSets.WlanInfo tmp = cli.getWlanInfo();
            ds.WLANS.Load(tmp.WLANS.CreateDataReader(), LoadOption.OverwriteChanges);
            ds.EndInit();
        }


    }
}
