using System;
using System.Collections.Generic;

using System.Net;
using System.Threading.Tasks;
//using Microsoft.AspNetCore.Identity;
using SendGrid;
using Newtonsoft.Json;
using SendGrid.Helpers.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
namespace ZoEazy.Api.Helpers
{

    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public IConfigurationRoot Configuration { get; }
        private readonly ILogger<AuthMessageSender> _logger;

        private const string CodeFmt = @"
<div style='margin: 0; background: #f2f2f2; padding: 0; width: 100%; border-collapse: collapse;'>


        <div style='line-height:50%;'>
            <img width='692' alt='Title' src='http://supersoccer.azurewebsites.net/templates/header.jpg'>
        </div>
        <div style=' border-collapse: collapse;padding:0;width: 692px;text-align: center;'>

            <div style='margin: 0 12px; padding: 0px; width: 668px; text-align: center; font-family: Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif; font-size: 16px; vertical-align: top; border-collapse: collapse; background-color: rgb(249, 249, 249);'>
                <div style=' text-align: left;padding-left: 30px;'>
                    <div style='font-size: 22px; color: #EC3B30; padding-left: 20px; margin-top: 0;'>
                        Dear {name}:
                    </div>
                    <br/>
                  
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>
                            Enter this code:
                        </div>
                        <div style='float:right;width: 200px;'>
                            <b>{code}</b>
                        </div>
                        <div style='clear: both;'></div>
                    </div>
                </div>
            </div>
        </div>
        <div>
            <img width='692' alt='Footer' src='http://supersoccer.azurewebsites.net/templates/footer.jpg'>
        </div>
    </div>
    ";
        private const string OrderFmt = @"
<div style='margin: 0; background: #f2f2f2; padding: 0; width: 100%; border-collapse: collapse;'>


        <div style='line-height:50%;'>
            <img width='692' alt='Title' src='http://supersoccer.azurewebsites.net/templates/header.jpg'>
        </div>
        <div style=' border-collapse: collapse;padding:0;width: 692px;text-align: center;'>

            <div style='margin: 0 12px; padding: 0px; width: 668px; text-align: center; font-family: Helvetica Neue, Helvetica, Arial, Lucida Grande, sans-serif; font-size: 16px; vertical-align: top; border-collapse: collapse; background-color: rgb(249, 249, 249);'>
                <div style=' text-align: left;padding-left: 30px;'>
                    <div style='font-size: 22px; color: #EC3B30; padding-left: 20px; margin-top: 0;'>
                        Thank you for your order:
                    </div>
                    <br/>
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>Authorization Date:</div>
                        <div style='float:right;width: 200px;'> {authDate}</div>
                        <div style='clear: both;'></div>
                    </div>
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>Branch: </div>
                        <div style='float:right;width: 200px;'> {branch}</div>
                        <div style='clear: both;'></div>
                    </div>
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>
                            Invoice:
                        </div>
                        <div style='float:right;width: 200px;'>
                            <b>{invoiceNumber}</b>
                        </div>
                        <div style='clear: both;'></div>
                    </div>
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>
                            Authorization code:
                        </div>
                        <div style='float:right;width: 200px;'>
                            <b>{authCode}</b>
                        </div>
                        <div style='clear: both;'></div>
                    </div>
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>
                            Card Number:
                        </div>
                        <div style='float:right;width: 200px;'>
                            {cardNumber}
                        </div>
                        <div style='clear: both;'></div>
                    </div>
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>
                            Transaction Id:
                        </div>
                        <div style='float:right;width: 200px;'>{trxId}</div>
                        <div style='clear: both;'></div>
                    </div>
                    <div style='margin-right: 95px;padding-left: 20px;'>
                        <div style='margin-top:0;float:left;width: 35%;'>
                            Amount:
                        </div>
                        <div style='float:right;width: 200px;'>
                            {amount}
                        </div>
                        <div style='clear: both;'></div>
                    </div>
                    <div>
                        <span style='padding-left: 20px; margin-top: 0; width: 200px; font-size: 22px; color: #EC3B30;'>Items:</span>
                    </div>
                </div>



