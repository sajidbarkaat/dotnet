using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories;

public interface IUserRespository
{
    Task<IdentityResult> Create(UserEntity entity, string password);
    Task<UserEntity> FindByUsername(string username);
    Task<List<UserEntity>> FetchAll();

     Task<SignInResult> CheckPassword(UserEntity userEntity, string password);
}

public class UserRepository: IUserRespository
{    
    protected readonly TUDataContext dataContext;    

    protected readonly UserManager<UserEntity> userManager;
    protected readonly  SignInManager<UserEntity> signinManager;

    public UserRepository(TUDataContext dataContext,
                        UserManager<UserEntity> userManager,
                        SignInManager<UserEntity> signinManager)
    {
        this.dataContext = dataContext;        
        this.userManager = userManager;
        this.signinManager = signinManager;
    }

    public Task<IdentityResult> Create(UserEntity entity, string password) 
    {
        return this.userManager.CreateAsync(entity, password);
    }

    public Task<UserEntity> FindByUsername(string username) {        
        return this.userManager.Users.FirstOrDefaultAsync(user => user.UserName == username);
    }

    public Task<List<UserEntity>> FetchAll() {
        return this.dataContext.Users.ToListAsync();
    }

    public Task<SignInResult> CheckPassword(UserEntity userEntity, string password) {
        return this.signinManager.CheckPasswordSignInAsync(userEntity, password, false);
    }
}
