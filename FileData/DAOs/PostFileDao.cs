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

    public Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto postSearchParameters)
    {
        IEnumerable<Post> posts = context.Posts.AsEnumerable();
        if (!string.IsNullOrEmpty(postSearchParameters.AuthorName))
            posts = posts.Where(post => post.Author.Username.Equals(postSearchParameters.AuthorName, StringComparison.OrdinalIgnoreCase));
        if (postSearchParameters.AuthorId != null)
            posts = posts.Where(post => post.Author.Id == postSearchParameters.AuthorId);
        if (!string.IsNullOrEmpty(postSearchParameters.TitleContains))
            posts = posts.Where(post => post.Title.Contains(postSearchParameters.TitleContains, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrEmpty(postSearchParameters.BodyContains))
            posts = posts.Where(post => post.Body.Contains(postSearchParameters.BodyContains, StringComparison.OrdinalIgnoreCase));

        return Task.FromResult(posts);
    }

    public Task<Post?> GetByIdAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(post => post.Id == id);
        return Task.FromResult(existing);
    }

    public Task UpdateAsync(Post post)
    {
        Post? existing = context.Posts.FirstOrDefault(foundPost => foundPost.Id == post.Id);
        if (existing == null)
            throw new Exception($"Post with ID {post.Id} not found!");

        context.Posts.Remove(existing);
        context.Posts.Add(post);
        context.SaveChanges();

        return Task.CompletedTask;
    }

    public Task DeleteAsync(int id)
    {
        Post? existing = context.Posts.FirstOrDefault(post => post.Id == id);
        if (existing == null)
            throw new Exception($"Post with ID {id} not found!");

        context.Posts.Remove(existing);
        context.SaveChanges();

        return Task.CompletedTask;
    }
}