using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ZoEazy.Api.Model;
using Order = ZoEazy.Api.Model.Order;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Data
{
    /// <summary>
    ///     Repository (a "Unit of Work" really) of oEazy models.
    /// </summary>
    public class Repository : IRepository
    {
        private const string ZoEazyDescription = "ZoEazy Services";
        private readonly UserManager<Model.Subscriber.Subscriber> _userManager;
        private readonly ZoeazyDbContext _zoeContextProvider; // = new ZoeazyDbContext();
        private readonly ZoeazyDbContext _subscriberContextProvider; // = new ZoeazyDbContext();
        private readonly FranchiseDbContext _franchiseContextProvider; // = new ZoeazyDbContext();
        private readonly BranchDbContext _branchContextProvider; // = new ZoeazyDbContext();
        private readonly ILogger _logger;
     
        public IQueryable<Model.Subscriber.Subscriber> Subscribers;
        // private readonly CloudStorageAccount _storageAccount =
        //    CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["StorageConnectionString"].ToString());

        public Repository(ZoeazyDbContext zoeContext, FranchiseDbContext franContext, BranchDbContext branContext,
            UserManager<Model.Subscriber.Subscriber> userManager, ILoggerFactory loggerFactory)
        {
            _zoeContextProvider = zoeContext;
            
            _franchiseContextProvider = franContext;
            _branchContextProvider = branContext;

            _userManager = userManager;
            _logger = loggerFactory.CreateLogger<Repository>();
        }
        public IQueryable<Model.Subscriber.Subscriber> Users { get { return _zoeContextProvider.Users; } }
        public IQueryable<Branch> Branches
        {
            get { return Branches; }
        }
        public IQueryable<Country> Countries
        {
            get { return _zoeContextProvider.Countries; }
        }

        public IQueryable<State> States
        {
            get { return _zoeContextProvider.States; }
        }

        public IQueryable<Model.Franchise.Franchise> Franchises
        {
            get { return _franchiseContextProvider.Franchises; }
        }

        public IQueryable<Cuisine> Cuisines
        {
            get { return _zoeContextProvider.Cuisines; }
        }

        public IQueryable<CreditCardBrand> CreditCardBrands
        {
            get { return _zoeContextProvider.CreditCardBrands; }
        }

        public IQueryable<Model.Branch.Contract.Contract> Contracts
        {
            get { return _branchContextProvider.Contracts; }
        }

        public IQueryable<Model.Branch.Contract.Period> Periods
        {
            get { return _branchContextProvider.Periods; }
        }
        public IQueryable<ZipCode> ZipCodes {
            get { return _zoeContextProvider.ZipCodes; }
        }
        public async Task<ZipCode> ZipCodeById(string code) {
            if (Int32.TryParse(code, out int zip))
            {
                return await ZipCodes.FirstOrDefaultAsync(z => z.Zip == zip);
            }
            else return null;
        }
        //        public SaveResult SaveChanges(JObject saveBundle)
        //        {
        //            return _contextProvider.SaveChanges(saveBundle);
        //        }
        //        public SaveResult SaveProfile(JObject saveBundle, string apId)
        //        {
        //            var subscriber = saveBundle["entities"].FirstOrDefault(t => t["entityAspect"]["entityTypeName"].ToString().Contains("Subscriber:#"));

        //            if (subscriber != null)
        //            {
        //                subscriber["ApplicationUser_Id"].Replace(apId);
        //                saveBundle["entities"].First(t => t["entityAspect"]["entityTypeName"].ToString().Contains("Subscriber:#")).Replace(subscriber);
        //            }

        //            return _contextProvider.SaveChanges(saveBundle);
        //        }

        //        public SaveResult SaveCheckout(JObject saveBundle)
        //        {
        //            _total = GetControlTotal(saveBundle);
        //            _viewItems = GetViewItems(saveBundle);

        //            if (!ValidTotals(saveBundle)) throw new Exception("Invalid Control Totals");

        //            var franchise = GetFranchise(saveBundle);
        //            _franchiseId = franchise.Id;
        //            _subscriberId = franchise.Subscriber_Id;
        //            _contractId = GetFirstContract(saveBundle);
        //            _creditCard = GetCreditCard(saveBundle);

        //            //preorder does the request to Authorize.Net gateway
        //            _contextProvider.BeforeSaveEntitiesDelegate = PreOrder;

        //            var saveResult = _contextProvider.SaveChanges(saveBundle);

        //            var order = (BranchOrder)saveResult.Entities.First(p => p.GetType() == typeof(BranchOrder));


        //            var emailParameters = GetEmailParameters(order, franchise);

        //#pragma warning disable 4014
        //            //          new EmailGenerator().GenerateTaskAsync("order", emailParameters, order.CreditCard.NotificationEmail, order.Id, _total);
        //#pragma warning restore 4014

        //            return saveResult;
        //        }

        //        private string GetViewItems(JObject saveBundle)
        //        {
        //            return (string)(saveBundle["saveOptions"]["tag"]["viewItems"]);
        //        }

        //        private decimal GetControlTotal(JObject saveBundle)
        //        {
        //            return Convert.ToDecimal((string)(saveBundle["saveOptions"]["tag"]["total"]));
        //        }

        //        private void RaiseDeclineEvent(IGatewayResponse response)
        //        {
        //            const string errorStr = "Rejected: ";

        //            var logEntity = new LogEntity(_subscriberId + _creditCard, _contractId.ToString())
        //            {
        //                Message =
        //                    errorStr + "Franchise  " + _franchiseId + ", Subscriber " + _subscriberId + ", Credit Card " + _creditCard +
        //                    "Transaction for " +
        //                    _total + " ERROR: " + response.Message,
        //                CardNumber = _creditCard
        //            };

        //            var tableClient = _storageAccount.CreateCloudTableClient();
        //            var table = tableClient.GetTableReference("EventLog");
        //            table.CreateIfNotExists();
        //            var insRepOp = TableOperation.InsertOrReplace(logEntity);
        //            table.Execute(insRepOp);

        //            throw new Exception(errorStr + response.Message);
        //        }

        //        private Dictionary<Type, List<EntityInfo>> PreOrder(Dictionary<Type, List<EntityInfo>> saveDict)
        //        {
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).Proposed = new Status(true);

        //            //Point of no return: once the order is posted in the authorize 
        //            var response = HttpPostOrder(saveDict);

        //            if (!response.Approved) RaiseDeclineEvent(response);

        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).Executed = new Status(true);

        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).Franchise_Id = _franchiseId;
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).AuthorizationCode = response.AuthorizationCode;
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).CardNumber = response.CardNumber;
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).InvoiceNumber = response.InvoiceNumber;
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).Message = response.Message;
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).ResponseCode = response.ResponseCode;
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).TransactioID = response.TransactionID;
        //            ((BranchOrder)saveDict[typeof(BranchOrder)][0].Entity).GatewayAmount = ConvertToMoney(response.Amount).Amount;

        //            return saveDict;
        //        }

        //        private IGatewayResponse HttpPostOrder(Dictionary<Type, List<EntityInfo>> saveDict)
        //        {
        //            var order = (BranchOrder)(saveDict[typeof(BranchOrder)][0]).Entity;

        //            var card = saveDict.ContainsKey(typeof(CreditCard)) ?
        //                (CreditCard)(saveDict[typeof(CreditCard)][0].Entity) :
        //                _contextProvider.CreditCards.FirstOrDefault(b => b.Id == order.CreditCard_Id);

        //            var subs = saveDict[typeof(BranchOrderItem)];
        //            var sups = saveDict[typeof(BranchOrderItemSetup)];
        //            var gate = OpenGateway();

        //            var apiRequest = Checkout.BuildAuthAndCaptureFromPost();

        //            apiRequest.Queue(ApiFields.Zip, card.PostalCode);
        //            apiRequest.Queue(ApiFields.CreditCardCode, card.CCV);
        //            apiRequest.Queue(ApiFields.Description, ZoEazyDescription);
        //            apiRequest.Queue(ApiFields.CreditCardExpiration, card.ValidThru.Month + "-" + card.ValidThru.Year);
        //            apiRequest.Queue(ApiFields.InvoiceNumber, order.Id.ToString(CultureInfo.InvariantCulture));
        //            apiRequest.Queue(ApiFields.FirstName, card.Name);

        //            if (false)
        //            {
        //                //for testing only... causes a rejection on code 27
        //                //apiRequest.Queue(ApiFields.CreditCardNumber, "4222222222222");
        //                //apiRequest.Queue(ApiFields.Amount, "27.00");
        //            }
        //            apiRequest.Queue(ApiFields.CreditCardNumber, card.Number.ToString().Trim());
        //            apiRequest.Queue(ApiFields.Amount, OrderTotal(subs, sups).ToString(CultureInfo.InvariantCulture));

        //            return gate.Send(apiRequest);
        //        }

        //        private string GetCreditCard(JObject saveBundle)
        //        {
        //            string ccnum;
        //            var cc = saveBundle["entities"].FirstOrDefault(t => t["entityAspect"]["entityTypeName"].ToString().Contains("CreditCard:#"));

        //            if (cc != null)
        //                ccnum = cc["Number"].ToString();
        //            else
        //            {
        //                var order = saveBundle["entities"].FirstOrDefault(t => t["entityAspect"]["entityTypeName"].ToString().Contains("BranchOrder:#"));

        //                if (order != null)
        //                {
        //                    var id = Convert.ToInt32(order["CreditCard_Id"]);
        //                    var ccard = _contextProvider.CreditCards.FirstOrDefault(b => b.Id == id);

        //                    if (ccard != null)
        //                        ccnum = ccard.Number.ToString();
        //                    else
        //                    {
        //                        ccnum = "0";
        //                    }
        //                }
        //                else
        //                {
        //                    ccnum = "0";
        //                }

        //            }

        //            return "xxxxxxxxxxxx" + ccnum.Substring(ccnum.Length - 4);
        //        }

        //        private IGateway OpenGateway()
        //        {
        //            //we used the form builder so we can now just load it up
        //            //using the form reader
        //            var login = ConfigurationManager.AppSettings["ApiLogin"];
        //            var transactionKey = ConfigurationManager.AppSettings["TransactionKey"];

        //            //this is set to test mode - change as needed.
        //            var gate = new Gateway(login, transactionKey, true);
        //            return gate;
        //        }

        //        private bool ValidTotals(IDictionary<string, JToken> saveBundle)
        //        {
        //            var orderItems =
        //                saveBundle["entities"].Where(t => t["entityAspect"]["entityTypeName"].ToString().Contains("BranchOrderItem:#"))
        //                    .ToList();
        //            var orderSetups =
        //                saveBundle["entities"].Where(t => t["entityAspect"]["entityTypeName"].ToString().Contains("BranchOrderItemSetup:#"))
        //                    .ToList();

        //            var totalItems = orderItems.Sum(orderItem => (decimal)orderItem["Charge"]["Amount"]);
        //            var totalSetups = orderSetups.Sum(orderItem => (decimal)orderItem["Charge"]["Amount"]);

        //            return (totalItems + totalSetups) == _total;
        //        }

        //        private decimal OrderTotal(IEnumerable<EntityInfo> subs, IEnumerable<EntityInfo> sups)
        //        {
        //            return subs.Sum(item => ((BranchOrderItem)item.Entity).Charge.Amount) + sups.Sum(item => ((BranchOrderItemSetup)item.Entity).Charge.Amount); ;
        //        }

        //        private Franchise GetFranchise(JObject saveBundle)
        //        {
        //            var order = saveBundle["entities"].First(t => t["entityAspect"]["entityTypeName"].ToString().Contains("BranchOrder:#"));

        //            var franchiseId = Convert.ToInt32(order["Franchise_Id"]);

        //            return _contextProvider.Franchises.First(b => b.Id == franchiseId);
        //        }
        //        private int GetFirstContract(JObject saveBundle)
        //        {
        //            var contract =
        //                saveBundle["entities"].FirstOrDefault(
        //                    t => t["entityAspect"]["entityTypeName"].ToString().Contains("Contract:#"));

        //            if (contract != null) return Convert.ToInt32(contract["Id"]);
        //            ;
        //            var item = saveBundle["entities"].FirstOrDefault(t => t["entityAspect"]["entityTypeName"].ToString().Contains("BranchOrderItem:#"));

        //            if (item != null) return Convert.ToInt32(item["Contract_Id"]);

        //            return 0;
        //        }

        //        private Dictionary<string, object> GetEmailParameters(BranchOrder order, Franchise franchise)
        //        {
        //            var dict = new Dictionary<string, object>();

        //            var authDate = order.Executed.DateTimeObj();
        //            var franchiseId = order.Franchise_Id.ToString();

        //            var authCode = order.AuthorizationCode;
        //            var cardNumber = order.CardNumber;
        //            var invoiceNumber = order.InvoiceNumber;
        //            var msg = order.Message;
        //            var responseCode = order.ResponseCode;
        //            var trxId = order.TransactioID;
        //            var amount = order.GatewayAmount;

        //            dict.Add("authDate", authDate.ToLocalTime());
        //            dict.Add("franchiseId", franchiseId);
        //            dict.Add("franchise", franchise.Name);
        //            dict.Add("authCode", authCode);
        //            dict.Add("cardNumber", cardNumber);
        //            dict.Add("invoiceNumber", invoiceNumber);
        //            dict.Add("msg", msg);
        //            dict.Add("responseCode", responseCode);
        //            dict.Add("trxId", trxId);
        //            dict.Add("amount", amount.ToString(CultureInfo.InvariantCulture));

        //            dict.Add("viewItems", _viewItems);

        //            return dict;
        //        }

        //        private Money ConvertToMoney(decimal amount)
        //        {
        //            return new Money(amount, 1);
        //        }

        //        public async Task<Subscriber> CreateSubscriberAsync(string email, string appId)
        //        {

        //            try
        //            {
        //                var recontext = new ZoeazyDbContext();

        //                var subs = new Subscriber()
        //                {
        //                    Id = appId,
        //                    FirstName = string.Empty,
        //                    LastName = string.Empty
        //                };


        //                recontext.Subscribers.AddOrUpdate(subs);

        //                recontext.Franchises.AddOrUpdate(
        //                    new Franchise()
        //                    {
        //                        Id = subs.Id,
        //                        Name = string.Empty
        //                    });


        //                re_contextProvider.SaveChanges();

        //                return await re_contextProvider.Subscribers.Include(s => s.Franchises)
        //                    .Where(s => s.Id == subs.Id)
        //                    .FirstAsync();

        //            }
        //            catch (Exception e)
        //            {

        //                throw;
        //            }
        //        }
    }
}