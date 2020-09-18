using DataLayer.Class;
using DataLayer.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DataLayer
{

    public class DataProcessor
    {
        private List<string> ResponseFileNames = new List<string>();
        private List<string> RequestFileNames = new List<string>();
        private List<string> MethodFileNames = new List<string>();
        private List<ServiceObject> Requests = new List<ServiceObject>();
        private List<ServiceObject> Responses = new List<ServiceObject>();
        private List<WebMethod> Methods = new List<WebMethod>();
        private List<String> BoolLimits = new List<string>();
        private List<String> IntegerLimits = new List<string>();
        private List<String> DecimalLimits = new List<string>();


        private string loadPath;

        public DataProcessor(string path)
        {
            loadPath = path;
        }

        public List<ServiceObject> GetResponses()
        {
            return Responses;
        }
        public List<ServiceObject> GetRequests()
        {
            return Requests;
        }
        public List<WebMethod> GetMethods()
        {
            return Methods;
        }
        public void Load()
        {
            RequestFileNames.Add("IPIDRequest");
            RequestFileNames.Add("ProductDetailsRequest");
            RequestFileNames.Add("InsuranceRequest");
            RequestFileNames.Add("CustomerDetailsRequest");

            ResponseFileNames.Add("IPIDResponse");
            ResponseFileNames.Add("ProductDetailsResponse");
            ResponseFileNames.Add("InsuranceResponse");
            ResponseFileNames.Add("QuoteResponse");
            ResponseFileNames.Add("SaveCustomerDetailsResponse");
            ResponseFileNames.Add("GetIncludedMake");
            ResponseFileNames.Add("GetDetailedProduct");
            ResponseFileNames.Add("GetLender");
            ResponseFileNames.Add("GetMake");
            ResponseFileNames.Add("GetProductList");
            ResponseFileNames.Add("ReportCollection");
            ResponseFileNames.Add("GetReprintList");
            ResponseFileNames.Add("GetSavedDetailsList");
            ResponseFileNames.Add("PrintSingleReportResponse");
            ResponseFileNames.Add("ValidationDetails");


            MethodFileNames.Add("CancelPolicyByInsurance");
            MethodFileNames.Add("ChangePassword");
            MethodFileNames.Add("CreateAndHandlePI");
            MethodFileNames.Add("CreateCustomer");
            MethodFileNames.Add("CreatePolicyByInsuranceRequest");
            MethodFileNames.Add("GetDetailedProductListRequest");
            MethodFileNames.Add("GetIncludedMakesRequest");
            MethodFileNames.Add("GetLendersRequest");
            MethodFileNames.Add("GetMakesRequest");
            MethodFileNames.Add("GetReportsListRequest");
            MethodFileNames.Add("GetReprintListRequest");
            MethodFileNames.Add("GetSavedDetailsListRequest");
            MethodFileNames.Add("MTAPolicyByInsuranceRequest");
            MethodFileNames.Add("PrintReport");
            MethodFileNames.Add("ReprintPolicyRequest");
            MethodFileNames.Add("SavePI");
            MethodFileNames.Add("SavePolicyDetailsRequest");
            MethodFileNames.Add("ValidateLogin");
            MethodFileNames.Add("ValidatePolicy");
        }

        public void RenderFromText()
        {
            Load();

            string filepath = loadPath;
            string filetype = @"Request\";
            var ReqDirectories = Directory.GetDirectories(Path.Combine(filepath, filetype));
            foreach (string file in ReqDirectories)
            {
                ServiceObject request = new ServiceObject();
                DirectoryInfo dir = new DirectoryInfo(file);
                request.Name = dir.Name;
                using (StreamReader sr = new StreamReader(Path.Combine(file, "description.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        request.Description += line + " \n";
                    }

                }
                using (StreamReader sr = new StreamReader(Path.Combine(file, "properties.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] prop = line.Split(':');
                        request.Properties.Add(prop[0], prop[1]);
                    }
                }
                request.Code = "";
                request.IsResponse = false;
                using (StreamReader sr = new StreamReader(Path.Combine(file, "format.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        request.Format = line;
                    }
                }

                Requests.Add(request);
            }

            filetype = @"Response\";
            var RespDirectories = Directory.GetDirectories(Path.Combine(filepath, filetype));
            foreach (string file in RespDirectories)
            {
                ServiceObject response = new ServiceObject();
                DirectoryInfo dir = new DirectoryInfo(file);
                response.Name = dir.Name;
                using (StreamReader sr = new StreamReader(Path.Combine(file, "description.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        response.Description += line + " \n";
                    }
                }
                using (StreamReader sr = new StreamReader(Path.Combine(file, "properties.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] prop = line.Split(':');
                        response.Properties.Add(prop[0], prop[1]);
                    }
                }
                response.Code = "";
                response.IsResponse = true;
                using (StreamReader sr = new StreamReader(Path.Combine(file, "format.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        response.Format = line;
                    }
                }

                Responses.Add(response);
            }

            filetype = @"Methods\";
            var MethodDirectories = Directory.GetDirectories(Path.Combine(filepath, filetype));
            foreach (string file in MethodDirectories)
            {
                WebMethod method = new WebMethod();
                DirectoryInfo dir = new DirectoryInfo(file);
                method.MethodName = dir.Name;
                using (StreamReader sr = new StreamReader(Path.Combine(file, "description.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        method.Description += line + " \n";
                    }
                }
                using (StreamReader sr = new StreamReader(Path.Combine(file, "properties.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] prop = line.Split(':');
                        method.Parameters.Add(prop[0], prop[1]);
                    }
                }
                using (StreamReader sr = new StreamReader(Path.Combine(file, "respreq.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] prop = line.Split(':');
                        method.Request = prop[0];
                        method.Response = prop[1];
                    }
                }
                using (StreamReader sr = new StreamReader(Path.Combine(file, "format.txt")))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        method.Format = line;
                    }
                }
                Methods.Add(method);

            }

        }

        public void RenderFromFiles()
        {
            Load();

            //Change path as required
            string filepath = @"Json\";
            string filetype = @"Request\";
            Dictionary<string, string> tables = new Dictionary<string, string>();
            string path = "";
            List<List<string>> Object = new List<List<string>>();

            /*
            * Rendering Requests from files 
            */

            foreach (string file in RequestFileNames)
            {
                path = filepath + filetype + file + ".txt";

                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ServiceObject obj = JsonConvert.DeserializeObject<ServiceObject>(line);
                        Requests.Add(obj);
                    }
                }
            }
            /*
            * Rendering Responses from files 
            */

            filetype = "Response\\";

            foreach (string file in ResponseFileNames)
            {
                path = filepath + filetype + file + "\\";
                path = filepath + filetype + file + ".txt";

                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        ServiceObject obj = JsonConvert.DeserializeObject<ServiceObject>(line);
                        Responses.Add(obj);
                    }
                }

            }

            /**
             * Rendering Methods from files 
             **/
            filetype = "Methods\\";


            foreach (string file in MethodFileNames)
            {
                path = filepath + filetype + file + ".txt";
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        WebMethod obj = JsonConvert.DeserializeObject<WebMethod>(line);
                        Methods.Add(obj);
                    }
                }
            }
        }

        private void ToJson()
        {
            string path = @"Json\";
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }

            string request = Path.Combine(path, "Request");
            foreach (ServiceObject req in Requests)
            {
                using (StreamWriter file = File.CreateText(Path.Combine(request, req.Name + ".txt")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, req);
                }

            }

            string response = Path.Combine(path, "Response");
            foreach (ServiceObject resp in Requests)
            {
                using (StreamWriter file = File.CreateText(Path.Combine(response, resp.Name + ".txt")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, resp);
                }

            }

            string method = Path.Combine(path, "Method");
            foreach (WebMethod meth in Methods)
            {
                using (StreamWriter file = File.CreateText(Path.Combine(method, meth.MethodName + ".txt")))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    //serialize object directly into file stream
                    serializer.Serialize(file, meth);
                }

            }
        }

        internal void SetAllFormatsToDefault()
        {
            string path = @"\Setup\";
            string req = Path.Combine(path, "Request");
            string resp = Path.Combine(path, "Response");
            string meth = Path.Combine(path, "Methods");

            foreach (string filename in RequestFileNames)
            {
                string filepath = Path.Combine(req, filename + @"\respreq.txt");
                using (StreamWriter file = File.CreateText(filepath))
                {
                    file.WriteLine("default:default");
                }
            }
            foreach (string filename in ResponseFileNames)
            {
                string filepath = Path.Combine(resp, filename + @"\respreq.txt");
                using (StreamWriter file = File.CreateText(filepath))
                {
                    file.WriteLine("default:default");
                }
            }
            foreach (string filename in MethodFileNames)
            {
                string filepath = Path.Combine(meth, filename + @"\respreq.txt");
                using (StreamWriter file = File.CreateText(filepath))
                {
                    file.WriteLine("default:default");
                }
            }

        }
    }
}