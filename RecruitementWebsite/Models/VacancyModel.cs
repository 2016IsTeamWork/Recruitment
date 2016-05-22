using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace RecruitementWebsite.Models
{
    public class VacancyModel
    {
        public string Title { get; set; }
        public string Company { get; set; }
        public string Type { get; set; }
        public string Updated { get; set; }
        public string Created { get; set; }
        public string Recruiter { get; set; }
        public string Owner { get; set; }
        public string CompanyJobID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string Salary { get; set; }
        public string Interviews { get; set; }
        public string JobStatus { get; set; }
        public string ItemID { get; set; }
   
        public VacancyModel()
        {
        }
    }

}