using _MarriageVertical.DataAccess.test;
using _MarriageVertical.Models.test;
using _MarriageVertical.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _MarriageVertical.BusinessLogic.test
{
    public static class TestBLL
    {
        public static List<Test> getNameAge()
        {
            var list = TestDAL.nameAndAge();
            //Logger.LogInfo("","","");
            return list;
        }
    }
}