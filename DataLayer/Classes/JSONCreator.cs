using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace DataLayer.Class
{
    class JSONCreator
    {


        public static string ObjectToJson(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            return json;

        }


        public static void WriteToJsonFile(List<Object> objs)
        {
            List<String> jsonObjs = new List<string>();
            foreach (Object obj in objs)
            {
                jsonObjs.Add(ObjectToJson(obj));
            }
        }
        public static void WriteToJsonFile(Object obj, string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    Console.WriteLine("File Exists, overwriting? (Y/n)");
                    var resp = Console.ReadLine();
                    if (resp.Equals("Y"))
                    {
                        Console.WriteLine("File overwritten, saving");
                        File.Delete(filepath);

                        WriteToFile((string)obj, filepath);
                    }
                    else if (resp.Equals("n"))
                    {
                        Console.WriteLine("File Not overwritten, exiting");

                    }
                }
                else
                {
                    WriteToFile((string)obj, filepath);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Writing failed");
                Console.WriteLine(e.Message + " + " + e.InnerException.Message + " + " + e.Message + " + " + e.StackTrace);
            }
        }

        public static void WriteToFile(String text, string fullfilename)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@fullfilename))
                {
                    sw.WriteLine(text);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<List<String>> LoadFromFile(string path)
        {
            List<List<string>> Object = new List<List<string>>();
            List<string> text = new List<string>();
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader sr = new StreamReader(path + "description.txt"))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            text.Add(line);
                        }
                        Object.Add(text);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Description not found");
                }
                try
                {
                    using (StreamReader sr = new StreamReader(path + "code.txt"))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            text.Add(line);
                        }
                        Object.Add(text);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Code not found");

                }
                try
                {
                    using (StreamReader sr = new StreamReader(path + "properties.txt"))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            text.Add(line);
                        }
                        Object.Add(text);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("properties not found");

                }
                try
                {
                    using (StreamReader sr = new StreamReader(path + "methods.txt"))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            text.Add(line);
                        }
                        Object.Add(text);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Methods not found");

                }
                try
                {
                    using (StreamReader sr = new StreamReader(path + "respreq.txt"))
                    {
                        string line = "";
                        while ((line = sr.ReadLine()) != null)
                        {
                            text.Add(line);
                        }
                        Object.Add(text);

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Response not found");

                }
            }
            else
            {
                Console.WriteLine("File Doesn't Exist");
            }

            return null;
        }


    }
}
