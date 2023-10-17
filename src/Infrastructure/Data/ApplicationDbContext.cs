using System.Reflection;
using System.Reflection.Emit;
using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;
using BlogApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();
    public DbSet<Writer> Writers => Set<Writer>();
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Bookmark> Bookmarks => Set<Bookmark>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        //builder.Entity<Bookmark>()
        //    .HasMany(b => b.Articles)
        //    .WithOne(a => a.Bookmark)
        //    .HasForeignKey(b => b.BookmarkId);
        //    //.OnDelete(DeleteBehavior.NoAction);

        ////builder.Entity<Article>()
        ////    .HasOne(a => a.Bookmark)
        ////    .WithMany(b => b.Articles)
        ////    .HasForeignKey(a => a.BookmarkId)
        ////    .OnDelete(DeleteBehavior.NoAction);


        //builder.Entity<Bookmark>()
        //    .HasOne(b => b.Writer)
        //    .WithOne(w => w.Bookmark)
        //    .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(builder);
    }
}
