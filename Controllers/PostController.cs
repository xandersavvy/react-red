using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using react_red.interfaces;
using react_red.Model;

namespace react_red.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPost _postDataAccess;
        private readonly IUser _userDataAccess;
        public PostController(IPost _postDataAccess,IUser _userDataAccess)
        {
            this._postDataAccess = _postDataAccess;
            this._userDataAccess = _userDataAccess;
        }

        [HttpGet("/posts")]
        public IActionResult GetPosts()
        {
            try
            {
                var posts = _postDataAccess.GetPosts();
                return (posts!=null)?Ok(posts):NoContent();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/post/id/{id}")]
        public IActionResult GetPostById(Guid id)
        {
            try
            {
                var post = _postDataAccess.GetPostById(id);
                return (post!=null)?Ok(post):NotFound();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("/post/{slug}")]
        public IActionResult GetPostBySlug(string slug)
        {
            try
            {
                var post = _postDataAccess.GetPostBySlug(slug);
                return (post!=null)?Ok(post):NotFound();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/{id}/posts")]
        public IActionResult GetPostsByAuthor(Guid id)
        {
            try
            {
                var posts = _postDataAccess.GetPostByAuthor(id);
                return (posts==null)?Ok(posts):NoContent();
            }catch(Exception ex)
            {
                return BadRequest($"{ex.Message}");
            }
        }

        [HttpPost("/post")]
        public IActionResult AddPost([FromBody]Post post)
        {
            try
            {
                _postDataAccess.AddPost(post);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/{AuhorId}/post/{id}")]
        public IActionResult UpdatePost([FromBody]Post post, [FromRoute]Guid AuthorId)
        {
            try
            {
                var user = _userDataAccess.GetUser(AuthorId);
                if (user == null) return Forbid();
                else if (user.Role == "admin" || user.UsersId == post.AuthorId)
                {
                    _postDataAccess.UpdatePost(post);
                    return Ok();
                }
                else return Forbid();

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("/{AuthorId}/post/{id}")]
        public IActionResult Delete(Guid AuthorId,Guid id)
        {
            try
            {
                var user = _userDataAccess.GetUser(AuthorId);
                var post = _postDataAccess.GetPostById(id);
                if(user==null || post==null) return Forbid();
                else if (user.Role == "admin" || user.UsersId == post.AuthorId)
                {
                    _postDataAccess.Delete(id);
                    return Ok();
                }
                else return Forbid();
                
            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
