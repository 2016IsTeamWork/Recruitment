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
        public string ID { get; set; }
        public string Summary { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Salary { get; set;  }
        public string City { get; set; }
        public string Zip { get; set; }

        public VacancyModel()
        {
        }
    }

}