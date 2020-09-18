using System;
using System.Collections.Generic;
using ServiceAccess.InsuranceService;
using ServiceAccess.Object;
namespace ServiceAccess
{
    class ServiceManager : IServiceManager
    {
        InsuranceWebService insuranceWebService = new InsuranceWebService();

        private Response MethodRespToObject(object resp)
        {
            Response responseObj = new Response();

            foreach (var p in resp.GetType().GetProperties())
            {
                foreach (var r in responseObj.GetType().GetProperties())
                {
                    if (p.Name.Equals(r.Name) && p.GetValue(resp, null) != null)
                    {
                        var x = p.GetValue(resp, null);
                        var z = p.Name;
                        var h = p.PropertyType;
                        if (h == typeof(string[]))
                        {
                            List<string> list = new List<string>((string[])p.GetValue(resp));
                            r.SetValue(responseObj, list);

                        }
                        else if (h == typeof(int[]))
                        {
                            List<int> list = new List<int>((int[])p.GetValue(resp));
                            r.SetValue(responseObj, list);

                        }
                        else if (h == typeof(bool[]))
                        {
                            List<bool> list = new List<bool>((bool[])p.GetValue(resp));
                            r.SetValue(responseObj, list);

                        }
                        else
                        {
                            r.SetValue(responseObj, p.GetValue(resp));
                        }
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
                    Username = (String)parameters["Username"],
                    Password = "",
                    AuthenticationKey = (String)parameters["AuthenticationKey"],
                    SearchDate = (DateTime)parameters["SearchDate"]
                };
                insReq.Session = sess;
                var response = insuranceWebService.GetDetailedProductListRequest(sess.Username, sess.AuthenticationKey, sess.Password, sess.SearchDate);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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
                sess.Username = (String)parameters["username"];
                sess.Password = "";

                sess.AuthenticationKey = (String)parameters["AuthenticationKey"];
                cancel.AccountID = (String)parameters["accountid"];
                cancel.CancellationReason = (String)parameters["cancellationreason"];
                cancel.CertificateNumber = (String)parameters["certificatenumber"];
                cancel.ContactEmail = (String)parameters["contactemail"];
                cancel.DealerName = (String)parameters["dealername"];
                cancel.Surname = (String)parameters["surname"];
                cancel.RequestValidation = (bool)parameters["requestvalidation"];
                cancel.RefundCustomer = (String)parameters["refundcustomer"];

                cancel.PhoenixCancellation = null;

                insReq.Session = sess;
                insReq.Cancellation = cancel;

                var response = insuranceWebService.CancelPolicyByInsuranceRequest(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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
                sess.Username = (String)parameters["username"];
                sess.AuthenticationKey = (String)parameters["AuthenticationKey"];
                client.FirstName = (String)parameters["firstname"];
                client.Surname = (String)parameters["surname"];
                client.Title = (String)parameters["title"];
                client.HouseNumber = (String)parameters["housenumber"];
                client.Address = (String)parameters["address"];
                client.Postcode = (String)parameters["postcode"];
                client.Email = (String)parameters["email"];
                client.Telephone = (String)parameters["telephone"];
                client.Contact_by_email = (bool)parameters["contact_by_email"];
                client.Contact_by_phone = (bool)parameters["contact_by_phone"];
                client.Contact_by_post = (bool)parameters["contact_by_post"];
                client.Contact_by_text = (bool)parameters["contact_by_text"];
                client.DateOfBirth = (DateTime)parameters["dateofbirth"];
                client.Mobile = (String)parameters["mobile"];
                client.IsCompany = (bool)parameters["iscompany"];
                sess.DealerFittedAccessoriesValue = (decimal)parameters["dealerfittedaccessories"];
                vehicle.Make = (String)parameters["make"];
                vehicle.Model = (String)parameters["model"];
                vehicle.Registration = (String)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.MOTDate = (DateTime)parameters["motdate"];
                vehicle.Fuel = (String)parameters["fuel"];
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
                var response = insuranceWebService.CreateCustomer(cusReq);
                return MethodRespToObject(response);


            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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
                sess.Username = (String)parameters["username"];
                sess.AuthenticationKey = (String)parameters["sess.AuthenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (String)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];

                client.FirstName = (String)parameters["firstname"];
                client.Surname = (String)parameters["surname"];
                client.Title = (String)parameters["title"];
                client.HouseNumber = (String)parameters["housenumber"];
                client.Address = (String)parameters["address"];
                client.Postcode = (String)parameters["postcode"];
                client.Email = (String)parameters["email"];
                client.Telephone = (String)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];
                client.DateOfBirth = (DateTime)parameters["dateofbirth"];
                policy.Description = (String)parameters["description"];
                policy.Plan = (String)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (String)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                policy.DatePISupplied = (DateTime)parameters["datepisupplied"];
                policy.ExternalReference = (String)parameters["externalreference"];
                policy.DateCustomerConfirmed = (DateTime)parameters["datecustomerconfirmed"];
                vehicle.Make = (String)parameters["make"];
                vehicle.Model = (String)parameters["model"];
                vehicle.Registration = (String)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.MOTDate = (DateTime)parameters["motdate"];
                vehicle.Fuel = (String)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];
                bank.AccountName = (String)parameters["accountname"];
                bank.AccountNumber = (String)parameters["accountnumber"];
                bank.PaperlessDDI = (bool)parameters["paperlessddi"];
                bank.PayeeAddress = (String)parameters["payeeaddress"];
                bank.PayeeFirstName = (String)parameters["payeefirstname"];
                bank.PayeeSurname = (String)parameters["payeesurname"];
                bank.PayeeAddress = (String)parameters["payeehousenumber"];
                bank.PayeePostcode = (String)parameters["payeepostcode"];
                bank.PayeeTitle = (String)parameters["payeetitle"];
                bank.SortCode = (String)parameters["sortcode"];
                bank.PolicyHolderPaying = (bool)parameters["policyholderpaying"];
                loan.Advance = (decimal)parameters["advance"];
                loan.AdvanceRentals = (int)parameters["advancerentals"];
                loan.LoanPayment = (decimal)parameters["loanpayment"];
                loan.LoanTerm = (int)parameters["loanterm"];
                loan.BorrowerName = (String)parameters["borrowername"];
                loan.Lender = (String)parameters["lender"];
                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;
                insReq.Bank = bank;
                insReq.Loan = loan;

                var response = insuranceWebService.CreatePolicyByInsuranceRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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

                sess.Username = (String)parameters["username"];
                sess.AuthenticationKey = (String)parameters["AuthenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (String)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];

                client.FirstName = (String)parameters["firstname"];
                client.Surname = (String)parameters["surname"];
                client.Title = (String)parameters["title"];
                client.HouseNumber = (String)parameters["housenumber"];
                client.Address = (String)parameters["address"];
                client.Postcode = (String)parameters["postcode"];
                client.Email = (String)parameters["email"];
                client.Telephone = (String)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];

                policy.Description = (String)parameters["description"];
                policy.Plan = (String)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (String)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];

                vehicle.Make = (String)parameters["make"];
                vehicle.Model = (String)parameters["model"];
                vehicle.Registration = (String)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (String)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = insuranceWebService.GetIncludedMakesRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;

            }
        }
        public Response GetMakesRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var response = insuranceWebService.GetMakesRequest();
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response GetLendersRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var response = insuranceWebService.GetLendersRequest();
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response GetReportsListRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var response = insuranceWebService.GetReportsListRequest();
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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


