using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;
namespace BlogApp.Application.Writers;
public record GetWriterQuery(int Id) : IRequest<Writer>;
public class GetWriterQueryHandler : IRequestHandler<GetWriterQuery, Writer>
{
    private readonly IApplicationDbContext _context;
    public GetWriterQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public Task<Writer> Handle(GetWriterQuery request, CancellationToken cancellationToken)
    {
        var writer = _context.Writers.Where(w => w.Id == request.Id).FirstOrDefaultAsync();
        return writer!;
    }
}
