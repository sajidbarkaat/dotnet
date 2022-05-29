using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;
public class TUDataContext: DbContext
{
    protected readonly IConfiguration Configuration;
    public TUDataContext(IConfiguration configuration) {
        this.Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
        options.UseSqlServer(Configuration.GetConnectionString("ApiDatabase"));
    }

    public DbSet<UserEntity> Users {get; set;}

    public DbSet<SAP_PriceListEntity> SAP_PriceList { get; set; }
}
