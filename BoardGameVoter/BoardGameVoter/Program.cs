using BoardGameVoter.Data;
using BoardGameVoter.Services;
using Microsoft.EntityFrameworkCore;

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

// DBContexts
builder.Services.AddDbContext<BoardGameDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<EmailConfirmationTokenDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<LibraryGameDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<LocationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<PasswordResetTokenDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<UserSessionDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
//builder.Services.AddDbContext<VoteDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
//builder.Services.AddDbContext<VoteSessionAttendeeDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<VoteSessionDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
//builder.Services.AddDbContext<VoteSessionResultDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

// Transient Services
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

// Scoped Services
builder.Services.AddScoped<ISignInService, SignInService>();
builder.Services.AddScoped<ISessionManager, SessionManager>();

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
app.Use(async (ctx, next) =>
{
    ISessionManager sessionManager = ctx.RequestServices.GetRequiredService<ISessionManager>();

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

    if (sessionManager.HandleSession(!AnnoymousPages.Contains(ctx.Request.Path.Value ?? string.Empty)))
    {
        ctx.Response.Redirect("/Account/Login");
        return;
    }

    sessionManager.UpdateSessionInteraction();

    await next();
});

app.Run();
