using TestInsuranceServiceAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestInsuranceServiceAPI.Classes
{

    public class DataProcessor
    {
        //List of file names for Response/Request/Methods
        private readonly List<string> _responseFileNames = new List<string>();
        private readonly List<string> _requestFileNames = new List<string>();
        private readonly List<string> _methodFileNames = new List<string>();

        //All Request/Response/Method Objects found
        private readonly List<ServiceObject> _requests = new List<ServiceObject>();
        private readonly List<ServiceObject> _responses = new List<ServiceObject>();
        private readonly List<WebMethod> _methods = new List<WebMethod>();

        //Config Load Path
        private readonly string _loadPath;

        public DataProcessor(string path)
        {
            _loadPath = path;
            //If Json versions exist, use Json Loading
            if (Directory.Exists(Path.Combine(_loadPath, "Json")))
            {
                LoadFromJson();
            }
            else //If Json versions don't exist, render objects from text files
            {
                RenderFromText();
                ToJson();
            }

        }

        //Get methods for Responses/Requests/Methods
        public List<ServiceObject> GetResponses()
        {
            return _responses;
        }
        public List<ServiceObject> GetRequests()
        {
            return _requests;
        }
        public List<WebMethod> GetMethods()
        {
            return _methods;
        }

        //Loads file names
        public void Load(bool json)
        {
            string path;
            string[] dir;
            if (json) //If Json version exists
            {
                path = Path.Combine(_loadPath, "Json");
                dir = Directory.GetDirectories(path);
                foreach (var folder in dir)
                {
                    //Gets all file names from respective folders
                    var list = Directory.GetFiles(folder);
                    switch (Path.GetDirectoryName(folder))
                    {
                        case "Methods":
                            _methodFileNames.AddRange(list);
                            break;
                        case "Requests":
                            _requestFileNames.AddRange(list);
                            break;
                        case "Responses":
                            _responseFileNames.AddRange(list);
                            break;
                        
                    }
                }
            }
            else //If rendering from text
            {
                path = Path.Combine(_loadPath, "Setup");
                dir = Directory.GetDirectories(path);
                
                foreach (var folder in dir)
                {
                    //Gets all filenames from respective folders
                    var objects = new DirectoryInfo(folder).GetDirectories();
                    List<string> list = new List<string>();
                    foreach(var obj in objects)
                    {
                        list.Add(obj.Name);
                    }

                    var name = new DirectoryInfo(folder).Name;
                    switch(name)
                    {
                        case "Methods":
                            _methodFileNames.AddRange(list);
                            break;
                        case "Request":
                            _requestFileNames.AddRange(list);
                            break;
                        case "Response":
                            _responseFileNames.AddRange(list);
                            break;

                    }
                }
            }
        }

        public void RenderFromText()
        {
            Load(false);
            try
            {
                var filepath = Path.Combine(_loadPath, "Setup");
                var filetype = @"Request\";
                var reqDirectories = Directory.GetDirectories(Path.Combine(filepath, filetype));
                foreach (var file in reqDirectories)
                {
                    var request = new ServiceObject();
                    var dir = new DirectoryInfo(file);
                    request.Name = dir.Name;
                    using (var sr = new StreamReader(Path.Combine(file, "description.txt")))
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

                    request.IsCode = false;
                    request.IsResponse = false;
                    using (StreamReader sr = new StreamReader(Path.Combine(file, "format.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            request.Format = line;
                        }
                    }

                    _requests.Add(request);
                }

                filetype = @"Response\";
                var respDirectories = Directory.GetDirectories(Path.Combine(filepath, filetype));
                foreach (var file in respDirectories)
                {
                    var response = new ServiceObject();
                    var dir = new DirectoryInfo(file);
                    response.Name = dir.Name;
                    using (var sr = new StreamReader(Path.Combine(file, "description.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            response.Description += line + " \n";
                        }
                    }
                    using (var sr = new StreamReader(Path.Combine(file, "properties.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var prop = line.Split(':');
                            response.Properties.Add(prop[0], prop[1]);
                        }
                    }
                    response.IsCode = false;
                    response.IsResponse = true;
                    using (var sr = new StreamReader(Path.Combine(file, "format.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            response.Format = line;
                        }
                    }

                    _responses.Add(response);
                }

                filetype = @"Methods\";
                var methodDirectories = Directory.GetDirectories(Path.Combine(filepath, filetype));
                foreach (var file in methodDirectories)
                {
                    var method = new WebMethod();
                    var dir = new DirectoryInfo(file);
                    method.Name = dir.Name;
                    using (var sr = new StreamReader(Path.Combine(file, "description.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            method.Description += line;
                        }
                    }
                    
                    if (File.Exists(Path.Combine(file, "code.txt")))
                    {
                        method.IsCode = File.Exists(Path.Combine(file, "code.txt"));
                        using (var sr = new StreamReader(Path.Combine(file, "code.txt")))
                        {

                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                method.Code += line;
                            }
                        }
                    } 

                    using (var sr = new StreamReader(Path.Combine(file, "properties.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] prop = line.Split(':');
                            method.Parameters.Add(prop[0], prop[1]);
                        }
                    }
                    using (var sr = new StreamReader(Path.Combine(file, "respreq.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            var prop = line.Split(':');
                            method.Request = prop[0];
                            method.Response = prop[1];
                        }
                    }
                    using (var sr = new StreamReader(Path.Combine(file, "format.txt")))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            method.Format = line;
                        }
                    }

                    method.Screenshot = File.Exists(Path.Combine(file, "screen.png"));
                    
                    _methods.Add(method);

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                throw;
            }

        }

        public void ToJson()
        {
            var filepath = Path.Combine(_loadPath, "Json");
            CreateJsonFolder(filepath);
            var filetype = @"Request";
            var count = 0;

            CreateJsonFolder(Path.Combine(filepath, filetype));
            foreach (var objectPath in _requestFileNames.Select(file => Path.Combine(Path.Combine(filepath, filetype), file)))
            {
                File.WriteAllText(objectPath + ".txt", JsonConvert.SerializeObject(_requests[count]));
                count++;
            }

            count = 0;

            filetype = @"Response\";
            CreateJsonFolder(Path.Combine(filepath, filetype));
            foreach (var objectPath in _responseFileNames.Select(file => Path.Combine(Path.Combine(filepath, filetype), file)))
            {
                File.WriteAllText(objectPath + ".txt", JsonConvert.SerializeObject(_responses[count]));
                count++;
            }

            count = 0;

            filetype = @"Methods\";
            CreateJsonFolder(Path.Combine(filepath, filetype));
            foreach (var objectPath in _methodFileNames.Select(file => Path.Combine(Path.Combine(filepath, filetype), file)))
            {
                File.WriteAllText(objectPath + ".txt", JsonConvert.SerializeObject(_methods[count]));
                count++;
            }

        }

        private void LoadFromJson()
        {
            Load(true);

            var filepath = Path.Combine(_loadPath, "Json");
            var filetype = @"Request\";
            var reqDirectories = Directory.GetFiles(Path.Combine(filepath, filetype));
            foreach (var file in reqDirectories)
            {
                var request = JsonConvert.DeserializeObject<ServiceObject>(File.ReadAllText(file));
                if (request.Code == null)
                {
                    request.Code = "";
                }
                _requests.Add(request);
            }

            filetype = @"Response\";
            var respDirectories = Directory.GetFiles(Path.Combine(filepath, filetype));
            foreach (var file in respDirectories)
            {
                var response = JsonConvert.DeserializeObject<ServiceObject>(File.ReadAllText(file));
                if (response.Code == null)
                {
                    response.Code = "";
                }
                _responses.Add(response);
            }

            filetype = @"Methods\";
            var methodDirectories = Directory.GetFiles(Path.Combine(filepath, filetype));
            foreach (var file in methodDirectories)
            {
                var method = JsonConvert.DeserializeObject<WebMethod>(File.ReadAllText(file));
                if (method.Code == null)
                {
                    method.Code = "";
                }
                _methods.Add(method);

            }
        }

        private void CreateJsonFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}