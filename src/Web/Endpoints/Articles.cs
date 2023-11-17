using The_Blog.Application.Articles.Commands;
using The_Blog.Application.Articles.Queries;
using The_Blog.Application.Articles;

namespace BlogApp.Web.Endpoints;

public class Articles : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //.RequireAuthorization()
            .MapGet(GetArticles)
            .MapGet(GetArticle, "{Id}")
            .MapGet(GetBookmarkArticles, "bookmark/{Id}")
            .MapPost(CreateArticle);
    }
    public async Task<List<ArticleDto>> GetArticles(ISender sender, [AsParameters] GetArticleListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<ArticleDto> GetArticle(ISender sender, [AsParameters] GetArticleQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<List<BookmarkDto>> GetBookmarkArticles(ISender sender, [AsParameters] GetBookmarkArticleListQuery query)
    {
        return await sender.Send(query);
    }

    public async Task<int> CreateArticle(ISender sender, [AsParameters] CreateArticleCommand command)
    {
        return await sender.Send(command);
    }
}
