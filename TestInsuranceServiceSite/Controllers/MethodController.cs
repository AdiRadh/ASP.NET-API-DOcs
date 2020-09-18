using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestInsuranceServiceAPI.Classes;
using TestInsuranceServiceSite.Models;

namespace TestInsuranceServiceSite.Controllers
{
    public class MethodController : Controller
    {
        private List<ServiceObject> _requests = new List<ServiceObject>();
        private List<ServiceObject> _responses = new List<ServiceObject>();
        private List<WebMethod> _methods = new List<WebMethod>();

        private readonly TestInsuranceServiceAPI.Controllers.HomeController _loadFromFiles = new TestInsuranceServiceAPI.Controllers.HomeController();


        // GET: Method
        public ActionResult Index()
        {
            On_Load();
            var model = new List<Object> {_methods};

            return View(model);
        }

        public ActionResult RenderPartial(string viewName)
        {
            On_Load();
            try
            {
                WebMethod modelToLoad = new WebMethod();
                foreach (var m in _methods)
                {
                    if (m.Name.Equals(viewName))
                    {
                        modelToLoad = m;
                    }
                }
                return PartialView("_MethodPartial", modelToLoad);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        public ActionResult RenderObject(string viewName)
        {
            On_Load();
            try
            {
                ServiceObject modelToLoad = new ServiceObject();
                foreach (var o in _requests)
                {
                    if (o.Name.Equals(viewName))
                    {
                        modelToLoad = o;
                    }
                }
                foreach (var o in _responses)
                {
                    if (o.Name.Equals(viewName))
                    {
                        modelToLoad = o;
                    }
                }

                return PartialView("_Object", modelToLoad);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

        }

        private void On_Load()
        {
            try
            {
                _loadFromFiles.Load();
                _methods = Convert(_loadFromFiles.GetMethods());
                _requests = Convert(_loadFromFiles.GetRequests());
                _responses = Convert(_loadFromFiles.GetResponses());
            } catch(Exception e)
            {
                Console.WriteLine("Error Loading: " + e.InnerException + " " + e.StackTrace);
            }


        }

        private static List<ServiceObject> Convert(IEnumerable<TestInsuranceServiceAPI.Models.ServiceObject> data)
        {
            List<ServiceObject> output = new List<ServiceObject>();
            foreach(var obj in data)
            {
                ServiceObject target = new ServiceObject();
                var source = obj;
                ObjectMapper<TestInsuranceServiceAPI.Models.ServiceObject, ServiceObject>.MapObject(ref source, ref target);
                output.Add(target);
            }
            return output;
        }

        private List<WebMethod> Convert(IEnumerable<TestInsuranceServiceAPI.Models.WebMethod> data)
        {
            List<WebMethod> output = new List<WebMethod>();
            foreach (var obj in data)
            {
                WebMethod target = new WebMethod();
                var source = obj;
                ObjectMapper<TestInsuranceServiceAPI.Models.WebMethod, WebMethod>.MapObject(ref source, ref target);
                output.Add(target);
            }
            return output;
        }


        public ActionResult GetAll()
        {
            On_Load();
            var allNames = new Dictionary<string, string>();

            foreach (var m in _methods)
            {
                allNames.Add(m.Name, "method");
            }
            foreach(var o in _requests)
            {
                allNames.Add(o.Name, "request");
            }
            foreach (var o in _responses)
            {
                allNames.Add(o.Name, "response");

            }

            return PartialView("_Sidebar", allNames);

        }

        public ActionResult Search(string criteria)
        {
            On_Load();
            var results = (from obj in _requests where obj.Name.ToLower().Contains(criteria.ToLower()) || obj.Description.ToLower().Contains(criteria.ToLower()) select new Search(obj.Name, "ServiceObject")).ToList();
            results.AddRange(from obj in _responses where obj.Name.ToLower().Contains(criteria.ToLower()) || obj.Description.ToLower().Contains(criteria.ToLower()) select new Search(obj.Name, "ServiceObject"));
            results.AddRange(from obj in _methods where obj.Name.ToLower().Contains(criteria.ToLower()) || obj.Description.ToLower().Contains(criteria.ToLower()) select new Search(obj.Name, "WebMethod"));
            return results.Count > 0 ? View("Search",results) : View("SearchFail");
        }
    }
}