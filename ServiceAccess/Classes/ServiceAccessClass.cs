using System;
using System.Collections.Generic;
using ServiceAccess.Object;

namespace ServiceAccess
{
    public class ServiceAccessClass
    {

        IServiceManager serviceManager = new ServiceManager();
        public Response GetDetailProductListRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetDetailProductListRequest(parameters);
        }
        public Response CancelPolicyByInsurance(Dictionary<string, object> parameters)
        {
            return serviceManager.CancelPolicyByInsurance(parameters);
        }
        public Response CreateCustomer(Dictionary<string, object> parameters)
        {
            return serviceManager.CreateCustomer(parameters);
        }
        public Response CreatePolicyByInsuranceRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.CreatePolicyByInsuranceRequest(parameters);
        }
        public Response GetIncludedMakesRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetIncludedMakesRequest(parameters);
        }
        public Response GetMakesRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetMakesRequest(parameters);
        }
        public Response GetLendersRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetLendersRequest(parameters);
        }
        public Response GetReportsListRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetReportsListRequest(parameters);
        }
        public Response GetProductListRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetProductListRequest(parameters);
        }
        public Response GetSavedDetailsListRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetSavedDetailsListRequest(parameters);
        }
        public Response MTAPolicyByInsuranceRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.MTAPolicyByInsuranceRequest(parameters);
        }
        public Response ReprintPolicyRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.ReprintPolicyRequest(parameters);
        }
        public Response ValidatePolicy(Dictionary<string, object> parameters)
        {
            return serviceManager.ValidatePolicy(parameters);
        }
        public Response ChangePassword(Dictionary<string, object> parameters)
        {
            return serviceManager.ChangePassword(parameters);
        }
        public Response GetReprintListRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.GetReprintListRequest(parameters);
        }
        public Response PrintReport(Dictionary<string, object> parameters)
        {
            return serviceManager.PrintReport(parameters);
        }
        public Response ValidateLogin(Dictionary<string, object> parameters)
        {
            return serviceManager.ValidateLogin(parameters);
        }
        public Response CreateAndHandlePI(Dictionary<string, object> parameters)
        {
            return serviceManager.CreateAndHandlePI(parameters);
        }
        public Response SavePI(Dictionary<string, object> parameters)
        {
            return serviceManager.SavePI(parameters);
        }
        public Response SavePolicyDetailsRequest(Dictionary<string, object> parameters)
        {
            return serviceManager.SavePolicyDetailsRequest(parameters);
        }
    }
}
