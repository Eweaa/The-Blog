using System.Security.Claims;
using BlogApp.Handlers.Articles.Commands;
using BlogApp.Handlers.Articles.Queries;
using BlogApp.Handlers.Users.Commands;
using BlogApp.Handlers.Users.Queries;
using Core.DTOs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace BlogApp.Controllers;

public class AccountController : BaseController
{
    private readonly UserService userService;
    private readonly ISender sender;

    public AccountController(UserService userService, ISender sender)
    {
        this.userService = userService;
        this.sender = sender;
    }
    
    [HttpPost]
    public async Task<ActionResult> Register(RegisterDto registerDto)
    {
        var res = await userService.Register(registerDto);

        if (res == null)
        {
            return BadRequest("User Already Exists");
        }
        
        return Ok(new { Message = "Success" });
    }

    [HttpPost]
    public async Task<ActionResult> Login(LoginDto loginDto)
    {
        var res = await userService.Login(loginDto);

        if (res == null)
            return Unauthorized();

        var emailClaim = User.Claims.FirstOrDefault(c => c.Type == "Email");
        
        if(emailClaim == null)
            Console.WriteLine("Email claim not found");
        else
            Console.WriteLine("Email claim: " + emailClaim.Value);
        
        return Ok(res);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Follow(string followedUser)
    {
        FollowUserCommand command = new(User.FindFirstValue("Name"), followedUser);
        var res = await sender.Send(command);

        if (res == null || res == false)
            return BadRequest();
        
        return Ok();
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> Unfollow(string unFollowedUser)
    {
        UnfollowUserCommand request = new(User.FindFirstValue("Name"), unFollowedUser);
        var res = await sender.Send(request);
        
        if(res == null || res == false)
            return BadRequest();
        
        return Ok();
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetUserInfo()
    {
        var userName = User.FindFirstValue("Name");
        var res = await sender.Send(new GetUserImage(userName));
        
        if(res == null)
            return NotFound();
        
        return Ok(new {UserImg = res});
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult> GetBookmarks()
    {
        var userName = User.FindFirstValue("Name");
        GetUserBookmarkedArticles request = new(userName);
        var res = await sender.Send(request);
        
        if(res == null)
            return NotFound();
        
        return Ok(res);
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult> AddBookmark(string articleId)
    {
        
        if (Guid.TryParse(articleId, out Guid guid))
        {
            AddBookmarkCommand request = new(guid, User.FindFirstValue("Name"));
                
            var res = await sender.Send(request);

            if (res == false)
            {
                return BadRequest("Already Added");
            }
            else
            {
                return Ok(res);
            }
        }
        
        return BadRequest();
    }
    
    [Authorize]
    [HttpDelete]
    public async Task<ActionResult> RemoveBookmark(string articleId)
    {
        if (Guid.TryParse(articleId, out Guid guid))
        {
            RemoveBookmarkCommand request = new(guid, User.FindFirstValue("Name"));
            var res = await sender.Send(request);
            // if (res == null || res == false)
            //     return NotFound();

            if (res == false)
            {
                return BadRequest("Bookmark Not Found");
            }
            else
            {
                return Ok(res);
            }
        }
        return BadRequest();
    }
}