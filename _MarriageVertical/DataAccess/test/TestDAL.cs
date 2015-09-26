using _MarriageVertical.Models.test;
using _MarriageVertical.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _MarriageVertical.DataAccess.test
{
    public static class TestDAL
    {
        private static string userinfo = System.Configuration.ConfigurationManager.AppSettings["MySQLconnStr"].ToString();
        public static List<Test> nameAndAge()
        {
            string sql = @"select * from userinfo";
            var dt = MySQLHelper.ExecuMySQLRDataTable(sql, userinfo);
            var list = MySQLHelper.ExecuMySQLRDataTable(sql, userinfo).ConvertToList<Test>();
            return list;
        }
    }
}