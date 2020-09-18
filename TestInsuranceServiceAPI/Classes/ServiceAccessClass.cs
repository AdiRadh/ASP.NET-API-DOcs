using System;
using System.Collections.Generic;
using TestInsuranceServiceAPI.Models;

namespace TestInsuranceServiceAPI.Classes
{
    public class ServiceAccessClass
    {
        private readonly IServiceManager _serviceManager = new ServiceManager();
        public Response ExampleMethod(Dictionary<string, object> parameters)
        {
            return _serviceManager.ExampleMethod(parameters);
        }
    }
}
