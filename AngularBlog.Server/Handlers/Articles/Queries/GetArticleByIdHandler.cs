using Core.Entities;
using MediatR;
using Services;

namespace BlogApp.Handlers.Articles.Queries;

public record GetArticleById(Guid Id) : IRequest<Article>;

public class GetArticleByIdHandler(ArticleService articleService) : IRequestHandler<GetArticleById, Article>
{
    public Task<Article> Handle(GetArticleById request, CancellationToken cancellationToken)
    {
        return articleService.GetArticleByIdAsync(request.Id);
    }
}