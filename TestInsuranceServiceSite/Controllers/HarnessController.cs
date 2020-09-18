using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TestInsuranceServiceSite.Models;
using TestInsuranceServiceAPI.Classes;

namespace TestInsuranceServiceSite.Controllers
{
    public class HarnessController : Controller
    {

        private readonly List<string> _booleanAttr = new List<string>() { "RequestValidation", "IsCompany", "NewVehicle", "Motorcycle", "AntilockBrakes", "AirConditioner", "FourWheelDrive", "Turbo", "SpecialCategory", "Automatic", "Bordereaux", "PaidByCard", "LoanProvided", "PaperlessDDI", "PolicyHolderPaying", "LoanProvided" };
        private readonly List<string> _decimalAttr = new List<string>() { "DealerFittedAccessoriesValue", "Policy", "GrossPremium", "Advance", "LoanPayment" };
        private readonly List<string> _intAttr = new List<string>() { "Mileage", "EngineSize", "CoverPeriod", "AdvanceRentals", "LoanTerm" };
        private List<WebMethod> _methods = new List<WebMethod>();
        private readonly TestInsuranceServiceAPI.Controllers.HomeController _controller = new TestInsuranceServiceAPI.Controllers.HomeController();

        // GET: Harness
        [HttpGet]
        public ActionResult Index()
        {
            On_Load();
            return View(_methods);
        }

        [HttpGet]
        public ActionResult TestView()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Service(FormCollection form)
        {
            On_Load();
            var response = new Response();
            var methodName = form["Name"];
            var parameters = new Dictionary<string, object>();

            //Convert Form input fields to corresponding variable types
            foreach (var input in form.AllKeys)
            {

                if (input.ToLower().Contains("date"))
                {
                    parameters.Add(input, Convert.ToDateTime(form[input]));
                }
                else if (input.ToLower().Contains("print") || input.ToLower().Contains("contact_by") || _booleanAttr.Contains(input))
                {
                    parameters.Add(input, form[input].ToLower().Equals("on"));
                }
                else if (_decimalAttr.Contains(input))
                {
                    parameters.Add(input, Convert.ToDecimal(form[input]));
                }
                else if (_intAttr.Contains(input))
                {
                    parameters.Add(input, Convert.ToInt32(form[input]));
                }
                else
                {
                    parameters.Add(input, form[input]);
                }
            }
            
            //Checks methodName and calls corresponding method
            try
            {   
                foreach(var m in _methods)
                {
                    if(m.Name.Equals(methodName))
                    {
                        response = ConvertResponse(_controller.ExecuteMethod(methodName, parameters));
                    }
                }
               
            } catch(Exception e)
            {
                Console.WriteLine("Execution error: " +e.Message);
            }

            return response != null ? View("Response", response) : View("Response", (Response) null);
        }

        public ActionResult MethodView(string viewName)
        {
            On_Load();
            try
            {

                int index = 0;
                for (int i = 0; i < _methods.Count; i++)
                {
                    if (_methods[i].Name.Equals(viewName))
                    {
                        index = i;
                    }
                }
                var modelToLoad = _methods[index];
                if (modelToLoad.Format.Equals("default"))
                {
                    return PartialView("_MethodView", modelToLoad);
                }
                else
                {
                    return PartialView(modelToLoad.Format, modelToLoad);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        private void On_Load()
        {
            _controller.Load();
            _methods = ConvertMethod(_controller.GetMethods());
        }

        public ActionResult GetAll()
        {
            On_Load();
            var methodNames = new List<string>();

            foreach (var m in _methods)
            {
                methodNames.Add(m.Name);
            }

            return PartialView("_Sidebar", methodNames);

        }

        private List<WebMethod> ConvertMethod(List<TestInsuranceServiceAPI.Models.WebMethod> data)
        {
            List<WebMethod> output = new List<WebMethod>();
            foreach (var obj in data)
            {
                
                WebMethod target = new WebMethod();
                var source = obj;
                target = ObjectMapper<TestInsuranceServiceAPI.Models.WebMethod,WebMethod>.MapObject(ref source, ref target);
                
                output.Add(target);
            }
            return output;
        }

        private Response ConvertResponse(TestInsuranceServiceAPI.Models.Response data)
        {
            Response output = new Response();
            ObjectMapper<TestInsuranceServiceAPI.Models.Response, Response>.MapObject(ref data, ref output);

            return output;
        }
    }
}