using MediatR;
using Services;

namespace BlogApp.Handlers.Articles.Commands;

public record AddBookmarkCommand(Guid ArticleId, string UserName) : IRequest<bool>;

public class AddBookmarkCommandHandler(ArticleService articleService) : IRequestHandler<AddBookmarkCommand, bool>
{
    public async Task<bool> Handle(AddBookmarkCommand request, CancellationToken cancellationToken)
    {
        return await articleService.AddBookmark(request.ArticleId, request.UserName);
    }
}