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
                model.Title = "Sentimus Title" + i;
                model.Salary = "1000" + i;
                VacancyListModels.Add(model);
            }
        }

        public static void LoadListFromDB()
        {
            string APIString = " https://api.catsone.com/api/get_public_joborders?save_user_values=1&subdomain=sentimus&transaction_code=fd20aba59b0968107547f1107ff78fd4&keywords=&result=normal&max_results=50&offset=";
            RunASync(APIString).Wait();
        }

        private static List<VacancyModel> CreateModels(IEnumerable xelements)
        {
            List<VacancyModel> vacancyModels = new List<VacancyModel>();
            foreach (XElement e in xelements)
            {
                VacancyModel vModel = new VacancyModel();
                if (e.Element("id") != null)
                {
                    vModel.ID = e.Element("id").Value;
                }
                if (e.Element("summary") != null)
                {
                    vModel.Summary = e.Element("summary").Value;
                }
                if (e.Element("title") != null)
                {
                    vModel.Title = e.Element("title").Value;
                }
                if (e.Element("description") != null)
                {
                    vModel.Description = e.Element("description").Value;
                }
                if (e.Element("salary") != null)
                {
                    vModel.Salary = e.Element("salary").Value;
                }
                if (e.Element("city") != null)
                {
                    vModel.City = e.Element("city").Value;
                }
                if (e.Element("zip") != null)
                {
                    vModel.Zip = e.Element("zip").Value;
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
