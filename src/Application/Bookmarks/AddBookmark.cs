using The_Blog.Application.Common.Interfaces;
using The_Blog.Domain.Entities;

namespace The_Blog.Application.Bookmarks;
public record AddBookmarkCommand : IRequest<int>
{
    public int ArticleId { get; set; }
    public int WriterId { get; set; }
}
public class AddBookmarkCommandHandler : IRequestHandler<AddBookmarkCommand, int>
{
    private readonly IApplicationDbContext _context;
    public AddBookmarkCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<int> Handle(AddBookmarkCommand request, CancellationToken cancellationToken)
    {
        var entity = new Bookmark
        {
            ArticleId = request.ArticleId,
            WriterId = request.WriterId
        };

        _context.Bookmarks.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);
        return entity.Id;
    }
}
