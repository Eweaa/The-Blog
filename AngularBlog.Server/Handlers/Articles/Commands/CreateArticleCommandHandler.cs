using Core.Contexts;
using Core.Entities;
using MediatR;

namespace BlogApp.Handlers.Articles.Commands;

public record CreateArticleCommand : IRequest<Guid>
{
    public required string Title { get; init; }
    public string? Content { get; init; }
    public string? ArticleImg { get; set; }
    public required string UserEmail { get; set; }
    public required string UserName { get; set; }
    
}

public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, Guid>
{
    private readonly ApplicationDbContext context;
    
    public CreateArticleCommandHandler(ApplicationDbContext context)
    {
        this.context = context;
    }

    public async Task<Guid> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = new Article()
        {
            Title = request.Title,
            Content = request.Content,
            Date = DateTime.Now,
            ArticleImg = request.ArticleImg,
            UserEmail = request.UserEmail,
            UserName = request.UserName,
        };
        
        context.Articles.Add(entity);
        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
    
}