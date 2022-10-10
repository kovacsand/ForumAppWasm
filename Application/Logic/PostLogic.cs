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

    public Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto postSearchParameters)
    {
        return postDao.GetAsync(postSearchParameters);
    }

    public async Task UpdateAsync(PostUpdateParametersDto postUpdateParameters)
    {
        Post? existing = await postDao.GetByIdAsync(postUpdateParameters.Id);
        if (existing == null)
            throw new Exception($"Post with ID {postUpdateParameters.Id} not found!");

        User? author = null;
        if (postUpdateParameters.AuthorId != null)
        {
            author = await userDao.GetByIdAsync(postUpdateParameters.Id);
            if (author == null)
                throw new Exception($"User with ID {postUpdateParameters.AuthorId} not found!");
        }
        
        Post updated = new (author ?? existing.Author, postUpdateParameters.Title ?? existing.Title, postUpdateParameters.Body ?? existing.Body)
        {
            Id = existing.Id
        };
        
        //TODO validate data here, if neccessary

        await postDao.UpdateAsync(updated);
    }
}