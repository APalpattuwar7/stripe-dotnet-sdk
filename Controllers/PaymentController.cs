using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using Stripe;

public class PaymentController : Controller
{
    private readonly IOptions<StripeOptions> options;

    public PaymentController(IOptions<StripeOptions> options)
    {
        this.options = options;
    }

    [HttpGet("public-keys")]
    public ActionResult<PublicKeyResponse> GetPublicKeys()
    {
        return new PublicKeyResponse
        {
            PublicKey = this.options.Value.PublishableKey,
        };
    }

    [HttpPost("my-route")]
    public ActionResult<MyRouteResponse> MyRoute([FromBody]MyRouteRequest request)
    {
        return new MyRouteResponse
        {
            Options = request,
        };
    }
}