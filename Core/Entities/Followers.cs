namespace Core.Entities;

public class Followers
{
    public required string UserName { get; set; }
    public required string FollowedUserName { get; set; }
    public string? FollowedUserImage { get; set; }
}