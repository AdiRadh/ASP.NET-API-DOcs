using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestInsuranceServiceAPI.Models;
using TestInsuranceServiceAPI.Classes;
using System.Configuration;


namespace TestInsuranceServiceAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataProcessor _dp = new DataProcessor(ConfigurationManager.AppSettings["LoadPath"]);
        private readonly ServiceAccessClass _serviceAccess = new ServiceAccessClass();

        List<WebMethod> _methods;
        List<ServiceObject> _requests;
        List<ServiceObject> _responses;

        public ActionResult Index()
        {
            return View();
        }

        public Boolean Load()
        {
            
            _methods = _dp.GetMethods();
            _requests = _dp.GetRequests();
            _responses = _dp.GetResponses();

            return true;
        }

        public List<WebMethod> GetMethods()
        {
            return _methods;
        }
        public List<ServiceObject> GetRequests()
        {
            return _requests;
        }
        public List<ServiceObject> GetResponses()
        {
            return _responses;
        }

        public Response ExecuteMethod(string method, Dictionary<string, object> parameters)
        {
            try
            {
                var methodsToRun = _serviceAccess.GetType().GetMethod(method);
                var param = new object[1];
                param[0] = parameters;
                if (methodsToRun != null)
                {
                    var response = (Response)methodsToRun.Invoke(_serviceAccess, param);
                    response.ResponseType = method;
                    return response;
                }
                return null;
                
            } catch(Exception e)
            {
                var err = new Response
                {
                    Name = "Method Invoking Error",
                    ErrorMessage = "Error Has Occurred Invoking Method: " + e.Message + "\n" + e.StackTrace,
                    ResponseType = "Error"
                };
                return err;
            }
        }
    }
}