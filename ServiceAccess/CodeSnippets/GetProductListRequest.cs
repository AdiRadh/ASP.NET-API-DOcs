using ServiceAccess.InsuranceService;
using System;

namespace ServiceTestConsole
{
    class GetProductListRequest
    {

        static void TMain(string[] args)
        {
            InsuranceWebService insuranceWebService = new InsuranceWebService();
            var insReq = new InsuranceRequest();
            var sess = new SessionRequest();
            var veh = new VehicleRequest();

            sess.Username = "";
            sess.Password = "";
            sess.DeliveryDate = new DateTime();
            sess.AuthenticationKey = "";
            sess.GuaranteeWarrantyDate = new DateTime();
            sess.LoanProvided = true;
            veh.Price = 1;
            sess.Vehicle = veh;
            insReq.Session = sess;
            insReq.Vehicle = veh;


            var response = insuranceWebService.GetProductListRequest(insReq);
            for (int i = 0; i < response.Plan.Length; i++)
            {
                Console.WriteLine(response.Plan[i]);
                Console.WriteLine(response.Description[i]);
            }
            Console.ReadKey();

        }
    }
}