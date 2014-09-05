using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace AirWin
{
    class Utils
    {


        public static long CountLinesInFile(string f)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }

            }
            return count;
        }

        //TRANSFORMAR CADENA DE BYTES EN UN STRING HEXA

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}:", b);

            string ret = hex.ToString().ToUpper();

            return ret.Remove(ret.Length - 1);
        }
        public static DataTable SelectDistinct(DataTable table,string[] columns)
        {

            DataView view = new DataView(table);
            return view.ToTable(true, columns);
        }
    }
}