                <table style='width: 95%;margin-left: 2.5%;'>
                    <thead>
                        <tr style='background: #0083cc;color: whitesmoke;padding: 5px; font-size: 0.8em; font-weight: normal;'>
                            <th>Name</th>
                            <th>Location</th>
                            <th>Class</th>
                            <th>DoW</th>
                            <th>Price</th>
                            <th>Dates</th>
                            <th>Time</th>

                        </tr>
                    </thead>
                    <tbody>
                        {items}
                    </tbody>
                </table>
            </div>
        </div>



        <div>
            <img width='692' alt='Footer' src='http://supersoccer.azurewebsites.net/templates/footer.jpg'>
        </div>
    </div>
    ";

        private const string ItemsFmt = @"
           <tr style='font-size: 0.6em;font-weight: normal;border-left: 1px solid #ccc;border-right: 1px solid #ccc;  padding: 5px 0 5px 5px;border-bottom: 1px solid #ccc; text-align: left;'>
                            <td>{name}</td>
                            <td>{address}</td>
                            <td>{validUntil}</td>
                            <td>{service}</td>
                            <td>{contract}</td>
                            <td style='text-align: right;'>{monthlyPrice}</td>
                            <td style='text-align: right;'>{discount}</td>
                            <td style='text-align: right;'>{charge}</td>
                        </tr>
";
        private const string SetupFmt = @"
           <tr style='font-size: 0.6em;font-weight: normal;border-left: 1px solid #ccc;border-right: 1px solid #ccc;  padding: 5px 0 5px 5px;border-bottom: 1px solid #ccc; text-align: left;'>
                            <td colspan='3'>&nbsp;</td>
                            <td>Setup Charge</td>
                            <td colspam='3'>&nbsp;</td>
                            <td style='text-align: right;'>{setup}</td>
                        </tr>
";
        private const string PrepaidFmt = @"
           <tr style='font-size: 0.6em;font-weight: normal;border-left: 1px solid #ccc;border-right: 1px solid #ccc;  padding: 5px 0 5px 5px;border-bottom: 1px solid #ccc; text-align: left;'>
                            <td colspan='3'>&nbsp;</td>
                            <td>Prepaid</td>
                            <td colspam='3'>&nbsp;</td>
                            <td style='text-align: right;'>{prepaid}</td>
                        </tr>
";
        private const string TotalFmt = @"
           <tr style='font-size: 0.6em;font-weight: normal;border-left: 1px solid #ccc;border-right: 1px solid #ccc;  padding: 5px 0 5px 5px;border-bottom: 1px solid #ccc; text-align: left;'>
                            <td colspan='3'>&nbsp;</td>
                            <td>Total</td>
                            <td colspam='3'>&nbsp;</td>
                            <td style='text-align: right;'>{total}</td>
                        </tr>
";

        private EmailOptions _options;
        //public AuthMessageSender(IEmailOptions options, ILogger<AuthMessageSender> logger)
        public AuthMessageSender(ILogger<AuthMessageSender> logger)
        {
            _options = new EmailOptions(
                Environment.GetEnvironmentVariable("SENDGRIDapikey"),
                Environment.GetEnvironmentVariable("SENDGRIDemail"),
                Environment.GetEnvironmentVariable("SENDGRIDname"));

            _logger = logger;
        }
        public async Task SendEmailAsync(string template, Dictionary<string, object> parameters, string email, int orderId, decimal total)
        {
            if (template.ToLower() == "order")
                await FormatOrderAsync(parameters, email, orderId, total);

        }
        public async Task SendEmailAsync(string template, string email, string code, string name = "")
        {
            if (template.ToLower() == "seccode")
            {
                await SendAsync(FormatSecCode(email, name, code), email, name);
            }

            if (template.ToLower() == "confemail")
            {
                await SendAsync(FormatConfEmail(email, "", code), email, name);
            }
        }

