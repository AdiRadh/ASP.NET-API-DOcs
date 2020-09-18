﻿using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class MTAPolicyByInsuranceRequest
    {

        static void DMain(string[] args)
        {
            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var mta = new AdjustRequest();
            var insReq = new InsuranceRequest();
            var sess = new SessionRequest();

            sess.Username = "";
            sess.Password = "";
            sess.AuthenticationKey = "";
            mta.AccountID = "";
            mta.Contact = "";
            mta.DealerName = "";
            mta.Details = "";
            mta.PolicyNumber = "";
            mta.MTAReason = "";
            mta.Surname = "";
            mta.RequestValidation = true;
            mta.PhoenixMTA = null;
            insReq.Session = sess;
            insReq.MTA = mta;

            var response = insuranceWebService.MTAPolicyByInsuranceRequest(insReq);
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