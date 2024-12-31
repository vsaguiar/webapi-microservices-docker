using AutoMapper;
using DiscountGRPC.Repositories;
using DiscountGRPC.Mapper;
using DiscountGRPC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
#region Registrando o serviço AutoMapper
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new DiscountProfile());
});
IMapper mapper = mappingConfig.CreateMapper();

builder.Services.AddSingleton(mapper);
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<DiscountService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
