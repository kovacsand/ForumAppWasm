using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }
    
    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? author = await userDao.GetByIdAsync(dto.AuthorId);
        if (author == null)
            throw new Exception($"User with id {dto.AuthorId} was not found!");

        Post toCreate = new Post(author, dto.Title, dto.Body);
        
        //TODO validate data here

        return await postDao.CreateAsync(toCreate);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters)
    {
        return postDao.GetAsync(searchPostParameters);
    }
}