using The_Blog.Application.Writers;

namespace The_Blog.Web.Endpoints;

public class Writers : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetWriter, "{Id}");
    }
    public async Task<WriterDto> GetWriter(ISender sender, [AsParameters] GetWriterQuery query)
    {
        return await sender.Send(query);
    }
}
