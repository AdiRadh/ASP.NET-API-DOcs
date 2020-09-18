using System;
using System.Collections.Generic;
using ServiceAccess.Object;

namespace ServiceAccess
{
    public interface IServiceManager
    {
        Response GetDetailProductListRequest(Dictionary<string, object> parameters);
        Response CancelPolicyByInsurance(Dictionary<string, object> parameters);
        Response CreateCustomer(Dictionary<string, object> parameters);
        Response CreatePolicyByInsuranceRequest(Dictionary<string, object> parameters);
        Response GetIncludedMakesRequest(Dictionary<string, object> parameters);
        Response GetMakesRequest(Dictionary<string, object> parameters);
        Response GetLendersRequest(Dictionary<string, object> parameters);
        Response GetReportsListRequest(Dictionary<string, object> parameters);
        Response GetProductListRequest(Dictionary<string, object> parameters);
        Response GetSavedDetailsListRequest(Dictionary<string, object> parameters);
        Response MTAPolicyByInsuranceRequest(Dictionary<string, object> parameters);
        Response ReprintPolicyRequest(Dictionary<string, object> parameters);
        Response ValidatePolicy(Dictionary<string, object> parameters);
        Response ChangePassword(Dictionary<string, object> parameters);
        Response GetReprintListRequest(Dictionary<string, object> parameters);
        Response PrintReport(Dictionary<string, object> parameters);
        Response ValidateLogin(Dictionary<string, object> parameters);
        Response CreateAndHandlePI(Dictionary<string, object> parameters);
        Response SavePI(Dictionary<string, object> parameters);
        Response SavePolicyDetailsRequest(Dictionary<string, object> parameters);

    }
}
