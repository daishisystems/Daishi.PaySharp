#region Includes

using System;
using System.Configuration;

#endregion

namespace Daishi.PayPal.GetExpressCheckoutTestApp {
    internal class Program {
        private static void Main(string[] args) {

            Console.Write("Enter PayPal Access Token: ");
            var payPalAccessToken = Console.ReadLine();

            if (string.IsNullOrEmpty(payPalAccessToken)) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid PayPal Access Token.");

                Console.ReadLine();
                return;
            }

            Console.WriteLine("Waiting for PayPal...");

            try {
                var payPalAdapter = new PayPalAdapter();

                // Don't need to await to fulfil test objective.
                var getExpressCheckoutDetails = payPalAdapter.GetExpressCheckoutDetailsAsync(
                    new GetExpressCheckoutDetailsPayload {
                        User = ConfigurationManager.AppSettings["User"],
                        Password = ConfigurationManager.AppSettings["Password"],
                        Signature = ConfigurationManager.AppSettings["Signature"],
                        Method = "GetExpressCheckoutDetails",
                        Version = "93",
                        AccessToken = payPalAccessToken
                    }, ConfigurationManager.AppSettings["GetExpressCheckoutURI"]);

                CustomerDetails customerDetails;
                PayPalError payPalError;

                var ok = PayPalUtility.TryParseCustomerDetails(
                    getExpressCheckoutDetails.Result, out customerDetails, out payPalError);

                if (ok) {
                    Console.Write("GETEXPRESSCHECKOUTDETAILS: ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("OK");
                    Console.ResetColor();

                    Console.WriteLine();
                    Console.Write("PayPal Acknowledgement: ");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.Write(customerDetails.Ack);
                }
                else {
                    Console.Write("GETEXPRESSCHECKOUTDETAILS: ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("FAIL");
                    Console.ResetColor();

                    Console.WriteLine();
                    Console.Write("PayPal Short Error Message: ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(payPalError.ShortMessage);
                }

                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Press any key to quit...");
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
            }

            Console.ReadLine();
        }
    }
}