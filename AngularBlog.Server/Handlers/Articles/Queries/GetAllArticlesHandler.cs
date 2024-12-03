using Core.Contexts;
using Core.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Services;

namespace BlogApp.Handlers.Articles.Queries;

public record GetAllArticles : IRequest<List<Article>>;

public class GetAllArticlesHandler(ApplicationDbContext context, ArticleService articleService) : IRequestHandler<GetAllArticles, List<Article>>
{
    public async Task<List<Article>> Handle(GetAllArticles request, CancellationToken cancellationToken)
    {
        var articles = await articleService.GetAllArticlesAsync();
        return articles;
    }
}