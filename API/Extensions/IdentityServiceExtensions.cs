// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using API.Data;
// using API.Entities;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.IdentityModel.Tokens;

// namespace API.Extensions;

// public static class IdentityServiceExtensions
// {
//     public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
//     {

//         services.AddIdentityCore<UserEntity>(opt => {
//             opt.Password.RequireNonAlphanumeric = false;
//         })
//         .AddRoles<RoleEntity>()
//         .AddRoleManager<RoleManager<RoleEntity>>()
//         .AddSignInManager<SignInManager<UserEntity>>()
//         .AddRoleValidator<RoleValidator<RoleEntity>>()
//         .AddEntityFrameworkStores<TUDataContext>();        

//         services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//         .AddJwtBearer( options =>
//         {
//             options.TokenValidationParameters = new TokenValidationParameters
//             {
//                 ValidateIssuerSigningKey = true,
//                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"])),
//                 ValidateIssuer = false,
//                 ValidateActor = false
//             };
//         });

//         return services;
//     }
// }
