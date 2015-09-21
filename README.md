<a href="http://insidethecpu.com">![Image of insidethecpu](https://dl.dropboxusercontent.com/u/26042707/Daishi%20Systems%20Icon%20with%20Text%20%28really%20tiny%20with%20photo%29.png)</a>
# PaySharp.NET
[![Build status](https://ci.appveyor.com/api/projects/status/fflciv7os94nxl9u?svg=true)](https://ci.appveyor.com/project/daishisystems/daishi-paysharp)

A PayPal SDK targeting the .NET Framework (4.5+), written in C#.
![PaySharp Image](https://dl.dropboxusercontent.com/u/26042707/PaySharp%20Logo.jpg)
## Overview
PaySharp.NET provides features that allow consuming applications and services to process [PayPal Express Checkout transactions](https://developer.paypal.com/docs/classic/express-checkout/ht_ec-singleItemPayment-curl-etc/). Such transactions consist of a 7-stage process, composed of a series of browser redirects, user input, and the following PayPal mechanisms, each of which is exposed through this SDK:
* *SetExpressCheckout*
* *GetExpressCheckoutDetails*
* *DoExpressCheckoutPayment*

PaySharp.NET provides both synchronous and asynchronous support for each mechanism.
## Installation
Install the [NuGet Package](https://www.nuget.org/packages/Daishi.PaySharp/):
```
PM> Install-Package Daishi.PaySharp
```
## Getting Started
[Register a Business Account with PayPal](https://developer.paypal.com/webapps/developer/applications/accounts) and follow these instructions. PaySharp.NET requires the following prerequisite PayPal metadata:
* *Username*
* *Password*
* *Signature*
* *ExpressCheckoutURI*

Each PayPal account is associated with a [Secure Merchant ID](https://www.paypal-community.com/t5/About-Business/Where-can-I-find-my-quot-Secure-Merchant-ID-quot/td-p/810000), which can be included in the *Subject* field, if for example, your application supports multiple currencies. *ExpressCheckoutURI* should refer to [the PayPal Sandbox](https://developer.paypal.com/developer/accounts/) for all non-production environments.
## Running the Test Harness
PaySharp.NET is covered by a range of Unit Tests, included with each build. To provide a great degree of reliability, the SDK contains a Test Harness project. This project will execute a full Express Checkout transaction when invoked as follows:
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
12. ![GetExpressCheckoutDetails](https://dl.dropboxusercontent.com/u/26042707/PaySharp%20Test%20Harness%20Step%202.PNG)
12. Press any key when prompted
13. DoExpressCheckout is invoked, successfully completing the transaction
![GetExpressCheckoutDetails](https://dl.dropboxusercontent.com/u/26042707/PaySharp%20Test%20Harness%20Step%203.PNG)

## Explanation of Terms
#### SetExpressCheckout
Establishes a PayPal session based on Merchant credentials, and returns an Access Token pertaining to that session
#### GetExpresscheckoutDetails
Returns a definitive collection of metadata that describes the PayPal user (*name*, *address*, etc.)
#### DoExpressCheckoutPayment
Collects the payment by transferring the transaction amount from the User's account to the Merchant account