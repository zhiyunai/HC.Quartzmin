using HC.Core.Models;
using HC.Core.Services;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace HC.Server.Run
{
    public class TeacherServer : BaseLogger, IJob
    {
        Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public async Task Execute(IJobExecutionContext context)
        {
            string connStr = "Data Source=.;Initial Catalog=TSQLTEST;Integrated Security=True";

            AddTeacher(connStr);
            await Task.CompletedTask;
        }

        public void AddTeacher(string connStr)
        {
            var DB = new DataBaseFactory().GetDB(connStr);
            Teacher teacher = new Teacher()
            {
                tname = "TEST" + new Random().Next(100, 999).ToString()
            };
            DB.Insertable(teacher).ExecuteCommand();
        }
    }
}
