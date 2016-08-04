using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Natura_Nova_Ata_3._0._0
{
    public class Global : System.Web.HttpApplication
    {
        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 30000;
            timer.AutoReset = true;
            timer.Enabled = true;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}