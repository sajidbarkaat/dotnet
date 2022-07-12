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
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace API.Services;

public interface IUserService
{
    Task<IEnumerable<UserEntity>> GetAll();    
    Task<UserRegisteredDto> Register(UserDto model);
    Task<UserAuthenticatedDto> Login(LoginCredentialsDto model);    
   
    //TUUserDto GetById(int id);
    // void Update(int id, TUUserDto model);
    // void Delete(int id);
}

public class UserService : IUserService
{
    protected readonly ILogger<UserService> logger;    
    protected readonly ITokenService tokenService;
    protected readonly IUserRespository userRepository;
    protected readonly IMapper mapper;
    public UserService(IUserRespository userRepository,                         
                        ITokenService tokenService,
                        ILogger<UserService> logger, 
                        IMapper mapper
                        )
    {
        this.userRepository = userRepository;
        this.tokenService = tokenService;
        this.logger = logger;
        this.mapper = mapper;
    }     

    public async Task<IEnumerable<UserEntity>> GetAll()
    {
       IEnumerable<UserEntity> userList =  await this.userRepository.FetchAll();
       return userList;
    }
    
    public async Task<UserRegisteredDto> Register(UserDto userDto)
    {

        UserEntity userEntity = new UserEntity {
            FName = userDto.FName,
            LName = userDto.LName,
            UserName = userDto.UserName.ToLower(),

        };

        var output = await this.userRepository.Create(userEntity, userDto.Password);

        if(!output.Succeeded) {
            return null;
        }

        return this.mapper.Map<UserRegisteredDto>(userEntity);
    }

    public async Task<UserAuthenticatedDto> Login(LoginCredentialsDto loginDto) 
    {
        var userDBRecord = await this.userRepository.FindByUsername(loginDto.UserName.ToLower());

        if(userDBRecord == null) 
        {
            return null;
        }

        var output = await this.userRepository.CheckPassword(userDBRecord, loginDto.Password);

        if(!output.Succeeded) {
            return null;
        }        
        
        string token = tokenService.CreateToken(userDBRecord);
        UserAuthenticatedDto dto = new UserAuthenticatedDto(userDBRecord.Id, loginDto.UserName, token);
        return dto;
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
