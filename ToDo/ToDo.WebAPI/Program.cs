using ToDo.Business;
using ToDo.WebAPI;
using ToDo.WebAPI.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddApiServices(builder.Configuration);
builder.Services.AddBusinessServices();

//builder.Services.AddAutoMapper(typeof(Program));

//builder.Services.AddScoped<ICompanyBs,CompanyBs>();
//builder.Services.AddScoped<ICompanyRepository,CompanyRepository>();

//builder.Services.AddScoped<IUserBs, UserBs>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();

//builder.Services.AddScoped<IProjectBs, ProjectBs>();
//builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCustomException();

app.Run();
