using BlogApp.Application.Common.Interfaces;
using BlogApp.Domain.Entities;

namespace BlogApp.Application.Articles.Queries;
public record GetArticleQuery(int Id) : IRequest<Article>;
public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, Article>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetArticleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public Task<Article> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var article = _context.Articles.Where(a => a.Id == request.Id).FirstOrDefaultAsync();
        return article!;
    }
}
