using System;
using System.Collections.Generic;
using System.Text;

namespace HC.Server.Run
{
    public class BaseLogger
    {
        public NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
    }
}