        private IdentityMessage FormatConfEmail(string email, string name, string code)
        {
            var msgBody = "Thanks, {email}. Please confirm your account by clicking this link: <a href='https://zoeazy.com/api/auth/email/{email}/code/{code}'>Confirm Your Account</a>"
                .Replace("{email}", email)
                .Replace("{name}", name)
                .Replace("{code}", code);

            var message = new IdentityMessage
            {
                Body = msgBody,
                Destination = email,
                Subject = "Hello {email}. Please, confirm your ZoEazy account."
                .Replace("{email}", email)
            };
            return message;
        }

        private IdentityMessage FormatSecCode(string email, string name, string code)
        {

            var msgBody = CodeFmt
                .Replace("{email}", email)
                .Replace("{name}", name)
                .Replace("{code}", code);

            var message = new IdentityMessage
            {
                Body = msgBody,
                Destination = email,
                Subject = "{name}, your code is inside.".Replace("{name}", name)
            };
            return message;
        }

        private async Task FormatOrderAsync(Dictionary<string, object> parameters, string email, int orderId, decimal total)
        {
            var viewItems = JsonConvert.DeserializeObject<List<ViewItem>>(parameters["viewItems"].ToString());

            var msgBody = OrderFmt
                .Replace("{authDate}", parameters["authDate"].ToString())
                .Replace("{franchise}", parameters["franchise"].ToString())
                .Replace("{invoiceNumber}", parameters["invoiceNumber"].ToString())
                .Replace("{responseCode}", parameters["responseCode"].ToString())
                .Replace("{authCode}", parameters["authCode"].ToString())
                .Replace("{cardNumber}", parameters["cardNumber"].ToString())
                .Replace("{trxId}", parameters["trxId"].ToString())
                .Replace("{amount}", parameters["amount"].ToString());

            msgBody = msgBody.Replace("{items}", PopulateItems(viewItems, total));

            var message = new IdentityMessage
            {
                Body = msgBody,
                Destination = email,
                Subject = "Order {order}, thanks for your purchase".Replace("{order}", orderId.ToString())
            };

            await SendAsync(message, email, parameters["name"].ToString());
        }

        private string PopulateItems(IEnumerable<ViewItem> viewItems, decimal total)
        {
            var label = string.Empty;
            foreach (var item in viewItems)
            {
                label += ItemsFmt.Replace("{name}", item.Name)
                    .Replace("{address}", item.Address)
                    .Replace("{months}", item.Months.ToString())
                    .Replace("{price}", item.Price.ToString("C0"))
                    .Replace("{discount}", item.Discount.ToString("C0"))
                    .Replace("{charge}", item.Charge.ToString("C0"))
                    .Replace("{validUntil}", GetValidUntil(item.Months));

                if (item.Setup > 0)
                {
                    label += SetupFmt.Replace("{setup}", item.Setup.ToString("C0"));

                    if (item.Prepaid > 0)
                        label += PrepaidFmt.Replace("{prepaid}", item.Prepaid.ToString("C0"));
                }

            }

            label += TotalFmt.Replace("{total}", total.ToString("C0"));
            return label;
        }

        private string GetValidUntil(int months)
        {
            return DateTime.UtcNow.AddMonths(months).ToString();
        }

        public async Task<Response> SendAsync(IdentityMessage message, string email, string name)
        {
            try
            {

                var client = new SendGridClient(_options.apiKey);
                var msg = new SendGridMessage()
                {
                    From = new EmailAddress(_options.email, _options.name),
                    Subject = message.Subject,
                    PlainTextContent = message.Body,
                    HtmlContent = message.Body
                };
                msg.AddTo(new EmailAddress(email, name));
                var response = await client.SendEmailAsync(msg);
                return response;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            //_logger.LogInformation("SMS: {number}, Message: {message}", number, message);
            return Task.FromResult(0);
        }
    }
}
