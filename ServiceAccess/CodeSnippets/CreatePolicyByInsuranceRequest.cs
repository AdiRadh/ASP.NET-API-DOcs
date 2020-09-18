using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class CreatePolicyByInsuranceRequest
    {

        static void aMain(string[] args)
        {


            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var insRequest = new InsuranceRequest();
            var mySession = new SessionRequest();
            var myBank = new BankRequest();
            var myPolicy = new PolicyRequest();
            var myClient = new ClientRequest();
            var myVehicle = new VehicleRequest();
            var myLoan = new LoanRequest();

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
            //Optional
            myClient.DateOfBirth = new DateTime();
            //END Optional
            myClient.IsCompany = false;

            myPolicy.Description = "";
            myPolicy.Plan = "";
            myPolicy.GrossPremium = 0;
            myPolicy.Product = "";
            myPolicy.CoverPeriod = 0;
            //Optional
            myPolicy.DatePISupplied = new DateTime();
            myPolicy.ExternalReference = "";
            myPolicy.DateCustomerConfirmed = new DateTime();
            //END Optional
            myPolicy.PaidByCard = false;

            myVehicle.Make = "";
            myVehicle.Model = "";
            myVehicle.Registration = "";
            myVehicle.Price = 0;
            myVehicle.Mileage = 0;
            myVehicle.DateRegistered = new DateTime();
            myVehicle.EngineSize = 0;
            myVehicle.MOTDate = new DateTime();
            myVehicle.Fuel = "";
            myVehicle.NewVehicle = false;
            myVehicle.Motorcycle = false;

            myBank.AccountName = "";
            myBank.AccountNumber = "";
            myBank.PaperlessDDI = false;
            myBank.PayeeAddress = "";
            myBank.PayeeFirstName = "";
            myBank.PayeeSurname = "";
            myBank.PayeeHouseNumber = "";
            myBank.PayeePostcode = "";
            myBank.PayeeTitle = "";
            myBank.SortCode = "";
            myBank.PolicyHolderPaying = false;

            //Optional
            myLoan.Advance = 0;
            myLoan.AdvanceRentals = 0;
            myLoan.LoanPayment = 0;
            myLoan.LoanTerm = 0;
            //END Optional
            myLoan.BorrowerName = "";
            myLoan.Lender = "";

            insRequest.Session = mySession;
            insRequest.Vehicle = myVehicle;
            insRequest.Client = myClient;
            insRequest.Policy = myPolicy;
            insRequest.Bank = myBank;
            insRequest.Loan = myLoan;

            var response = insuranceWebService.CreatePolicyByInsuranceRequest(insRequest);


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