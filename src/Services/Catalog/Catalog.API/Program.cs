using Catalog.API.Data;
using Catalog.API.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//UI Doc - ehsan.jahnagard
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("V1", new OpenApiInfo
    {
        Version = "نسخه 1",
        Title = "لیست کالا ها",
        Description = "وب سرویس فروشگاه"
    });

    ////JWT Init
    //options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    //{
    //    Scheme = "Bearer",
    //    BearerFormat = "JWT",
    //    In = ParameterLocation.Header,
    //    Name = "Authorization",
    //    Description = "Bearer Authentication with JWT Token",
    //    Type = SecuritySchemeType.Http
    //});
    //options.AddSecurityRequirement(new OpenApiSecurityRequirement {
    //    {
    //        new OpenApiSecurityScheme {
    //            Reference = new OpenApiReference {
    //                Id = "Bearer",
    //                    Type = ReferenceType.SecurityScheme
    //            }
    //        },
    //        new List < string > ()
    //    }
    //});
});


builder.Services.AddScoped<ICatalogContext, CatalogContext>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

var app = builder.Build();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
