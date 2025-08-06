using Microsoft.EntityFrameworkCore;
using OMS.EFCore.Data;
using OMS.EFCore.Repositories.Implements;
using OMS.EFCore.Repositories.Interfaces;
using OMS.EFCore.Services.Implements;
using OMS.EFCore.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<IOMSEFCoreDbContext, OMSEFCoreDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OMSEFCoreDbContext"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<IOMSEFCoreDbContext>();

    if (!dbContext.Database.CanConnect())
    {
        throw new NotImplementedException("Can't connect to database, please check again!");
    }
}

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
