using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.Dto;
using API.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Services;

public interface IUserService
{
    //AuthenticateResponse Authenticate(AuthenticateRequest model);
    Task<IEnumerable<UserEntity>> GetAll();
    //TUUserDto GetById(int id);
    void Register(UserDto model);
    // void Update(int id, TUUserDto model);
    // void Delete(int id);
}

public class UserService : IUserService
{
    
    //private IJwtUtils _jwtUtils;
    //private readonly IMapper _mapper;

    protected readonly ILogger<UserService> logger;
    protected readonly TUDataContext tuDataContext;
    public UserService(TUDataContext dataContext, ILogger<UserService> logger)
    {
        this.tuDataContext = dataContext;
        this.logger = logger;
    }     

    public async Task<IEnumerable<UserEntity>> GetAll()
    {
       return await this.tuDataContext.Users.ToListAsync();
    }

    // public User GetById(int id)
    // {
    //     return getUser(id);
    // }

    public async void Register(UserDto userDto)
    {
        using var hmac = new HMACSHA512();

        UserEntity userEntity = new UserEntity {
            FName = userDto.FName,
            LName = userDto.LName,
            Username = userDto.Username,
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.Password)),
            Salt = hmac.Key
        };

        this.tuDataContext.Users.Add(userEntity);
        await this.tuDataContext.SaveChangesAsync();
    }

    // public void Update(int id, UpdateRequest model)
    // {
    //     var user = getUser(id);

    //     // validate
    //     if (model.Username != user.Username && _context.Users.Any(x => x.Username == model.Username))
    //         throw new AppException("Username '" + model.Username + "' is already taken");

    //     // hash password if it was entered
    //     if (!string.IsNullOrEmpty(model.Password))
    //         user.PasswordHash = BCrypt.HashPassword(model.Password);

    //     // copy model to user and save
    //     _mapper.Map(model, user);
    //     _context.Users.Update(user);
    //     _context.SaveChanges();
    // }

    // public void Delete(int id)
    // {
    //     var user = getUser(id);
    //     _context.Users.Remove(user);
    //     _context.SaveChanges();
    // }

    // helper methods

    // private User getUser(int id)
    // {
    //     var user = _context.Users.Find(id);
    //     if (user == null) throw new KeyNotFoundException("User not found");
    //     return user;
    // }
}
