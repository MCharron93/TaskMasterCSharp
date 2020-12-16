using System.Collections.Generic;
using System.Threading.Tasks;
using CodeWorks.Auth0Provider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskMasterCSharp.Models;
using TaskMasterCSharp.Services;

namespace TaskMasterCSharp.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BlogController : ControllerBase
  {
    private readonly BlogService _bs;

    public BlogController(BlogService bs)
    {
      _bs = bs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Blog>> Create([FromBody] Blog newBlog)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newBlog.CreatorId = userInfo.Id;
        Blog createdNew = _bs.Create(newBlog);
        return Ok(createdNew);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<Blog>> GetBlogs()
    {
      try
      {
        return Ok(_bs.GetBlogs());
      }
      catch (System.Exception)
      {

        throw;
      }
    }
  }
}