using MediatR;
using Services;

namespace BlogApp.Handlers.Users.Commands;

public record FollowUserCommand(string UserName, string FollowedUserName) : IRequest<bool>;

public class FollowUserCommandHandler(UserService userService) : IRequestHandler<FollowUserCommand, bool>
{
    public async Task<bool> Handle(FollowUserCommand request, CancellationToken cancellationToken)
    {
        var res = await userService.Follow(request.UserName, request.FollowedUserName);
        return res;
    }
}