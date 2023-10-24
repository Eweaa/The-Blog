using BlogApp.Application.Bookmarks;

namespace BlogApp.Web.Endpoints;

public class Bookmarks : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this).
            RequireAuthorization()
            .MapPost(AddBookmark);
    }
    public async Task<int> AddBookmark(ISender sender, [AsParameters] AddBookmarkCommand command)
    {
        return await sender.Send(command);
    }
}
