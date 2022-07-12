using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class TUDataContext: IdentityDbContext<
                            UserEntity, 
                            RoleEntity, 
                            int, 
                            IdentityUserClaim<int>, 
                            UserRoleEntity, 
                            IdentityUserLogin<int>,
                            IdentityRoleClaim<int>,
                            IdentityUserToken<int>>
{
    protected readonly IConfiguration Configuration;
    public TUDataContext(IConfiguration configuration) {
        this.Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseSqlServer(Configuration.GetConnectionString("ApiDatabase"));
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<UserEntity>()
        .HasMany(userRole => userRole.UserRoles)
        .WithOne(user => user.User)
        .HasForeignKey(userRole => userRole.UserId)
        .IsRequired();

        builder.Entity<RoleEntity>()
        .HasMany(userRole => userRole.UserRoles)
        .WithOne(user => user.Role)
        .HasForeignKey(userRole => userRole.RoleId)
        .IsRequired();
    }
}
