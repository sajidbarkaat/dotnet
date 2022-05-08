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
using API.Helpers;

namespace API.Services;

public interface IUserService
{
    Task<IEnumerable<UserEntity>> GetAll();    
    void Register(UserDto model);
    Task<string> Login(LoginCredentialsDto model);
    
    //AuthenticateResponse Authenticate(AuthenticateRequest model);
    //TUUserDto GetById(int id);
    // void Update(int id, TUUserDto model);
    // void Delete(int id);
}

public class UserService : IUserService
{
    protected readonly ILogger<UserService> logger;
    protected readonly TUDataContext dataContext;

    protected readonly ITokenService tokenService;
    public UserService(TUDataContext dataContext, ILogger<UserService> logger, ITokenService tokenService)
    {
        this.dataContext = dataContext;
        this.logger = logger;
        this.tokenService = tokenService;
    }     

    public async Task<IEnumerable<UserEntity>> GetAll()
    {
       return await this.dataContext.Users.ToListAsync();
    }
    
    public void Register(UserDto userDto)
    {
        using var hmac = new HMACSHA512();

        UserEntity userEntity = new UserEntity {
            FName = userDto.fName,
            LName = userDto.lName,
            Username = userDto.username,
            Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDto.password)),
            Salt = hmac.Key
        };

        this.dataContext.Users.Add(userEntity);
        this.dataContext.SaveChanges();
    }

    public async Task<String> Login(LoginCredentialsDto loginDto) 
    {
        var userDBRecord = await this.dataContext.Users.SingleOrDefaultAsync(user => user.Username == loginDto.Username);

        if(userDBRecord == null) 
        {
            return null;
        }

        using var hmac = new HMACSHA512(userDBRecord.Salt);
        var hashedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        for (int i = 0; i < hashedPassword.Length; i++)        
        {
            if(hashedPassword[i] != userDBRecord.Password[i]) 
            {
                return null;
            }
        } 

        return tokenService.CreateToken(userDBRecord);
    }

    //private IJwtUtils _jwtUtils;
    //private readonly IMapper _mapper;

    // public User GetById(int id)
    // {
    //     return getUser(id);
    // }

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
