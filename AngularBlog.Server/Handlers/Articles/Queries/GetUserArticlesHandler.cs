using Core.DTOs;
using Core.Entities;
using MediatR;
using Services;

namespace BlogApp.Handlers.Articles.Queries;

public record GetUserArticles(string UserProfile, string UserName) : IRequest<UserProfileDto>;
public class GetUserArticlesHandler(ArticleService articleService) : IRequestHandler<GetUserArticles, UserProfileDto>
{
    public async Task<UserProfileDto> Handle(GetUserArticles request, CancellationToken cancellationToken)
    {
        return await articleService.GetUserArticlesAsync(request.UserProfile, request.UserName);
    }
}