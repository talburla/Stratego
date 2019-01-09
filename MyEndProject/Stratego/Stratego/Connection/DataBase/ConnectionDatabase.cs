using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Stratego.Connection.DataBase
{
    static class ConnectionDatabase
    {
        #region Prop

        // The connection datebase.
        static public DataTable TheDataTable = new DataTable();

        #endregion

        #region Function

        /// <summary>
        /// Update the client database.
        /// </summary>
        static public void UpdateDataBase()
        {
            try
            {
                ConnectionDatabase.TheDataTable.WriteXml(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]).ToString() + "\\UsersData.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception)
            {
                //MessageBox.Show("cant update the data base...");
            }
        }

        #endregion
    }
}
