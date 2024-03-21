using Project.BLL.ServiceInjections;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); //E�er session komplex yap�larla �al��mak i�in Extension metodu eklenme durumuna maruz kalm��ssa bu kod projenizin sa�l�kl� �al��mas� i�in gereklidir...

builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddDbContextService(); //DbContextService'imizi BLL'den alarak middleware'e entegre ettik...
builder.Services.AddIdentityServices();

builder.Services.AddRepServices(); // �ok daha temiz bir hale getirdik.
builder.Services.AddManagerServices();






WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
