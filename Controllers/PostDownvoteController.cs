using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using react_red.interfaces;
using react_red.Model;

namespace react_red.Controllers;
    
[Route("post/Downvote/")]
[ApiController]
public class PostDownvoteController : ControllerBase{
    private readonly IPostDownvote _postDownvoteController;
    PostDownvoteController(IPostDownvote _postDownvoteController){
        this._postDownvoteController = _postDownvoteController;
    }

    [HttpGet("{id}")]
    public IActionResult GetDownvote([FromBody]PostDownvote postDownvote){
        try
        {
            return Ok(_postDownvoteController.GetDownvoteCount(postDownvote));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut("{id}")]
    public IActionResult Downvote([FromBody]PostDownvote postDownvote)
    {
        try
        {
            _postDownvoteController.AddDownvote(postDownvote);
            return Ok();
        }catch(Exception ex) { 
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/remove")]
    public IActionResult RemoveDownvote([FromBody]PostDownvote postDownvote)
    {
        try
        {
            _postDownvoteController.DeleteDownvote(postDownvote);
            return Ok();
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
