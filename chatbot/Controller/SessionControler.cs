using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chatbot.Controller
{
    public class SessionControler
    {
        private static SessionControler instance;
        //private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static SessionControler getInstance()
        {
            return instance;
        }
        static public void init()
        {
            if (null == instance)
            {
                instance = new SessionControler();
            }
        }

        /*public ILog getLog()
        {
            return log;
        }*/

        
    }


}
