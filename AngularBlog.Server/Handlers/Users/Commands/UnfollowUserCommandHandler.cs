using MediatR;
using Services;

namespace BlogApp.Handlers.Users.Commands;

public record UnfollowUserCommand(string UserName, string UnFollowedUser) : IRequest<bool>;

public class UnfollowUserCommandHandler(UserService userService) : IRequestHandler<UnfollowUserCommand, bool>
{
    public async Task<bool> Handle(UnfollowUserCommand request, CancellationToken cancellationToken)
    {
        return await userService.Unfollow(request.UserName, request.UnFollowedUser);
    }
}