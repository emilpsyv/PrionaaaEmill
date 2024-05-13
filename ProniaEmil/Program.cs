using ProniaEmil.DataAccesLayer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ProniaEContext>();

var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute("areas","{area:exists}/{controller=Slider}/{action=Index}/{id?}");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();