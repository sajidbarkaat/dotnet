using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public interface IUserRespository
{
    Task<int> Create(UserEntity entity);
    Task<UserEntity> FindByUsername(string username);

    Task<List<UserEntity>> FetchAll();
}

public class UserRepository: IUserRespository
{
    protected readonly TUDataContext dataContext;
    public UserRepository(TUDataContext dataContext)
    {
        this.dataContext = dataContext;
    }

    public Task<int> Create(UserEntity entity) {
        this.dataContext.Users.Add(entity);
        return this.dataContext.SaveChangesAsync();
    }

    public Task<UserEntity> FindByUsername(string username) {        
        return this.dataContext.Users.FirstOrDefaultAsync(user => user.Username == username);
    }

    public Task<List<UserEntity>> FetchAll() {
        return this.dataContext.Users.ToListAsync();
    }
}
