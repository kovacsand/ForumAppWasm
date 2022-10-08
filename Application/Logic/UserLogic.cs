﻿using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class UserLogic : IUserLogic
{
    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }

    public async Task<User> CreateAsync(UserCreationDto userToCreate)
    {
        User? existing = await userDao.GetByUsernameAsync(userToCreate.Username);
        if (existing != null)
            throw new Exception("Username already taken!");
        
        //TODO validate data here
        
        User toCreate = new User()
        {
            Username = userToCreate.Username
        };

        User created = await userDao.CreateAsync(toCreate);
        return created;
    }

    public Task<IEnumerable<User>> GetAsync(SearchUserParametersDto searchUserParameters)
    {
        return userDao.GetAsync(searchUserParameters);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return userDao.GetByIdAsync(id);
    }

    public Task UpdateAsync(UpdateUserParametersDto updateUserParameters)
    {
        return userDao.UpdateAsync(updateUserParameters);
    }

    public Task DeleteAsync(int id)
    {
        return userDao.DeleteAsync(id);
    }
}