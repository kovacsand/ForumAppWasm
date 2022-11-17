using Application.DaoInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly DatabaseContext context;

    public PostEfcDao(DatabaseContext context)
    {
        this.context = context;
    }

    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newTodo = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newTodo.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync(PostSearchParametersDto postSearchParameters)
    {
        IQueryable<Post> query = context.Posts.Include(todo => todo.Author).AsQueryable();
    
        if (!string.IsNullOrEmpty(postSearchParameters.AuthorName))
            query = query.Where(todo => todo.Author.Username.ToLower().Equals(postSearchParameters.AuthorName.ToLower()));

        if (postSearchParameters.AuthorId != null)
            query = query.Where(todo => todo.Author.Id == postSearchParameters.AuthorId);

        if (!string.IsNullOrEmpty(postSearchParameters.TitleContains))
            query = query.Where(todo => todo.Title.ToLower().Contains(postSearchParameters.TitleContains.ToLower()));

        if (!string.IsNullOrEmpty(postSearchParameters.BodyContains))
            query = query.Where(todo => todo.Body.ToLower().Contains(postSearchParameters.BodyContains.ToLower()));
        
        List<Post> result = await query.ToListAsync();
        return result;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? found = await context.Posts
            .AsNoTracking()
            .Include(todo => todo.Author)
            .SingleOrDefaultAsync(post => post.Id == id);
        return found;
    }

    public async Task UpdateAsync(Post post)
    {
        context.Posts.Update(post);
        await context.SaveChangesAsync(); 
    }

    public async Task DeleteAsync(int id)
    {
        Post? existing = await GetByIdAsync(id);
        if (existing == null)
            throw new Exception($"Post with id {id} not found!");
        
        context.Posts.Remove(existing);
        await context.SaveChangesAsync();
    }
}