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
Install the NuGet Package:
```
PM> Install-Package Daishi.PaySharp
```
## Getting Started
[Register a Business Account with PayPal](https://developer.paypal.com/webapps/developer/applications/accounts) and follow these instructions. PaySharp.NET requires the following prerequisite PayPal metadata:
* *Username*
* *Password*
* *Signature*
* *ExpressCheckoutURI*

Each PayPal account is associated with a [Secure Merchant ID](https://www.paypal-community.com/t5/About-Business/Where-can-I-find-my-quot-Secure-Merchant-ID-quot/td-p/810000), which can be included in the ***Subject*** field, if for example, your application supports multiple currencies. ***ExpressCheckoutURI*** should refer to [the PayPal Sandbox](https://api-3t.sandbox.paypal.com/nvp) for all non-production environments.