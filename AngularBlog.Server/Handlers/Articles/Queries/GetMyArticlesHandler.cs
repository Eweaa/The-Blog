using Core.Entities;
using MediatR;
using Services;

namespace BlogApp.Handlers.Articles.Queries;

public record GetMyArticles(string Email) : IRequest<List<Article>>;

public class GetMyArticlesHandler(ArticleService articleService) : IRequestHandler<GetMyArticles, List<Article>>
{
    public async Task<List<Article>> Handle(GetMyArticles request, CancellationToken cancellationToken)
    {
        var articles = await articleService.GetMyArticlesAsync(request.Email);
        return articles;
    }
}