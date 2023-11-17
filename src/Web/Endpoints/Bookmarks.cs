using The_Blog.Application.Bookmarks;

namespace The_Blog.Web.Endpoints;

public class Bookmarks : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            //RequireAuthorization()
            .MapPost(AddBookmark)
            .MapDelete(RemoveBookmark, "/{Id}");
    }
    public async Task<int> AddBookmark(ISender sender, [AsParameters] AddBookmarkCommand command)
    {
        return await sender.Send(command);
    }

    public async Task RemoveBookmark(ISender sender, [AsParameters] RemoveBookmarkCommand command)
    {
        await sender.Send(command);
    }
}
