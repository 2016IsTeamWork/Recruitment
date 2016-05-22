using RecruitementWebsite.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RecruitementWebsite.Service
{
    public class VacancyService
    {
        public static List<VacancyModel> VacancyListModels = new List<VacancyModel>();
     
        public VacancyService()
        {
        }

        public static void DummyData()
        {
            VacancyListModels.Clear();
            for(int i=0; i<=20; ++i)
            {
                VacancyModel model = new VacancyModel();
                model.Company = "Sentimus Company" + i;
                model.Title = "Sentimus Title" + i;
                model.Salary = "1000" + i;
                VacancyListModels.Add(model);
            }
        }

        //public List<VacancyModel> GetVacancyList(string SearchString)
        //{
        //    string APIString = "https://api.catsone.com/api/get_joborders?save_user_values=1&subdomain=sentimus&transaction_code=fd20aba59b0968107547f1107ff78fd4&search=%22C%23%22&rows_per_page=50&page_number=0&sort=id%2C+title%2C+description%2C+is_hot%2C+company&sort_direction=&display_column=&list=&filter=";
        //    return LoadListFromDB(APIString);
        //}

        public void LoadListFromDB(string ApiString)
        {
            RunASync(ApiString).Wait();
           // return _vacancyListModels;
        }

        //public List<VacancyModel> ReturnCurrentList()
        //{
        //    return VacancyListModels;
        //}

        private static List<VacancyModel> CreateModels(IEnumerable xelements)
        {
            List<VacancyModel> vacancyModels = new List<VacancyModel>();
            foreach (XElement e in xelements)
            {
                VacancyModel vModel = new VacancyModel();
                if (e.Element("title") != null)
                {
                    vModel.Title = e.Element("title").Value;
                }
                if (e.Element("company") != null)
                {
                    vModel.Company = e.Element("company").Value;
                }
                if (e.Element("type") != null)
                {
                    vModel.Type = e.Element("type").Value;
                }
                if (e.Element("updated") != null)
                {
                    vModel.Updated = e.Element("updated").Value;
                }
                if (e.Element("created") != null)
                {
                    vModel.Created = e.Element("created").Value;
                }
                if (e.Element("recruiter") != null)
                {
                    vModel.Recruiter = e.Element("recruiter").Value;
                }
                if (e.Element("owner") != null)
                {
                    vModel.Owner = e.Element("owner").Value;
                }
                if (e.Element("company_job_id") != null)
                {
                    vModel.CompanyJobID = e.Element("company_job_id").Value;
                }
                if (e.Element("city") != null)
                {
                    vModel.City = e.Element("city").Value;
                }
                if (e.Element("state") != null)
                {
                    vModel.State = e.Element("state").Value;
                }
                if (e.Element("zip") != null)
                {
                    vModel.ZipCode = e.Element("zip").Value;
                }
                if (e.Element("location") != null)
                {
                    vModel.Location = e.Element("location").Value;
                }
                if (e.Element("country") != null)
                {
                    vModel.Country = e.Element("country").Value;
                }
                if (e.Element("salary") != null)
                {
                    vModel.Salary = e.Element("salary").Value;
                }
                if (e.Element("interviews") != null)
                {
                    vModel.Interviews = e.Element("interviews").Value;
                }
                if (e.Element("status") != null)
                {
                    vModel.JobStatus = e.Element("status").Value;
                }
                if (e.Element("item_id") != null)
                {
                    vModel.ItemID = e.Element("item_id").Value;
                }
                vacancyModels.Add(vModel);
            }
            return vacancyModels;
        }

        private static async Task RunASync(string argApiString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(argApiString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(argApiString, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    var streamContent = response.Content.ReadAsStreamAsync();

                    while (streamContent.IsCompleted == false)
                    {
                    }

                    var streamResult = streamContent.Result;
                    XDocument doc;

                    using (StreamReader reader = new StreamReader(streamResult))
                    {
                        reader.BaseStream.ReadTimeout = 5000;
                        string end = reader.ReadToEnd();
                        doc = XDocument.Parse(end);
                        var query = from a in doc.Descendants("item") select a;

                        VacancyListModels = CreateModels(query);
                        return;
                    }
                }
            }
        }
    }

}
