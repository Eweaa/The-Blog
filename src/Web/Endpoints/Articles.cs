using BlogApp.Application.Articles;
using BlogApp.Application.Articles.Queries;
using BlogApp.Domain.Entities;

namespace BlogApp.Web.Endpoints;

public class Articles : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetArticles);
    }
    public async Task<List<Article>> GetArticles(ISender sender,[AsParameters] GetArticleListQuery query)
    {
        return await sender.Send(query);
    }
}
