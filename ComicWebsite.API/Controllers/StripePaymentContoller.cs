using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ComicWebsite.API.Data;
using ComicWebsite.API.Dtos;
using ComicWebsite.API.Models;
using ComicWebsite.API;
using AutoMapper;
using ComicWebsite.API.Helpers;
using Stripe;

namespace ComicWebsite.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StripePaymentContoller : Controller
    {
    //[AllowAnonymous]
    [HttpPost("Payment")]
    public JsonResult Post([FromBody]StripePaymentRequest paymentRequest)
    {
        StripeConfiguration.SetApiKey("sk_test_eAGTVpWttNKmjbDdtDridju600y7eg4UJU"); 

        var myCharge = new ChargeCreateOptions();
        myCharge.SourceId = paymentRequest.tokenId;
        myCharge.Amount = paymentRequest.amount;
        myCharge.Currency = "eur";
        myCharge.Description = paymentRequest.productName;
        myCharge.Metadata = new Dictionary<string, string>();
        myCharge.Metadata["OurRef"] = "OurRef-" + Guid.NewGuid().ToString();

        var chargeService = new ChargeService();
        Charge stripeCharge = chargeService.Create(myCharge);

        return Json(stripeCharge);
    }

    public class StripePaymentRequest
    {
        public string tokenId { get; set; }
        public string productName { get; set; }
        public int amount { get; set; }
    }
        
    }
}