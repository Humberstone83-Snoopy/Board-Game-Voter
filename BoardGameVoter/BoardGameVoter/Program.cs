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

// DBContexts
builder.Services.AddDbContext<UserDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));
builder.Services.AddDbContext<UserSessionDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING")));

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

app.Run();
