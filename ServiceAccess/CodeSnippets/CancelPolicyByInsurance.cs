﻿using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class CancelPolicyByInsuranceRequest
    {

        static void nMain(string[] args)
        {
            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var cancel = new CancelRequest();
            var insReq = new InsuranceRequest();
            var sess = new SessionRequest();

            sess.Username = "";
            sess.Password = "";
            sess.AuthenticationKey = "";
            cancel.AccountID = "";
            cancel.CancellationReason = "";
            cancel.CertificateNumber = "";
            cancel.ContactEmail = "";
            cancel.DealerName = "";

            //Always Null
            cancel.PhoenixCancellation = null;
            cancel.RequestValidation = true;
            cancel.RefundCustomer = ""; //Set As required
            cancel.Surname = "";
            insReq.Session = sess;
            insReq.Cancellation = cancel;

            var response = insuranceWebService.CancelPolicyByInsuranceRequest(insReq);
            
            if(response.Success)
            {
                Console.WriteLine("Success");
            } else
            {
                Console.WriteLine("Fail");
            }
            Console.ReadKey();

        }
    }
}