using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class CreateCustomer
    {

        static void aMain(string[] args)
        {
            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var cusRequest = new CustomerDetailsRequest();
            var mySession = new SessionRequest();
            var myClient = new ClientRequest();
            var myVehicle = new VehicleRequest();


            //Username and Authentication key always needed 
            mySession.Username = "";
            mySession.AuthenticationKey = "";

            /*
             * For Create Customers not all fields are required
             * Fields can be left as empty strings e.g. ""
             */

            //Optional
            mySession.DeliveryDate = new DateTime();
            mySession.DealerFittedAccessoriesValue = 0;
            //END Optional
            myClient.FirstName = "";
            myClient.Surname = "";
            myClient.Title = "";
            myClient.HouseNumber = "";
            myClient.Address = "";
            myClient.Postcode = "";
            myClient.Email = "";
            myClient.Telephone = "";
            myClient.Contact_by_email = false;
            myClient.Contact_by_phone = false;
            myClient.Contact_by_post = false;
            myClient.Contact_by_text = false;

            //Optional assignment; does not necessarily need to be assigned
            myClient.DateOfBirth = new DateTime();
            //END Optional

            myClient.Mobile = "";
            myClient.IsCompany = false;

            myVehicle.Make = "";
            myVehicle.Model = "";
            myVehicle.Registration = "";

            //Optional
            myVehicle.Price = 0;
            myVehicle.Mileage = 0;
            myVehicle.DateRegistered = new DateTime();
            myVehicle.EngineSize = 0;
            myVehicle.MOTDate = new DateTime();
            //END Optional

            myVehicle.Fuel = "";
            myVehicle.NewVehicle = false;
            myVehicle.Motorcycle = false;
            myVehicle.AntilockBrakes = false;
            myVehicle.AirConditioner = false;
            myVehicle.FourWheelDrive = false;
            myVehicle.Turbo = false;
            myVehicle.SpecialCategory = false;
            myVehicle.Automatic = false;
            cusRequest.Session = mySession;
            cusRequest.Vehicle = myVehicle;
            cusRequest.Client = myClient;



            var response = insuranceWebService.CreateCustomer(cusRequest);
            if (response.Success)
            {
                Console.WriteLine("Success");
            }
            else
            {
                Console.WriteLine("Fail");
            }
            Console.ReadKey();

        }
    }
}