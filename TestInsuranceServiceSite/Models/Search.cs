using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestInsuranceServiceSite.Models
{
    public class Search
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Search(string name, string type)
        {
            Name = name;
            Type = type;
        }

    }
}