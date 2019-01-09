using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Stratego.Connection.Networks
{
    static class ConnectionNetworks
    {

        #region Prop



        #endregion

        #region Functions

        /// <summary>
        /// Send to the Server the update data after the register of the client.
        /// </summary>
        /// <param name="serverDatatable"></param>
        public static void UpdateServer(DataTable serverDatatable)
        {

        }

        /// <summary>
        /// Receive from the Server the update data on the clients, call on first upload of the client, and call at any time we need update data.
        /// </summary>
        /// <returns></returns>
        public static DataTable UpdateClient()
        {
            return new DataTable();
        }


        #endregion


    }
}
