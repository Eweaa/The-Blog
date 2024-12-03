using Core.Entities;
using MediatR;
using Services;

namespace BlogApp.Handlers.Articles.Queries;

public record GetHomeArticles(string UserName) : IRequest<List<Article>>;

public class GetHomeArticlesHandler(ArticleService articleService) : IRequestHandler<GetHomeArticles, List<Article>>
{
    public async Task<List<Article>> Handle(GetHomeArticles request, CancellationToken cancellationToken)
    {
        var res = await articleService.GetFollowedUsersArticles(request.UserName);
        return res;
    }
}