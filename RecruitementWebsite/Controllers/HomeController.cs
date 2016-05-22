using RecruitementWebsite.Models;
using RecruitementWebsite.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace RecruitementWebsite.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public List<VacancyModel> GetVacancyList()
        {
            VacancyService.DummyData();
            List<VacancyModel> vacancyModelList = VacancyService.VacancyListModels;

            return vacancyModelList;
            ////var jsonSerialiser = new JavaScriptSerializer();
            ////var json = jsonSerialiser.Serialize(vacancyModelList);

            ////return json;
        }
    }
}