using System;
using System.Collections.Generic;
using System.Linq;

namespace TestInsuranceServiceSite.Models
{
    public class WebMethod
    {
        public string Request { get; set; }

        public string Name { get; set; }
        public Dictionary<string, string> Parameters { get; set; }

        public string Description { get; set; }

        public string Response { get; set; }

        public string Format { get; set; }
        public bool Screenshot { get; set; }

        public bool IsCode { get; set; }
        public string Code { get; set; }
        public WebMethod()
        {
            Parameters = new Dictionary<string, string>();
        }
        public WebMethod(string _methodName, string _description)
        {
            Name = _methodName;
            Description = _description;
            Parameters = new Dictionary<string, string>();
            Response = "";
            Request = "";

        }

        public WebMethod(string _methodName, Dictionary<string, string> _parameters, string _description, string _response, string _request)
        {
            Name = _methodName;
            Parameters = _parameters;
            Description = _description;
            Response = _response;
            Request = _request;
        }
    }
}