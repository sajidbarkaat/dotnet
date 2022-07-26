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
    Task<IdentityResult> Create(IdentityUser user, string password);
    Task<IdentityUser> FindByUsername(string username);
    Task<List<IdentityUser>> FetchAll();
    Task<SignInResult> CheckPassword(IdentityUser identityUser, string password);
    Task<IList<string>> GetUserRoles(IdentityUser identityUser);
}

public class UserRepository : IUserRespository
{
    protected readonly TUDataContext dataContext;

    protected readonly UserManager<IdentityUser> userManager;
    protected readonly SignInManager<IdentityUser> signinManager;

    public UserRepository(TUDataContext dataContext,
                        UserManager<IdentityUser> userManager,
                        SignInManager<IdentityUser> signinManager)
    {
        this.dataContext = dataContext;
        this.userManager = userManager;
        this.signinManager = signinManager;
    }

    public Task<IdentityResult> Create(IdentityUser identityUser, string password)
    {
        return this.userManager.CreateAsync(identityUser, password);
    }

    public Task<IdentityUser> FindByUsername(string username)
    {
        return this.userManager.Users.FirstOrDefaultAsync(user => user.UserName == username);
    }

    public Task<List<IdentityUser>> FetchAll()
    {
        return this.dataContext.Users.ToListAsync();
    }

    public Task<SignInResult> CheckPassword(IdentityUser identityUser, string password)
    {
        return this.signinManager.CheckPasswordSignInAsync(identityUser, password, false);
    }

    public Task<IList<string>> GetUserRoles(IdentityUser identityUser)
    {
        return this.userManager.GetRolesAsync(identityUser);
    }
}
