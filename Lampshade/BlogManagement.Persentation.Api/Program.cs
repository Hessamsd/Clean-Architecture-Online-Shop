using _0_Framework.Application;
using BlogManagement.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddHttpContextAccessor();
var connectiostring = builder.Configuration.GetConnectionString("LampShadeDb");



BlogManagementBootstrapper.Configure(builder.Services, connectiostring);
CommentManagementBootstrapper.Configure(builder.Services, connectiostring);
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddTransient<IFileUploader, FileUploader>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
