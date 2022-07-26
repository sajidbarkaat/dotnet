using System.Text;
using System.Text.Json.Serialization;
using API.Data;
using API.Helpers;
using API.Middlewares;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using API.Repositories;
using API.Entities;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TUDataContext>();
// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<TUDataContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;        
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,            
            ValidAudience = builder.Configuration["Jwt:Audience"],
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),            

        };
    });

// List<string> adminRoles = new List<string> {
//     "SuperAdmin",
//     "Admin"
// };

// builder.Services.AddAuthorization(opt => {    
//     opt.AddPolicy("RequiredSuperAdminRole", policy => policy.RequireRole("SuperAdmin"));    
//     opt.AddPolicy("RequireAdminRole", policy => policy.RequireRole(adminRoles));    
//     opt.AddPolicy("RequireModeratorRole", policy => policy.RequireRole("Moderator"));
// });

//DI for application services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRespository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

builder.Services.AddCors();
builder.Services.AddControllers();
// .AddJsonOptions(jsonOptions =>
// {
//     //Serialize enums as strings in response
//     jsonOptions.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

//     //Ignore omitted parameters on models to enable optional params
//     jsonOptions.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
// });


//
// configure strongly typed settings object
//services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<TUDataContext>();
    context.Database.Migrate();
}

app.UseMiddleware<ExceptionMiddleware>();

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
