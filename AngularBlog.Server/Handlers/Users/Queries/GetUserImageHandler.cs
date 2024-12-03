using MediatR;
using Services;

namespace BlogApp.Handlers.Users.Queries;

public record GetUserImage(string UserName) : IRequest<string>;

public class GetUserImageHandler(UserService userService) : IRequestHandler<GetUserImage, string>
{
    public async Task<string> Handle(GetUserImage request, CancellationToken cancellationToken)
    {
        var img = await userService.getUserImageAsync(request.UserName);
        return img;
    }
}