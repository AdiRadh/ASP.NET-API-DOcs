/*using System;
using System.Collections.Generic;
using TestInsuranceServiceAPI.InsuranceService;
using TestInsuranceServiceAPI.Models;

namespace TestInsuranceServiceAPI.Classes
{
    class ServiceManager : IServiceManager
    {
        private readonly InsuranceWebService _insuranceWebService = new InsuranceWebService();

        private static Response MethodRespToObject(object resp)
        {
            var responseObj = new Response();

            foreach (var p in resp.GetType().GetProperties())
            {
                foreach (var r in responseObj.GetType().GetProperties())
                {
                    if (!p.Name.Equals(r.Name) || p.GetValue(resp) == null) continue;
                    var h = p.PropertyType;
                    if (h == typeof(string[]))
                    {
                        var list = new List<string>((string[])p.GetValue(resp));

                        r.SetValue(responseObj, list);

                    }
                    else if (h == typeof(int[]))
                    {
                        var list = new List<int>((int[])p.GetValue(resp));
                        r.SetValue(responseObj, list);

                    }
                    else if (h == typeof(bool[]))
                    {
                        var list = new List<bool>((bool[])p.GetValue(resp));
                        r.SetValue(responseObj, list);

                    }
                    else
                    {
                        r.SetValue(responseObj, p.GetValue(resp));
                    }
                }
            }

            return responseObj;
        }

        public Response GetDetailProductListRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest
                {
                    Username = (string)parameters["Username"],
                    Password = "",
                    AuthenticationKey = (string)parameters["AuthenticationKey"],
                    SearchDate = (DateTime)parameters["SearchDate"]
                };
                insReq.Session = sess;
                var response = _insuranceWebService.GetDetailedProductListRequest(sess.Username, sess.AuthenticationKey, sess.Password, sess.SearchDate);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response CancelPolicyByInsurance(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var cancel = new CancelRequest();
                sess.Username = (string)parameters["username"];
                sess.Password = "";

                sess.AuthenticationKey = (string)parameters["AuthenticationKey"];
                cancel.AccountID = (string)parameters["accountid"];
                cancel.CancellationReason = (string)parameters["cancellationreason"];
                cancel.CertificateNumber = (string)parameters["certificatenumber"];
                cancel.ContactEmail = (string)parameters["contactemail"];
                cancel.DealerName = (string)parameters["dealername"];
                cancel.Surname = (string)parameters["surname"];
                cancel.RequestValidation = (bool)parameters["requestvalidation"];
                cancel.RefundCustomer = (string)parameters["refundcustomer"];

                cancel.PhoenixCancellation = null;

                insReq.Session = sess;
                insReq.Cancellation = cancel;

                var response = _insuranceWebService.CancelPolicyByInsuranceRequest(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response CreateCustomer(Dictionary<string, object> parameters)
        {
            try
            {
                CustomerDetailsRequest cusReq = new CustomerDetailsRequest();
                var sess = new SessionRequest();
                var vehicle = new VehicleRequest();
                var client = new ClientRequest();
                sess.Username = (string)parameters["username"];
                sess.AuthenticationKey = (string)parameters["AuthenticationKey"];
                client.FirstName = (string)parameters["firstname"];
                client.Surname = (string)parameters["surname"];
                client.Title = (string)parameters["title"];
                client.HouseNumber = (string)parameters["housenumber"];
                client.Address = (string)parameters["address"];
                client.Postcode = (string)parameters["postcode"];
                client.Email = (string)parameters["email"];
                client.Telephone = (string)parameters["telephone"];
                client.Contact_by_email = (bool)parameters["contact_by_email"];
                client.Contact_by_phone = (bool)parameters["contact_by_phone"];
                client.Contact_by_post = (bool)parameters["contact_by_post"];
                client.Contact_by_text = (bool)parameters["contact_by_text"];
                client.DateOfBirth = (DateTime)parameters["dateofbirth"];
                client.Mobile = (string)parameters["mobile"];
                client.IsCompany = (bool)parameters["iscompany"];
                sess.DealerFittedAccessoriesValue = (decimal)parameters["dealerfittedaccessories"];
                vehicle.Make = (string)parameters["make"];
                vehicle.Model = (string)parameters["model"];
                vehicle.Registration = (string)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.MOTDate = (DateTime)parameters["motdate"];
                vehicle.Fuel = (string)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];
                vehicle.AntilockBrakes = (bool)parameters["antilockbrakes"];
                vehicle.AirConditioner = (bool)parameters["airconditioner"];
                vehicle.FourWheelDrive = (bool)parameters["fourwheeldrive"];
                vehicle.Turbo = (bool)parameters["turbo"];
                vehicle.SpecialCategory = (bool)parameters["specialcategory"];
                vehicle.Automatic = (bool)parameters["automatic"];

                cusReq.Session = sess;
                cusReq.Client = client;
                cusReq.Vehicle = vehicle;
                var response = _insuranceWebService.CreateCustomer(cusReq);
                return MethodRespToObject(response);


            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response CreatePolicyByInsuranceRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var vehicle = new VehicleRequest();
                var client = new ClientRequest();
                var policy = new PolicyRequest();
                var bank = new BankRequest();
                var loan = new LoanRequest();
                sess.Username = (string)parameters["username"];
                sess.AuthenticationKey = (string)parameters["sess.AuthenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (string)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];

                client.FirstName = (string)parameters["firstname"];
                client.Surname = (string)parameters["surname"];
                client.Title = (string)parameters["title"];
                client.HouseNumber = (string)parameters["housenumber"];
                client.Address = (string)parameters["address"];
                client.Postcode = (string)parameters["postcode"];
                client.Email = (string)parameters["email"];
                client.Telephone = (string)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];
                client.DateOfBirth = (DateTime)parameters["dateofbirth"];
                policy.Description = (string)parameters["description"];
                policy.Plan = (string)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (string)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                policy.DatePISupplied = (DateTime)parameters["datepisupplied"];
                policy.ExternalReference = (string)parameters["externalreference"];
                policy.DateCustomerConfirmed = (DateTime)parameters["datecustomerconfirmed"];

                vehicle.Make = (string)parameters["make"];
                vehicle.Model = (string)parameters["model"];
                vehicle.Registration = (string)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.MOTDate = (DateTime)parameters["motdate"];
                vehicle.Fuel = (string)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                bank.AccountName = (string)parameters["accountname"];
                bank.AccountNumber = (string)parameters["accountnumber"];
                bank.PaperlessDDI = (bool)parameters["paperlessddi"];
                bank.PayeeAddress = (string)parameters["payeeaddress"];
                bank.PayeeFirstName = (string)parameters["payeefirstname"];
                bank.PayeeSurname = (string)parameters["payeesurname"];
                bank.PayeeAddress = (string)parameters["payeehousenumber"];
                bank.PayeePostcode = (string)parameters["payeepostcode"];
                bank.PayeeTitle = (string)parameters["payeetitle"];
                bank.SortCode = (string)parameters["sortcode"];
                bank.PolicyHolderPaying = (bool)parameters["policyholderpaying"];
                loan.Advance = (decimal)parameters["advance"];
                loan.AdvanceRentals = (int)parameters["advancerentals"];
                loan.LoanPayment = (decimal)parameters["loanpayment"];
                loan.LoanTerm = (int)parameters["loanterm"];
                loan.BorrowerName = (string)parameters["borrowername"];
                loan.Lender = (string)parameters["lender"];
                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;
                insReq.Bank = bank;
                insReq.Loan = loan;

                var response = _insuranceWebService.CreatePolicyByInsuranceRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response GetIncludedMakesRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var vehicle = new VehicleRequest();
                var client = new ClientRequest();
                var policy = new PolicyRequest();

                sess.Username = (string)parameters["username"];
                sess.AuthenticationKey = (string)parameters["AuthenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (string)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];

                client.FirstName = (string)parameters["firstname"];
                client.Surname = (string)parameters["surname"];
                client.Title = (string)parameters["title"];
                client.HouseNumber = (string)parameters["housenumber"];
                client.Address = (string)parameters["address"];
                client.Postcode = (string)parameters["postcode"];
                client.Email = (string)parameters["email"];
                client.Telephone = (string)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];

                policy.Description = (string)parameters["description"];
                policy.Plan = (string)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (string)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];

                vehicle.Make = (string)parameters["make"];
                vehicle.Model = (string)parameters["model"];
                vehicle.Registration = (string)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (string)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = _insuranceWebService.GetIncludedMakesRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
        public Response GetMakesRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var response = _insuranceWebService.GetMakesRequest();
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response GetLendersRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var response = _insuranceWebService.GetLendersRequest();
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response GetReportsListRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var response = _insuranceWebService.GetReportsListRequest();
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response GetProductListRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var vehicle = new VehicleRequest();


                sess.Username = (string)parameters["username"];
                sess.Password = "";
                sess.AuthenticationKey = (string)parameters["authenticationKey"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];
                vehicle.Price = (decimal)parameters["price"];

                insReq.Session = sess;
                insReq.Vehicle = vehicle;

                var response = _insuranceWebService.GetProductListRequest(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
        public Response GetSavedDetailsListRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();

                sess.Username = (string)parameters["username"];
                sess.Password = "";
                sess.AuthenticationKey = (string)parameters["authenticationkey"];
                insReq.Session = sess;

                var response = _insuranceWebService.GetSavedDetailsListRequest(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response MTAPolicyByInsuranceRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest(); var mta = new AdjustRequest();
                sess.Username = (string)parameters["username"];
                sess.Password = "";
                sess.AuthenticationKey = (string)parameters["authenticationKey"];
                mta.AccountID = (string)parameters["accountid"];
                mta.Contact = (string)parameters["contact"];
                mta.Details = (string)parameters["details"];
                mta.PolicyNumber = (string)parameters["policynumber"];
                mta.MTAReason = (string)parameters["mtareason"];
                mta.DealerName = (string)parameters["dealername"];
                mta.Surname = (string)parameters["surname"];
                insReq.MTA = mta;
                insReq.Session = sess;
                var response = _insuranceWebService.MTAPolicyByInsuranceRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
        public Response ReprintPolicyRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var document = new DocumentRequest();
                sess.Username = (string)parameters["username"];
                sess.Password = "";
                document.CertificateNumber = (string)parameters["certificatenumber"];
                document.PrintCertificate = (bool)parameters["printcertificate"];
                document.PrintPolicySummary = (bool)parameters["printpolicysummary"];
                document.PrintTermsandConditions = (bool)parameters["printtermsandconditions"];
                document.PrintStatementofPrice = (bool)parameters["printstatementofprice"];
                document.PrintDirectDebit = (bool)parameters["printdirectdebit"];
                insReq.Documents = document;
                insReq.Session = sess;
                var response = _insuranceWebService.ReprintPolicyRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
        public Response ValidatePolicy(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var vehicle = new VehicleRequest();
                var client = new ClientRequest();
                var policy = new PolicyRequest();

                sess.Username = (string)parameters["username"];
                sess.AuthenticationKey = (string)parameters["authenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (string)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];


                client.FirstName = (string)parameters["firstname"];
                client.Surname = (string)parameters["surname"];
                client.Title = (string)parameters["title"];
                client.HouseNumber = (string)parameters["housenumber"];
                client.Address = (string)parameters["address"];
                client.Postcode = (string)parameters["postcode"];
                client.Email = (string)parameters["email"];
                client.Telephone = (string)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];
                policy.Description = (string)parameters["description"];
                policy.Plan = (string)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (string)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                vehicle.Make = (string)parameters["make"];
                vehicle.Model = (string)parameters["model"];
                vehicle.Registration = (string)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (string)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Vehicle = vehicle;
                insReq.Policy = policy;
                var response = _insuranceWebService.ValidatePolicyRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response ChangePassword(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest
                {
                    Username = (string)parameters["username"],
                    Password = (string)parameters["password"],
                    NewPassword = (string)parameters["newpassword"]
                };
                insReq.Session = sess;
                var response = _insuranceWebService.ChangePasswordRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
        public Response GetReprintListRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest
                {
                    Username = (string)parameters["username"],
                    Password = "",
                    AuthenticationKey = (string)parameters["authenticationkey"],
                    SearchDate = (DateTime)parameters["searchdate"]
                };
                insReq.Session = sess;
                var response = _insuranceWebService.GetReprintListRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response PrintReport(Dictionary<string, object> parameters)
        {
            try
            {
                var account = (string)parameters["account"];
                var authenticationKey = (string)parameters["authenticationkey"];
                var reportId = (string)parameters["reportid"];
                var reportDate = (DateTime)parameters["reportdate"];
                var response = _insuranceWebService.PrintReportRequest(account, authenticationKey, reportId, reportDate);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
        public Response ValidateLogin(Dictionary<string, object> parameters)
        {
            try
            {

                string username = (string)parameters["username"];
                string password = "";
                string authenticationKey = (string)parameters["authenticationkey"];

                var response = _insuranceWebService.ValidateLogin(username, password, authenticationKey);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }


        public Response CreateAndHandlePI(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();

                var vehicle = new VehicleRequest();
                var client = new ClientRequest();

                var policy = new PolicyRequest();
                var sess = new SessionRequest
                {
                    Username = (string)parameters["username"],
                    AuthenticationKey = (string)parameters["AuthenticationKey"],
                    Account = (string)parameters["account"],
                    DeliveryDate = (DateTime)parameters["deliverydate"]
                };

                client.FirstName = (string)parameters["firstname"];
                client.Surname = (string)parameters["surname"];
                client.Title = (string)parameters["title"];
                client.HouseNumber = (string)parameters["housenumber"];
                client.Address = (string)parameters["address"];
                client.Postcode = (string)parameters["postcode"];
                client.Email = (string)parameters["email"];
                client.Telephone = (string)parameters["telephone"];
                client.Employer = (string)parameters["employer"];
                client.Mobile = (string)parameters["mobile"];
                client.Occupation = (string)parameters["occupation"];

                policy.Description = (string)parameters["description"];
                policy.Plan = (string)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (string)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                policy.StartDate = (DateTime)parameters["startdate"];

                vehicle.Make = (string)parameters["make"];
                vehicle.Model = (string)parameters["model"];
                vehicle.Registration = (string)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (string)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = _insuranceWebService.CreateAndHandlePI(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response SavePI(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var vehicle = new VehicleRequest();
                var client = new ClientRequest();
                var policy = new PolicyRequest();

                sess.Username = (string)parameters["username"];
                sess.AuthenticationKey = (string)parameters["AuthenticationKey"];
                sess.Account = (string)parameters["account"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];

                client.FirstName = (string)parameters["firstname"];
                client.Surname = (string)parameters["surname"];
                client.Title = (string)parameters["title"];
                client.HouseNumber = (string)parameters["housenumber"];
                client.Address = (string)parameters["address"];
                client.Postcode = (string)parameters["postcode"];
                client.Email = (string)parameters["email"];
                client.Telephone = (string)parameters["telephone"];
                client.Employer = (string)parameters["employer"];
                client.Mobile = (string)parameters["mobile"];
                client.Occupation = (string)parameters["occupation"];

                policy.Description = (string)parameters["description"];
                policy.Plan = (string)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (string)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                policy.StartDate = (DateTime)parameters["startdate"];

                vehicle.Make = (string)parameters["make"];
                vehicle.Model = (string)parameters["model"];
                vehicle.Registration = (string)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (string)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = _insuranceWebService.SavePI(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }


        public Response SavePolicyDetailsRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();
                var vehicle = new VehicleRequest();
                var client = new ClientRequest();
                var policy = new PolicyRequest();

                sess.Username = (string)parameters["username"];
                sess.AuthenticationKey = (string)parameters["AuthenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (string)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];

                client.FirstName = (string)parameters["firstname"];
                client.Surname = (string)parameters["surname"];
                client.Title = (string)parameters["title"];
                client.HouseNumber = (string)parameters["housenumber"];
                client.Address = (string)parameters["address"];
                client.Postcode = (string)parameters["postcode"];
                client.Email = (string)parameters["email"];
                client.Telephone = (string)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];

                policy.Description = (string)parameters["description"];
                policy.Plan = (string)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (string)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];

                vehicle.Make = (string)parameters["make"];
                vehicle.Model = (string)parameters["model"];
                vehicle.Registration = (string)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (string)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = _insuranceWebService.SavePolicyDetailsRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                if (e.InnerException != null) Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
    }

}
*/