                sess.Username = (String)parameters["username"];
                sess.Password = "";
                sess.AuthenticationKey = (String)parameters["authenticationKey"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];
                vehicle.Price = (decimal)parameters["price"];

                insReq.Session = sess;
                insReq.Vehicle = vehicle;

                var response = insuranceWebService.GetProductListRequest(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;

            }
        }
        public Response GetSavedDetailsListRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest();


                sess.Username = (String)parameters["username"];
                sess.Password = "";

                insReq.Session = sess;

                var response = insuranceWebService.GetSavedDetailsListRequest(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;

            }
        }

        public Response MTAPolicyByInsuranceRequest(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();
                var sess = new SessionRequest(); var mta = new AdjustRequest();
                sess.Username = (String)parameters["username"];
                sess.Password = "";
                sess.AuthenticationKey = (String)parameters["authenticationKey"];
                mta.AccountID = (String)parameters["accountid"];
                mta.Contact = (String)parameters["contact"];
                mta.Details = (String)parameters["details"];
                mta.PolicyNumber = (String)parameters["policynumber"];
                mta.MTAReason = (String)parameters["mtareason"];
                mta.DealerName = (String)parameters["dealername"];
                mta.Surname = (String)parameters["surname"];
                insReq.MTA = mta;
                insReq.Session = sess;
                var response = insuranceWebService.MTAPolicyByInsuranceRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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
                sess.Username = (String)parameters["username"];
                sess.Password = "";
                document.CertificateNumber = (String)parameters["certificatenumber"];
                document.PrintCertificate = (bool)parameters["printcertificate"];
                document.PrintPolicySummary = (bool)parameters["printpolicysummary"];
                document.PrintTermsandConditions = (bool)parameters["printtermsandconditions"];
                document.PrintStatementofPrice = (bool)parameters["printstatementofprice"];
                document.PrintDirectDebit = (bool)parameters["printdirectdebit"];
                insReq.Documents = document;
                insReq.Session = sess;
                var response = insuranceWebService.ReprintPolicyRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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

                sess.Username = (String)parameters["username"];
                sess.AuthenticationKey = (String)parameters["authenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (String)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];


                client.FirstName = (String)parameters["firstname"];
                client.Surname = (String)parameters["surname"];
                client.Title = (String)parameters["title"];
                client.HouseNumber = (String)parameters["housenumber"];
                client.Address = (String)parameters["address"];
                client.Postcode = (String)parameters["postcode"];
                client.Email = (String)parameters["email"];
                client.Telephone = (String)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];
                policy.Description = (String)parameters["description"];
                policy.Plan = (String)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (String)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                vehicle.Make = (String)parameters["make"];
                vehicle.Model = (String)parameters["model"];
                vehicle.Registration = (String)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (String)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Vehicle = vehicle;
                insReq.Policy = policy;
                var response = insuranceWebService.ValidatePolicyRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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
                    Username = (String)parameters["username"],
                    Password = (String)parameters["password"],
                    NewPassword = (String)parameters["newpassword"]
                };
                insReq.Session = sess;
                var response = insuranceWebService.ChangePasswordRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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
                    Username = (String)parameters["username"],
                    Password = "",
                    AuthenticationKey = (String)parameters["authenticationkey"],
                    SearchDate = (DateTime)parameters["searchdate"]
                };
                insReq.Session = sess;
                var response = insuranceWebService.GetReprintListRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }

        public Response PrintReport(Dictionary<string, object> parameters)
        {
            try
            {
                var Account = (String)parameters["account"];
                var AuthenticationKey = (String)parameters["authenticationkey"];
                var ReportID = (String)parameters["reportid"];
                var ReportDate = (DateTime)parameters["reportdate"];
                var response = insuranceWebService.PrintReportRequest(Account, AuthenticationKey, ReportID, ReportDate);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;
            }
        }
        public Response ValidateLogin(Dictionary<string, object> parameters)
        {
            try
            {
                var insReq = new InsuranceRequest();

                string Username = (String)parameters["username"];
                string Password = "";
                string AuthenticationKey = (String)parameters["authenticationkey"];

                var response = insuranceWebService.ValidateLogin(Username, Password, AuthenticationKey);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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
                    Username = (String)parameters["username"],
                    AuthenticationKey = (String)parameters["AuthenticationKey"],
                    Account = (String)parameters["account"],
                    DeliveryDate = (DateTime)parameters["deliverydate"]
                };

                client.FirstName = (String)parameters["firstname"];
                client.Surname = (String)parameters["surname"];
                client.Title = (String)parameters["title"];
                client.HouseNumber = (String)parameters["housenumber"];
                client.Address = (String)parameters["address"];
                client.Postcode = (String)parameters["postcode"];
                client.Email = (String)parameters["email"];
                client.Telephone = (String)parameters["telephone"];
                client.Employer = (String)parameters["employer"];
                client.Mobile = (String)parameters["mobile"];
                client.Occupation = (String)parameters["occupation"];

                policy.Description = (String)parameters["description"];
                policy.Plan = (String)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (String)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                policy.StartDate = (DateTime)parameters["startdate"];

                vehicle.Make = (String)parameters["make"];
                vehicle.Model = (String)parameters["model"];
                vehicle.Registration = (String)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (String)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = insuranceWebService.CreateAndHandlePI(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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

                sess.Username = (String)parameters["username"];
                sess.AuthenticationKey = (String)parameters["AuthenticationKey"];
                sess.Account = (String)parameters["account"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];

                client.FirstName = (String)parameters["firstname"];
                client.Surname = (String)parameters["surname"];
                client.Title = (String)parameters["title"];
                client.HouseNumber = (String)parameters["housenumber"];
                client.Address = (String)parameters["address"];
                client.Postcode = (String)parameters["postcode"];
                client.Email = (String)parameters["email"];
                client.Telephone = (String)parameters["telephone"];
                client.Employer = (String)parameters["employer"];
                client.Mobile = (String)parameters["mobile"];
                client.Occupation = (String)parameters["occupation"];

                policy.Description = (String)parameters["description"];
                policy.Plan = (String)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (String)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];
                policy.StartDate = (DateTime)parameters["startdate"];

                vehicle.Make = (String)parameters["make"];
                vehicle.Model = (String)parameters["model"];
                vehicle.Registration = (String)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (String)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = insuranceWebService.SavePI(insReq);
                return MethodRespToObject(response);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
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

                sess.Username = (String)parameters["username"];
                sess.AuthenticationKey = (String)parameters["AuthenticationKey"];
                sess.Bordereaux = (bool)parameters["bordereaux"];
                sess.Account = (String)parameters["account"];
                sess.GuaranteeWarrantyDate = (DateTime)parameters["guarenteewarrantydate"];
                sess.PaidByCard = (bool)parameters["paidbycard"];
                sess.DeliveryDate = (DateTime)parameters["deliverydate"];
                sess.LoanProvided = (bool)parameters["loanprovided"];

                client.FirstName = (String)parameters["firstname"];
                client.Surname = (String)parameters["surname"];
                client.Title = (String)parameters["title"];
                client.HouseNumber = (String)parameters["housenumber"];
                client.Address = (String)parameters["address"];
                client.Postcode = (String)parameters["postcode"];
                client.Email = (String)parameters["email"];
                client.Telephone = (String)parameters["telephone"];
                client.IsCompany = (bool)parameters["iscompany"];

                policy.Description = (String)parameters["description"];
                policy.Plan = (String)parameters["plan"];
                policy.GrossPremium = (decimal)parameters["grosspremium"];
                policy.Product = (String)parameters["product"];
                policy.CoverPeriod = (int)parameters["coverperiod"];

                vehicle.Make = (String)parameters["make"];
                vehicle.Model = (String)parameters["model"];
                vehicle.Registration = (String)parameters["registration"];
                vehicle.Price = (decimal)parameters["price"];
                vehicle.Mileage = (int)parameters["mileage"];
                vehicle.DateRegistered = (DateTime)parameters["dateregistered"];
                vehicle.EngineSize = (int)parameters["enginesize"];
                vehicle.Fuel = (String)parameters["fuel"];
                vehicle.NewVehicle = (bool)parameters["newvehicle"];
                vehicle.Motorcycle = (bool)parameters["motorcycle"];

                insReq.Session = sess;
                insReq.Client = client;
                insReq.Policy = policy;
                insReq.Vehicle = vehicle;

                var response = insuranceWebService.SavePolicyDetailsRequest(insReq);
                return MethodRespToObject(response);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException.Message);
                return null;

            }
        }
    }

}
