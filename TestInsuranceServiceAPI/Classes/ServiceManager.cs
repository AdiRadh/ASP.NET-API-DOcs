using System;
using System.Collections.Generic;
using TestInsuranceServiceAPI.InsuranceService;
using TestInsuranceServiceAPI.Models;

namespace TestInsuranceServiceAPI.Classes
{
    class ServiceManager : IServiceManager
    {
        private readonly InsuranceWebService _insuranceWebService = new InsuranceWebService();

        private static Response MethodRespToObject(object resp)
        {
            var responseObj = new Response();

            foreach (var p in resp.GetType().GetProperties())
            {
                foreach (var r in responseObj.GetType().GetProperties())
                {
                    if (!p.Name.Equals(r.Name) || p.GetValue(resp) == null) continue;
                    var h = p.PropertyType;
                    if (h == typeof(string[]))
                    {
                        var list = new List<string>((string[])p.GetValue(resp));

                        r.SetValue(responseObj, list);

                    }
                    else if (h == typeof(int[]))
                    {
                        var list = new List<int>((int[])p.GetValue(resp));
                        r.SetValue(responseObj, list);

                    }
                    else if (h == typeof(bool[]))
                    {
                        var list = new List<bool>((bool[])p.GetValue(resp));
                        r.SetValue(responseObj, list);

                    }
                    else
                    {
                        r.SetValue(responseObj, p.GetValue(resp));
                    }
                }
            }

            return responseObj;
        }

        public Response ExampleMethod(Dictionary<string, object> parameters)
        {
            try
            {
                var sess = new SessionRequest
                {
                    Username = (string)parameters["Username"],
                    Password = "",
                    AuthenticationKey = (string)parameters["AuthenticationKey"],
                    SearchDate = (DateTime)parameters["SearchDate"]
                };
                return MethodRespToObject(sess);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        
    }

}
