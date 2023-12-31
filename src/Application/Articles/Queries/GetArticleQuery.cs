﻿using The_Blog.Application.Common.Interfaces;

namespace The_Blog.Application.Articles.Queries;
public record GetArticleQuery(int Id) : IRequest<ArticleDto>;
public class GetArticleQueryHandler : IRequestHandler<GetArticleQuery, ArticleDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    public GetArticleQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<ArticleDto> Handle(GetArticleQuery request, CancellationToken cancellationToken)
    {
        var article = await _context.Articles.Where(a => a.Id == request.Id).Include(a => a.Writer).FirstOrDefaultAsync();
        var articleVM = _mapper.Map<ArticleDto>(article);
        return articleVM!;
    }
}
