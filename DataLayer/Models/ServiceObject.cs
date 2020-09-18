using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.Models
{
    public class ServiceObject
    {
        public Boolean IsResponse { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Code { get; set; }
        public Dictionary<String, String> Properties { get; set; }

        public ServiceObject(bool resp, string name)
        {
            Name = name;
            IsResponse = resp;
        }

        public ServiceObject()
        {
            Properties = new Dictionary<string, string>();

        }

        public string Format { get; set; }
    }
}