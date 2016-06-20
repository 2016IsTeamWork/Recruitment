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

        public JsonResult GetVacancyList()
        {
            VacancyService.DummyData();
            List<VacancyModel> vacancyModelList = VacancyService.VacancyListModels;

            var viewModel = vacancyModelList.Select(x => new
            {
                Company = x.Company, 
                Salary = x.Salary,
                Title = x.Title
            });

            return Json(viewModel.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}