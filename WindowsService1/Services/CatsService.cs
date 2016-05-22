using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;

namespace WindowsService1
{
    public partial class CatsService : ServiceBase
    {
        Timer timer = new Timer(); 

        public CatsService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer.Interval = 1000000; /*The interval of the Windows Service Cycle set this to one hour*/
            timer.Start();
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(OnElapseTime); /*fire the event after each cycle*/
    
        }

        private void OnElapseTime(object sender, ElapsedEventArgs e)
        {
            // HERE DO UR DATABASE QUERY AND ALL
        }

        protected override void OnStop()
        {
        }
    }
}
