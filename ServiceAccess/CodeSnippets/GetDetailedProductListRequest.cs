using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class GetDetailedProductListRequest
    {

        static void SMain(string[] args)
        {
            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var getDetProdList = new GetDetailedProduct();


            var Username = "";
            var Password = "";
            var SearchDate = new DateTime(); // Set as required
            var AuthenticationKey = "";

            var response = insuranceWebService.GetDetailedProductListRequest(Username,Password,AuthenticationKey,SearchDate);
            for(int i = 0; i < response.Description.Length; i++)
            {
                Console.WriteLine("Description: "+response.Description[i]);
                Console.WriteLine("Product: "+response.Product[i]);
                Console.WriteLine("Plan: "+response.Plan[i]);
                Console.WriteLine("NonMonthly: "+response.NonMonthly[i]);
                Console.WriteLine("MinTerm: "+response.MinTerm[i]);
                Console.WriteLine("MaxTerm: "+response.MaxTerm[i]);
                Console.WriteLine("Period: "+response.Period[i]);
                Console.WriteLine("MinPremium: "+response.MinPremium[i]);
                Console.WriteLine("MaxPremium: "+response.MaxPremium[i]);
                Console.WriteLine("MinPrice: " + response.MinPrice[i]);
                Console.WriteLine("MaxPrice: " + response.MaxPrice[i]);
                Console.WriteLine("MaxAge: " + response.MaxAge[i]);
                Console.WriteLine("MaxMiles: " + response.MaxMiles[i]);
                Console.WriteLine("MinCC: " + response.MinCC[i]);
            }
            Console.ReadKey();

        }
    }
}