using RecruitementWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1.Services
{
    public class VacancyTableService
    {
        private HttpClient client;
        private string APIString;

        public VacancyTableService()
        {
            client = new HttpClient();

        }

        public string GetVacancyList(string SearchString)
        {
            APIString = "https://api.catsone.com/api/get_joborders?save_user_values=1&subdomain=sentimus&transaction_code=fd20aba59b0968107547f1107ff78fd4&search=%22"
               + SearchString + "%22&rows_per_page=&page_number=&sort=id%2C+title%2C+description&sort_direction=asc&display_column=&list=&filter=";

            List<VacancyModel> tempList = GetListOfVacancyModels(APIString);

            return "nothingness";
        }

        private List<VacancyModel> GetListOfVacancyModels(string ApiString)
        {
            List<VacancyModel> listOfVacancyModels = new List<VacancyModel>();

            RunASync(ApiString).Wait();

            return listOfVacancyModels;
        }

        static async Task RunASync(string argApiString)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(argApiString);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(argApiString);

                if (response.IsSuccessStatusCode)
                {
                    //Product product = await response.Content.ReadAsAsync>Product>();

                }
            }
        }



    }
}
