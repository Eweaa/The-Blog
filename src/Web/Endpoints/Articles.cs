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
            .MapGet(GetArticles)
            .MapGet(GetArticle, "{Id}")
            .MapGet(GetBookmarkArticles, "bookmark/{Id}");
    }
    public async Task<List<ArticleDto>> GetArticles(ISender sender,[AsParameters] GetArticleListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<ArticleDto> GetArticle(ISender sender, [AsParameters] GetArticleQuery query)
    {
        return await sender.Send(query);
    }
    
    public async Task<List<Bookmark>> GetBookmarkArticles(ISender sender, [AsParameters] GetBookmarkArticleListQuery query)
    {
        return await sender.Send(query);
    }
}
