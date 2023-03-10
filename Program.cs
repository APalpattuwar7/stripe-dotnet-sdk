using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

DotNetEnv.Env.Load();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
//builder.UseWebRoot("../client");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseFileServer();
app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
