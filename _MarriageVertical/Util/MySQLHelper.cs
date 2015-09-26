using log4net;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace _MarriageVertical.Util
{
    public static class MySQLHelper
    {
        static ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        #region Execute SQL Script and return the dataTable
        /// <summary>
        /// Execute SQL Script and get the DataTable
        /// </summary>
        /// <param name="strSQL">SQL Script</param>
        /// <param name="parms">
        /// The parameters for the SQL command. Each "parameter" should be given as a pair of actual C# parameter where the first one
        /// should be the SQL variable name and the second one is the value for such variable.
        /// </param>
        /// <returns>DataTable</returns>
        public static DataSet ExecuMySQLRDataTable(string strSQL, string DBSource, params object[] parms)
        {
            if (string.IsNullOrEmpty(DBSource))
            {
                if (log.IsErrorEnabled)
                {
                    log.Error("The DB Source of Dars can't been found!");
                }
                return null;
            }
            if (string.IsNullOrEmpty(strSQL))
            {
                if (log.IsWarnEnabled)
                {
                    log.Warn("The SQL Statement of Dars is error");
                }
                return null;
            }
            int stage = 0;
            try
            {
                using (var conn = new MySqlConnection(DBSource))
                {
                    stage = 1;
                    conn.Open();
                    stage = 2;
                    using (var cmd = new MySqlCommand(strSQL, conn))
                    {
                        stage = 3;
                        using (var adapter = new MySqlDataAdapter(cmd.AddParameters(parms)))
                        {
                            stage = 4;
                            var dataTable = new DataSet();
                            adapter.Fill(dataTable,"ds");
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                switch (stage)
                {
                    case 0:
                        if (log.IsWarnEnabled)
                        {
                            log.Warn("Init the connection of Dars is error", e);
                            return null;
                        }
                        throw new Exception(e.Message.ToString());
                    case 1:
                        if (log.IsWarnEnabled)
                        {
                            log.Warn("Open the connection of Dars is error", e);
                            return null;
                        }
                        throw new Exception(e.Message.ToString());
                    case 2:
                        if (log.IsWarnEnabled)
                        {
                            log.Warn("Exeception for executing SQL statement of Dars", e);
                            return null;
                        }
                        throw new Exception(e.Message.ToString());
                    case 3:
                        if (log.IsWarnEnabled)
                        {
                            log.Warn("Exeception for creating SQL data adapter of Dars", e);
                        }
                        throw new Exception(e.Message.ToString());
                    case 4:
                        if (log.IsWarnEnabled)
                        {
                            log.Warn("Exeception for filling data table of Dars", e);
                        }
                        throw new Exception(e.Message.ToString());
                    default:
                        throw new ApplicationException("Bad program flow");
                }
            }
        }
        #endregion
        
        private static MySqlCommand AddParameters(this MySqlCommand command, object[] parms)
        {
            if (parms != null)
            {
                for (int i = 0; i < parms.Length / 2; ++i)
                {
                    command.Parameters.AddWithValue((string)parms[i * 2], parms[i * 2 + 1]);
                }
            }
            return command;
        }
        public static List<object> AddParameter(this List<object> parms, string name, object value)
        {
            parms.Add(name);
            parms.Add(value);
            return parms;
        }
    }
}