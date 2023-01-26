using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using react_red.interfaces;
using react_red.Model;

namespace react_red.Controllers;
    
[Route("post/Upvote/")]
[ApiController]
public class PostUpvoteController : ControllerBase{
    private readonly IPostUpvote _postUpvoteController;
    PostUpvoteController(IPostUpvote _postUpvoteController){
        this._postUpvoteController = _postUpvoteController;
    }

    [HttpGet("{id}")]
    public IActionResult GetUpvote([FromBody]PostUpvote postUpvote){
        try
        {
            return Ok(_postUpvoteController.GetUpvoteCount(postUpvote));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        
    }

    [HttpPut("{id}")]
    public IActionResult Upvote([FromBody]PostUpvote postUpvote)
    {
        try
        {
            _postUpvoteController.AddUpvote(postUpvote);
            return Ok();
        }catch(Exception ex) { 
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}/remove")]
    public IActionResult RemoveUpvote([FromBody]PostUpvote postUpvote)
    {
        try
        {
            _postUpvoteController.DeleteUpvote(postUpvote);
            return Ok();
        }catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
