using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extension.Options;
using Stripe;

public class PaymentController : Controller
{
    private readonly IOptions<StripeOptions> options;

    public PaymentController(IOptions<StripeOptions> options)
    {
        this.options = options;
    }
}