using BoardGameVoter.Data;
using BoardGameVoter.Logic.SessionManagers;
using BoardGameVoter.Models;
using BoardGameVoter.Services;
using BoardGameVoter.Services.DBContextService;
using BoardGameVoter.Services.SessionService;
using BoardGameVoter.Services.SignInService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Enable Session (1/2)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

//Configure Scss
builder.Services.AddWebOptimizer(pipeline =>
{
    pipeline.AddScssBundle("/css/all.css", "/css/BGV.scss");
});

// Setting up Blob Storage
builder.Services.Configure<StorageAccountOptions>(builder.Configuration.GetSection("StorageAccount"));

// DBContexts
builder.Services.AddDbContext<BoardGameDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<EmailConfirmationTokenDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<LibraryGameDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<LocationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<PasswordResetTokenDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<VoteSessionDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

// Transient Services
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

// Scoped Services
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<IDBContextService, DBContextService>();
builder.Services.AddScoped<IBGVServiceProvider, BGVServiceProvider>();
builder.Services.AddScoped<ISessionService, SessionService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Enable Session (2/2)
app.UseSession();

app.MapRazorPages();

// Middleware to Redirect && Update interaction
app.Use(async (context, next) =>
{
    ISessionManager sessionManager = context.RequestServices.GetRequiredService<ISessionService>().SessionManager;

    List<string> AnnoymousPages = new()
    {
        "/",
        "/Index",
        "/Account/ConfirmEmail",
        "/Account/ForgotPassword",
        "/Account/ForgotPasswordConfirmation",
        "/Account/Lockout",
        "/Account/Login",
        "/Account/Logout",
        "/Account/Register",
        "/Account/RegisterConfirmation",
        "/Account/ResendEmailConfirmation",
        "/Account/ResetPassword",
        "/Account/ResetPasswordConfirmation"
    };

    if (sessionManager.HandleSession(!AnnoymousPages.Contains(context.Request.Path.Value ?? string.Empty)))
    {
        context.Response.Redirect("/Account/Login");
        return;
    }

    sessionManager.UpdateSessionInteraction();

    await next();
});

app.Run();
