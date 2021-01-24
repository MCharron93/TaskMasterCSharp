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
  public class ListController : ControllerBase
  {
    private readonly ListService _bs;

    public ListController(ListService bs)
    {
      _bs = bs;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<List>> Create([FromBody] List newList)
    {
      try
      {
        Profile userInfo = await HttpContext.GetUserInfoAsync<Profile>();
        newList.CreatorId = userInfo.Id;
        List createdNew = _bs.Create(newList);
        return Ok(createdNew);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet]
    public ActionResult<IEnumerable<List>> GetLists()
    {
      try
      {
        return Ok(_bs.GetLists());
      }
      catch (System.Exception)
      {

        throw;
      }
    }
  }
}