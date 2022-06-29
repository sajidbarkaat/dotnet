using System.Text;
using System.Text.Json.Serialization;
using API.Data;
using API.Helpers;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TUDataContext>();

//
//DI for application services
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISAPPriceListService, SAP_PriceListService>();
builder.Services.AddScoped<ISAPDeliveryNoteHeaderService, SAP_DeliveryNoteHeaderService>();
builder.Services.AddScoped<ISAPDeliveryNoteRowService, SAPDeliveryNoteRowService>();


builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(jsonOptions =>
{
    //Serialize enums as strings in response
    jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    //Ignore omitted parameters on models to enable optional params
    jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => 
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters 
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

//
//Auto mapper
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//
// configure strongly typed settings object
//services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
