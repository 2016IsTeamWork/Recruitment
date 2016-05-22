using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecruitementWebsite.Models
{
    public class VacancyModel
    {
        private string _title;

        private string _company;

        private string _type;

        private string _updated;

        private string _created;

        private string _recruiter;

        private string _owner;

        private string _company_job_id;

        private string _city;

        private string _state;

        private string _zipCode;
        
        private string _location;
        
        private string _country;
        
        private string _salary;

        private string _interviews;

        private string _jobStatus;

        private string _item_id;

        public VacancyModel(string title, string company, string type, string updated, string created, string recruiter, string owner, string company_job_id, 
           string city, string state, string zipCode, string location, string country, string salary, string interviews, string jobStatus, string item_id)
        {
            _title = title;
            _company = company;
            _type = type;
            _updated = updated;
            _created = created;
            _recruiter = recruiter;
            _owner = owner;
            _company_job_id = company_job_id;
            _city = city;
            _state = state;
            _zipCode = zipCode;
            _location = location;
            _country = country;
            _salary = salary;
            _interviews = interviews;
            _jobStatus = jobStatus;
            _item_id = item_id;
        }

    }
}