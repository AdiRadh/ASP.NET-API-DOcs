using System;
using TestInsuranceServiceAPI.InsuranceService;
using System.Collections.Generic;


namespace TestInsuranceServiceAPI.Models
{
    public class Response
    {
        public Response()
        {
        }
        public string Name { get; set; }

        public string ResponseType { get; set; }
        public bool Success { get; set; }

        public string Message { get; set; }

        public Guid CustomerID { get; set; }

        public string Account { get; set; }

        public string CertificateNumber { get; set; }

        public string UniqueCertificateNumber { get; set; }

        public string URL { get; set; }

        public string QuoteNumber { get; set; }

        public List<GapProductModel> GapPolicyModelList { get; set; }

        public string ErrorMessage { get; set; }

        public List<string> Description { get; set; }

        public List<string> Product { get; set; }

        public List<string> Plan { get; set; }

        public List<bool> NonMonthly { get; set; }

        public List<int> MinTerm { get; set; }

        public List<int> MaxTerm {get; set;}

        public List<int> MaxAge { get; set; }

        public List<int> MaxMiles { get; set; }

        public List<int> MinCC { get; set; }

        public List<string> GetVehicleList { get; set; }
        public List<string> Lenders { get; set; }

        public List<string> VehicleMakes { get; set; }

        public string Errors { get; set; }


    }
}