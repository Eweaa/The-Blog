using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Articles.Commands;
public record CreateArticleCommand : IRequest<int>
{
    public required string Title { get; init; }
    public string? content { get; init; }
    public string? ArticleImg { get; init; }
    public int WriterId { get; init; }
}
public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand, int>
{
    private readonly IApplicationDbContext _context;
    public CreateArticleCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
        var entity = new Article
        {
            Title = request.Title,
            Content = request.content,
            ArticleImg = request.ArticleImg,
            Date = DateTime.Now,
            WriterId = request.WriterId
        };
        _context.Articles.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
