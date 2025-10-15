using Microsoft.EntityFrameworkCore;
using Test_Santiagorestrepoarismendy.Data;

var builder = WebApplication.CreateBuilder(args);

// Config AppDbContext to MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

    options.UseMySql(connectionString, serverVersion, mySqlOptions =>
    {
        mySqlOptions.EnableRetryOnFailure(); // for retries automatics in transitory errors
    });
});

// add controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Verific db connection
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    try
    {
        context.Database.OpenConnection();
        Console.WriteLine("✅MySQL OK");
        context.Database.CloseConnection();
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Connection MySQL");
        Console.WriteLine(ex.Message);
        if (ex.InnerException != null)
            Console.WriteLine($"Details: {ex.InnerException.Message}");
    }
}

// Config of pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();