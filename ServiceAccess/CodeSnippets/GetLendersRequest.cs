﻿using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class GetLendersRequest
    {
        static void test(string[] args)
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