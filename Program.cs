using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    WebRootPath = "client"
});

DotNetEnv.Env.Load();

builder.Services.Configure<StripeOptions>(options => {
    options.SecretKey = Environment.GetEnvironmentVariable("STRIPE_SECRET_KEY");
    options.PublishableKey = Environment.GetEnvironmentVariable("STRIPE_PUBLISHABLE_KEY");
    options.WebhookSecret = Environment.GetEnvironmentVariable("STRIPE_WEBHOOK_KEY");
});
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => {
    options.SerializerSettings.ContractResolver = new DefaultContractResolver
    {
        NamingStrategy = new SnakeCaseNamingStrategy(),
    };
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseFileServer();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

app.Run();
