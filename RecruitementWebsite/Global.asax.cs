using RecruitementWebsite.Service;
using RecruitementWebsite.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace RecruitementWebsite
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        private static Timer timer;
        private VacancyService _service;
        private BackendLogger _logger;
        private string DBLoadString = "https://api.catsone.com/api/get_joborders?save_user_values=1&subdomain=sentimus&transaction_code=fd20aba59b0968107547f1107ff78fd4&search=%22C%23%22&rows_per_page=50&page_number=0&sort=id%2C+title%2C+description%2C+is_hot%2C+company&sort_direction=&display_column=&list=&filter=";

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

             _service = new VacancyService();
             _logger = new BackendLogger();
             timer = new Timer();
             timer.Interval = 60000 * 60;
             timer.Enabled = true;
             timer.AutoReset = true;
         //    _service.LoadListFromDB(DBLoadString);
         //    timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }

          void timer_Elapsed(object sender, ElapsedEventArgs e)
          {
              //Log before
              DateTime timeBeginLoad = DateTime.Now;
              string stringTimeBeginLoad = timeBeginLoad.ToString();
              _logger.Log("New load engaged: " + stringTimeBeginLoad);

              _service.LoadListFromDB(DBLoadString);

              //Log after
              DateTime timeEndLoad =  DateTime.Now;
              string stringTimeEndLoad = timeEndLoad.ToString();
              _logger.Log("Load completed: " + stringTimeEndLoad);
          }
    
    }
}