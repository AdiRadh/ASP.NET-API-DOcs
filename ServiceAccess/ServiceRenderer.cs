using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestInsuranceServiceSite.Models;

namespace ServiceAccess
{
    class ServiceRenderer
    {

        public static void WSDLReader(string webservice)
        {
            string webserviceName = "~/Connected Services/"+webservice + ".wsdl";
            
            List<string> wsdl = new List<string>();
            List<WebMethod> serviceMethods = new List<WebMethod>();
            try
            {
                using (StreamReader sr = new StreamReader(webserviceName))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        wsdl.Add(line);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Failed in Rendering Service Information: "+e.Message+" "+e.StackTrace);
            }
        }
        private static void FindMethods(List<string> wsdl)
        {
            List<WebMethod> serviceMethods = new List<WebMethod>();
            List<string> methodText = new List<string>();
            WebMethod currentMethod = new WebMethod();
            bool isMethod = false;
            foreach (string line in wsdl)
            {
                if (line.Contains("<s:element") && line.Contains("\">"))
                {
                    string[] arr = line.Split(new string[] { "name=\"", "\">" }, StringSplitOptions.RemoveEmptyEntries);
                    currentMethod.methodName = arr[1];
                    isMethod = true;
                    methodText.Add(line);
                }

                if(isMethod)
                {
                    methodText.Add(line);
                }

                if(isMethod && line.Contains("s:element>"))
                {
                    methodText.Add(line);
                    FindAttributes(methodText);
                    methodText.Clear();
                    isMethod = false;
                }
            }
        }

        private static void FindAttributes(List<string> methodData)
        {
            WebMethod currentMethod = new WebMethod();                      
            foreach (string line in methodData)
            {
                if (line.Contains("<s:element") && line.Contains("\">"))
                {
                    string[] arr = line.Split(new string[] { "name=\"", "\">" }, StringSplitOptions.RemoveEmptyEntries);
                    currentMethod.methodName = arr[1];
                }

                    if (line.Contains("<s:element") && line.Contains(" />"))
                {
                    string[] attributes = line.Split(new string[] { "name=\"", "\" type=\"", "\" />" }, StringSplitOptions.RemoveEmptyEntries);
                    string attr = attributes[1] + ": " + (attributes[2].Replace("s:",""));
                    currentMethod.parameters.Add(attr);
                }
            }
        }

    }

}
