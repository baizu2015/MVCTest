using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace _MarriageVertical.Util
{
    public static class DatableToList
    {
        #region Convert to list
        /// <summary>
        /// Convert to list
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>List<T></returns>
        public static List<T> ConvertToList<T>(this DataTable table)
            where T : new()
        {
            var list = new List<T>();
            if (table == null || table.Rows == null)
            {
                return list;
            }
            foreach (DataRow row in table.Rows)
            {
                var item = new T();
                foreach (var prop in item.GetType().GetProperties())
                {
                    if (table.Columns.Contains(prop.Name) && prop.CanWrite)
                    {
                        object value = row[prop.Name];
                        prop.SetValue(item, value == DBNull.Value ? null : value);
                    }
                }
                list.Add(item);
            }
            return list;
        }
        #endregion
        #region Convert to list
        /// <summary>
        /// Convert to list
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>List<T></returns>
        public static List<T> ConvertToList<T>(this DataSet ds)
            where T : new()
        {
            var list = new List<T>();
            if (ds == null || ds.Tables[0].Rows == null)
            {
                return list;
            }
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var item = new T();
                var listx = item.GetType().GetProperties();
                foreach (var prop in item.GetType().GetProperties())
                {
                    if (ds.Tables[0].Columns.Contains(prop.Name) && prop.CanWrite)
                    {
                        object value = row[prop.Name];
                        prop.SetValue(item, value == DBNull.Value ? null : value);
                    }
                }
                list.Add(item);
            }
            return list;
        }
        #endregion
        public static List<T> ToList<T>(this DataTable table)
    where T : new()
        {

            var result = new List<T>();
            if (table == null)
            {
                return result;
            }
            var map = table.Columns.OfType<DataColumn>()
                                   .Select(
                                        column =>
                                        new
                                        {
                                            PropertyName = string.Join(string.Empty, column.ColumnName.Select(c => c == '_' || char.IsLetterOrDigit(c) ? c : '_')),
                                            ColumnName = column.ColumnName,
                                        }
                                    )
                                   .ToDictionary(
                                        pair => char.IsDigit(pair.PropertyName[0]) ? "_" + pair.PropertyName : pair.PropertyName,
                                        pair => pair.ColumnName
                                    );
            foreach (DataRow row in table.Rows)
            {
                var item = new T();
                foreach (var prop in item.GetType()
                                         .GetProperties()
                                         .Where(prop => prop.CanWrite && map.ContainsKey(prop.Name)))
                {
                    object value = row[map[prop.Name]];
                    prop.SetValue(item, value == DBNull.Value ? null : value);
                }
                result.Add(item);
            }
            return result;
        }

    }
}