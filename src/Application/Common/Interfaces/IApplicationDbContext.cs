using BlogApp.Domain.Entities;

namespace BlogApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }
    DbSet<TodoItem> TodoItems { get; }
    DbSet<Writer> Writers { get; }
    DbSet<Article> Articles { get; }
    DbSet<Comment> Comments { get; }
    DbSet<Bookmark> Bookmarks { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
