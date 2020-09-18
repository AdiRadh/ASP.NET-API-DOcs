using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class GetIncludedMakes
    {

        static void sadMain(string[] args)
        {



            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var insRequest = new InsuranceRequest();
            var mySession = new SessionRequest();
            var myPolicy = new PolicyRequest();
            var myClient = new ClientRequest();
            var myVehicle = new VehicleRequest();

            mySession.Username = "";
            mySession.AuthenticationKey = "";
            mySession.Bordereaux = false;
            mySession.Account = "";
            mySession.GuaranteeWarrantyDate = new DateTime();
            mySession.PaidByCard = true;
            mySession.DeliveryDate = new DateTime();
            mySession.LoanProvided = false;

            myClient.FirstName = "";
            myClient.Surname = "";
            myClient.Title = "";
            myClient.HouseNumber = "";
            myClient.Address = "";
            myClient.Postcode = "";
            myClient.Email = "";
            myClient.Telephone = "";
            myClient.IsCompany = false;

            myPolicy.Description = "";
            myPolicy.Plan = "";
            myPolicy.GrossPremium = 0;
            myPolicy.Product = "";
            myPolicy.CoverPeriod = 0;

            myVehicle.Make = "";
            myVehicle.Model = "";
            myVehicle.Registration = "";
            myVehicle.Price = 0;
            myVehicle.Mileage = 0;
            myVehicle.DateRegistered = new DateTime();
            myVehicle.EngineSize = 0;
            myVehicle.Fuel = "";
            myVehicle.NewVehicle = false;
            myVehicle.Motorcycle = false;


            insRequest.Session = mySession;
            insRequest.Vehicle = myVehicle;
            insRequest.Client = myClient;
            insRequest.Policy = myPolicy;

            var response = insuranceWebService.GetIncludedMakesRequest(insRequest);
            foreach (var p in response.GetVehicleList)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();

        }
    }
}