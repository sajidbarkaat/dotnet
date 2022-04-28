using System.Text.Json.Serialization;
using API.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TUDataContext>();

builder.Services.AddControllers().AddJsonOptions(jsonOptions => {
    //Serialize enums as strings in response
    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    //Ignore omitted parameters on models to enable optional params
    jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

//Auto mapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//DI for application services
//builder.Services.AddScoped<Interface, ActualImplementation>();
//
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

app.UseCors(policy => 
    policy
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
