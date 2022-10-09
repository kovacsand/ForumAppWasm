using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;

namespace FileData.DAOs;

public class PostFileDao : IPostDao
{
    private readonly FileContext context;

    public PostFileDao(FileContext context)
    {
        this.context = context;
    }
    
    public Task<Post> CreateAsync(Post post)
    {
        int postId = 1;
        if (context.Posts.Any())
            postId = context.Posts.Max(post => post.Id) + 1;

        post.Id = postId;
        context.Posts.Add(post);
        context.SaveChanges();
        return Task.FromResult(post);
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchPostParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (!string.IsNullOrEmpty(searchPostParameters.AuthorName))
            posts = posts.Where(post => post.Author.Username.Equals(searchPostParameters.AuthorName, StringComparison.OrdinalIgnoreCase));
        if (searchPostParameters.AuthorId != null)
            posts = posts.Where(post => post.Author.Id == searchPostParameters.AuthorId);
        if (!string.IsNullOrEmpty(searchPostParameters.TitleContains))
            posts = posts.Where(post => post.Title.Contains(searchPostParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrEmpty(searchPostParameters.BodyContains))
            posts = posts.Where(post => post.Body.Contains(searchPostParameters.BodyContains, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(posts);
    }
}