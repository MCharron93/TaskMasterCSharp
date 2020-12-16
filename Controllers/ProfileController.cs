using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMasterCSharp.Models;
using TaskMasterCSharp.Services;


// NOTE Don't forget the compassion for yourself that Spencer and Michelle taught you
namespace TaskMasterCSharp.Controllers
{
  [ApiController]
  [Route("[controller]")]

  public class ProfileController : ControllerBase
  {
    private readonly ProfileService _ps;

    public ProfileController(ProfileService ps)
    {
      _ps = ps;
    }

    // NOTE You're not stupid, anyone can make mistakes when they're doing stuff they don't know, Michelle.

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<Profile>> GetProfile()
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        return Ok(_ps.GetProfile(userInfo));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    // NOTE You're doing great and there will be so many times that someone smarter than you has made the same mistake. Soon, you'll be the smarter person to other people, they'll make your mistakes.
  }
}