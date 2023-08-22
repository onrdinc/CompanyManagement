
using ToDo.MvcUI.Areas.Admin.HttpApiServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();//httpcontext.sessionu kullanabilmek için ilgili servisi container a register etmeliyiz
builder.Services.AddHttpContextAccessor(); //uygulamada IhttpContextAccessor tipindeki bir nesnenin istenilen alana inject edilebilesi için container'a register etmemiz gerekiyor

builder.Services.AddHttpClient(); //httpclient nesnesi isteyen yerlere bu nesneyi verebilmesi için
builder.Services.AddScoped<IHttpApiService, HttpApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseSession();//sessionu kullanabilmek için pipeline'a eklememiz gerekiyor

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "adminAreaDefault",
    areaName: "admin",
    pattern: "{area}/{controller=Authentication}/{action=LogIn}/{id?}"
  );

app.MapAreaControllerRoute(
    name: "userAreaDefault",
    areaName: "user",
    pattern: "{area}/{controller=Authentication}/{action=LogIn}/{id?}"
  );


app.Run();
