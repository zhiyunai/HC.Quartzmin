using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HC.Server.Run
{
    public class TESTServer : BaseLogger, IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            TESTRun();
            await Task.CompletedTask;
        }

        public void TESTRun()
        {
            logger.Debug("TESTRun开始");
            Thread.Sleep(2000);
            logger.Debug("TESTRun停止2秒");
            logger.Debug("TESTRun结束");
            logger.Debug("====================================================================");
        }
    }
}
