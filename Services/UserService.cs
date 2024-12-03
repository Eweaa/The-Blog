using Core.Contexts;
using Core.DTOs;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Services;

public class UserService
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;
    private readonly TokenService tokenService;
    private readonly ApplicationDbContext context;

    public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService, ApplicationDbContext context)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.tokenService = tokenService;
        this.context = context;
    }

    public async Task<IdentityResult?> Register(RegisterDto registerDto)
    {
        var user = await userManager.FindByEmailAsync(registerDto.Email);

        if (user != null)
            return null;

        var appUser = new AppUser()
        {
            DisplayName = registerDto.DisplayName,
            Email = registerDto.Email,
            UserName = registerDto.Email.Split("@").First(),
        };

        var result = await userManager.CreateAsync(appUser, registerDto.Password);

        return !result.Succeeded ? null : result;
    }

    public async Task<UserDto?> Login(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        
        if (user == null)
            return null;
        
        var res = await signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

        if (!res.Succeeded)
            return null;

        return new UserDto()
        {
            DisplayName = user.DisplayName,
            Email = user.Email,
            Token = await tokenService.CreateToken(user)
        };
    }

    public async Task<bool> Follow(string userName, string followedUserName)
    {
        var followedUser = await userManager.FindByNameAsync(followedUserName);
        
        if (followedUser == null)
            return false;
        
        var follow = new Followers() {UserName = userName, FollowedUserName = followedUserName, FollowedUserImage = followedUser?.UserImg};
        context.Followers.Add(follow);
        
        await context.SaveChangesAsync();
        
        return true;
    }

    public async Task<bool> Unfollow(string userName, string unFollowedUserName)
    {
        var follow = await context.Followers.FirstOrDefaultAsync(f => f.FollowedUserName == unFollowedUserName && f.UserName == userName);
        context.Followers.Remove(follow);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<string> getUserImageAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        return Utilities.ModifyPath(user?.UserImg);
    }
}