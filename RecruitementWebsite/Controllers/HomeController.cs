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
           // VacancyService.DummyData();

            List<VacancyModel> vacancyModelList = VacancyService.VacancyListModels;

            var viewModel = vacancyModelList.Select(x => new
            {
                ID = x.ID,
                Summary = x.Summary,
                Title = x.Title,
                Description = x.Description,
                Salary = x.Salary,
                City = x.City,
                Zip = x.Zip
            });

            return Json(viewModel.ToArray(), JsonRequestBehavior.AllowGet);
        }
    }
}