using MediatR;
using Services;

namespace BlogApp.Handlers.Articles.Commands;

public record RemoveBookmarkCommand(Guid ArticleId, string UserName) : IRequest<bool>;

public class RemoveBookmarkCommandHandler(ArticleService articleService) : IRequestHandler<RemoveBookmarkCommand, bool>
{
    public async Task<bool> Handle(RemoveBookmarkCommand request, CancellationToken cancellationToken)
    {
        return await articleService.RemoveBookmark(request.ArticleId, request.UserName);
    }
}