<a href="http://insidethecpu.com">![Image of insidethecpu](https://dl.dropboxusercontent.com/u/26042707/Daishi%20Systems%20Icon%20with%20Text%20%28really%20tiny%20with%20photo%29.png)</a>
# PaySharp.NET
[![Build status](https://ci.appveyor.com/api/projects/status/fflciv7os94nxl9u?svg=true)](https://ci.appveyor.com/project/daishisystems/daishi-paysharp)

A PayPal SDK targeting the .NET Framework (4.5+).
![PaySharp Image](https://dl.dropboxusercontent.com/u/26042707/PaySharp%20Logo.jpg)
## Overview
PaySharp.NET provides features that allow consuming applications and services to process [PayPal Express Checkout transactions](https://developer.paypal.com/docs/classic/express-checkout/ht_ec-singleItemPayment-curl-etc/). Such transactions consist of a 7-stage process, composed of a series of browser redirects, user input, and the following PayPal mechanisms, each of which is exposed through this SDK:
* *SetExpressCheckout*
* *GetExpressCheckoutDetails*
* *DoExpressCheckoutPayment*

PaySharp.NET provides both synchronous and asynchronous support for each mechanism.
## Process Flow
![Express Checkout](https://dl.dropboxusercontent.com/u/26042707/PaySharp.gif)
## Installation
Install the [NuGet Package](https://www.nuget.org/packages/Daishi.PaySharp/):
```
PM> Install-Package Daishi.PaySharp
```
## Getting Started
[Register a Business Account with PayPal](https://developer.paypal.com/webapps/developer/applications/accounts). PaySharp.NET requires the following prerequisite PayPal metadata:
* *Username*
* *Password*
* *Signature*
* *ExpressCheckoutURI*

Each PayPal account is also associated with a [Secure Merchant ID](https://www.paypal-community.com/t5/About-Business/Where-can-I-find-my-quot-Secure-Merchant-ID-quot/td-p/810000), which can be included in the *Subject* field (*see code samples below*), if for example, your application supports multiple currencies. *ExpressCheckoutURI* should refer to [the PayPal Sandbox](https://developer.paypal.com/developer/accounts/) for all non-production environments.
## Explanation of Terms
##### SetExpressCheckout
> Establishes a PayPal session based on Merchant credentials, and returns an Access Token pertaining to that session.

##### GetExpresscheckoutDetails
> Returns a definitive collection of metadata that describes the PayPal user (*name*, *address*, etc.).

##### DoExpressCheckoutPayment
> Collects the payment by transferring the transaction amount from the User's account to the Merchant account.

## Running the Test Harness
PaySharp.NET is covered by a range of Unit Tests, included with each build. To provide a greater degree of reliability, the SDK contains a Test Harness project. This project will execute a full Express Checkout transaction when invoked as follows:

1. Locate *App.config* in **Daishi.PaySharp.TestHarness**
2. Enter appropriate values for *User*, *Password*, *Signature*, and *Subject* (if applicable)
3. Run the project (F5)
4. Press any key when prompted
5. *SetExpressCheckout* executes and returns a PayPal Access Token

![SetExpressCheckout](https://dl.dropboxusercontent.com/u/26042707/PaySharp%20Test%20Harness%20Step%201.PNG)

6. Open your web browser and navigate to https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_express-checkout&token=EC-17W08351SC6397012. Note that the token parameter is set to the value returned in Step 5
7. Login to PayPal
8. Your browser will redirect to http://www.example.com/success.html?token=EC-17W08351SC6397012&PayerID=783CTW8EXK5AE. Note the PayerID parameter
9. Return to the Test Harness Command Prompt having copied the PayerID parameter from Step 8
10. Press any key when prompted, and input the PayerID parameter from Step 8
11. GetExpressCheckoutDetails is invoked

![GetExpressCheckoutDetails](https://dl.dropboxusercontent.com/u/26042707/PaySharp%20Test%20Harness%20Step%202.PNG)

12. Press any key when prompted
13. DoExpressCheckoutPayment is invoked, successfully completing the transaction

![GetExpressCheckoutDetails](https://dl.dropboxusercontent.com/u/26042707/PaySharp%20Test%20Harness%20Step%203.PNG)
## Sample Code
#### SetExpressCheckout
```cs
var user = ConfigurationManager.AppSettings["User"];
var password = ConfigurationManager.AppSettings["Password"];
var signature = ConfigurationManager.AppSettings["Signature"];
var subject = ConfigurationManager.AppSettings["Subject"];

var payPalAdapter = new PayPalAdapter();

var setExpresscheckout =
    payPalAdapter.SetExpressCheckout(
        new SetExpressCheckoutPayload {
            User = user,
            Password = password,
            Signature = signature,
            Version = "108.0",
            Amount = "19.95",
            Subject = subject,
            LocaleCode = "en-IE",
            CurrencyCode = "EUR",
            CancelUrl = "http://www.example.com/cancel.html",
            ReturnUrl = "http://www.example.com/success.html",
            PaymentRequestName = "TEST",
            PaymentRequestDescription = "TEST BOOKING"
        },
        Encoding.UTF8,
        ConfigurationManager.AppSettings["ExpressCheckoutURI"]);

string accessToken;
PayPalError payPalError;

var ok = PayPalUtility.TryParseAccessToken(setExpresscheckout,
    out accessToken, out payPalError);
```
#### GetExpressCheckoutDetails
```cs
var getExpressCheckoutDetails = payPalAdapter
    .GetExpressCheckoutDetails(
        new GetExpressCheckoutDetailsPayload {
            User = user,
            Password = password,
            Signature = signature,
            Version = "108.0",
            AccessToken = accessToken,
            Subject = subject,
            PayerID = payerID
        },
        ConfigurationManager.AppSettings["ExpressCheckoutURI"]);

CustomerDetails customerDetails;

ok = PayPalUtility.TryParseCustomerDetails(
    getExpressCheckoutDetails, out customerDetails,
    out payPalError);
```
#### DoExpressCheckoutPayment
```cs
var doExpressCheckoutPayment = payPalAdapter
    .DoExpressCheckoutPayment(
        new DoExpressCheckoutPaymentPayload {
            User = user,
            Password = password,
            Signature = signature,
            Version = "108.0",
            AccessToken = accessToken,
            Subject = subject,
            PayerID = payerID,
            PaymentRequestAmt = "19.95",
            PaymentRequestCurrencyCode = "EUR"
        },
        ConfigurationManager.AppSettings["ExpressCheckoutURI"]);

TransactionResults transactionResults;

ok = PayPalUtility.TryParseTransactionResults(
    doExpressCheckoutPayment, out transactionResults,
    out payPalError);
```
## API Documentation
The API is fully documented; [a *.chm Help-file](https://github.com/daishisystems/Daishi.PaySharp/blob/master/Daishi.PaySharp/PaySharp.NET%20API%20DOC.chm) is included with every build. If you prefer to view the API documentation in a web-based format, such as HTML, you can run [the Sandcastle tool](https://sandcastle.codeplex.com/) against any branch in order to generate the requisite files.

**Note**: *You will likely need to [unblock the Help-file](https://github.com/matplotlib/matplotlib/issues/3446) as part of Windows security measures*.
## FAQ
**Does this library support C# Async?**
> Yes, there are asynchronous equivalents of each synchronous method exposed by the SDK.

**I get weird errors from PayPal**
> Generally, PayPal issues intuitive error messages. Less intuitive error messages are usually returned as a result of uninitialized payload properties. In the case of **SetExpressCheckout**, scan through the properties in ```SetExpressCheckoutPayload``` and ensure that each property is set to an appropriate value.

**Can I Fork this project?**
> By all means. I’m happy to contribute to any extensions.

**What’s next?**
>An set of extensible components that make it easier for developers to create and augment objects proprietary to downstream systems, such as Fraud Prevention, Booking & Reservation, and Back-office Accounting systems.

## Contact the Developer
Please reach out and contact me for questions, suggestions, or to just talk tech in general.


<a href="http://insidethecpu.com/feed/">![RSS](https://dl.dropboxusercontent.com/u/26042707/rss.png)</a><a href="https://twitter.com/daishisystems">![Twitter](https://dl.dropboxusercontent.com/u/26042707/twitter.png)</a><a href="https://www.linkedin.com/in/daishisystems">![LinkedIn](https://dl.dropboxusercontent.com/u/26042707/linkedin.png)</a><a href="https://plus.google.com/102806071104797194504/posts">![Google+](https://dl.dropboxusercontent.com/u/26042707/g.png)</a><a href="https://www.youtube.com/user/daishisystems">![YouTube](https://dl.dropboxusercontent.com/u/26042707/youtube.png)</a>