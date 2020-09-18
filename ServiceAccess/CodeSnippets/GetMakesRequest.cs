﻿using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class GetMakes
    {

        static void aMain(string[] args)
        {
            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var response = insuranceWebService.GetMakesRequest();
            foreach (var p in response.VehicleMakes)
            {
                Console.WriteLine(p);
            }
            Console.ReadKey();

        }
    }
}