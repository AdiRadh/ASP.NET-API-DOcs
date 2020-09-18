using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class ReprintPolicyRequest
    {

        static void hMain(string[] args)
        {
            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var insReq = new InsuranceRequest();
            var sess = new SessionRequest();
            var doc = new DocumentRequest();

            sess.Username = "";
            sess.Password = "";
            doc.CertificateNumber = "";
            doc.PrintCertificate = true;
            doc.PrintPolicySummary = true;
            doc.PrintTermsandConditions = true;
            doc.PrintStatementofPrice = true;
            doc.PrintDirectDebit = true;
            insReq.Session = sess;
            insReq.Documents = doc;


            var response = insuranceWebService.ReprintPolicyRequest(insReq);
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