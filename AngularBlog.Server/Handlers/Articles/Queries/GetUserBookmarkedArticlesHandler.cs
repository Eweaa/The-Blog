using Core.Entities;
using MediatR;
using Services;

namespace BlogApp.Handlers.Articles.Queries;

public record GetUserBookmarkedArticles(string UserName) : IRequest<List<Article>>;

public class GetUserBookmarkedArticlesHandler(ArticleService articleService) : IRequestHandler<GetUserBookmarkedArticles, List<Article>>
{
    public async Task<List<Article>> Handle(GetUserBookmarkedArticles request, CancellationToken cancellationToken)
    {
        return await articleService.GetBookmarkedArticlesAsync(request.UserName);
    }
}