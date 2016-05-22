using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace RecruitementWebsite.Utility
{
    public class BackendLogger
    {
        private string file = "D:/Log/RecruitmentWebsite.txt";

        public BackendLogger()
        { }

        public void Log(string ToLog)
        {
            using(StreamWriter writer = new StreamWriter(file, true))
            {
                writer.AutoFlush = true;
                writer.Write(ToLog);
            }
        }
    }
}