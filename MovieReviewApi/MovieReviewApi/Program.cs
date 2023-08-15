using MovieReviewApi.Extensions;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAllServices();
builder.Services.ConfigureCors();
builder.Services.MapConfig();
builder.Services.ConfigureIdentity();
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

builder.Services.RegisterServices();
builder.Services.JWTConfiguration(builder.Configuration);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsConfig");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();