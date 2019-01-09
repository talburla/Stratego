using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace RummiKub
{
    static class StaticVariables
    {
        // The most update datatable.
        static public DataTable TheDataTable = new DataTable();

        static public int currentId;

        static public void UpdateDataBase()
        {
            try
            {
                StaticVariables.TheDataTable.WriteXml(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString() + "\\UsersData.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception)
            {
                MessageBox.Show("cant update the data base...");
            }
        }
    }
}
