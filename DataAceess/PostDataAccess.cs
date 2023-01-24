using react_red.interfaces;
using react_red.Model;

namespace react_red.DataAccess
{
    public class PostDataAccess : IPost
    {
        private readonly BlogContext _;
        public PostDataAccess(BlogContext _)
        {
            this._=_;
        }

        public void AddPost(Post post)
        {
            try{
            _.Posts.Add(post);
            _.SaveChanges();
            }catch(Exception ex){
                Console.WriteLine(ex);
            }
        }

        public void Delete(Guid id)
        {
            Post? post = _.Posts.FirstOrDefault(p=>p.PostsId==id);
            if(post != null) _.Posts.Remove(post);
        }

        public IEnumerable<Post> GetPostByAuthor(Guid AuthorId)
        {
            IEnumerable<Post> _posts = _.Posts.Where(p=>p.AuthorId==AuthorId);
            if(_posts==null) return Enumerable.Empty<Post>().ToList();
            else return _posts;
        }

        public Post? GetPostById(Guid id)
        {
            return _.Posts.FirstOrDefault(p=>p.PostsId==id);
        }

        public IEnumerable<Post> GetPosts()
        {
            IEnumerable<Post> _posts = _.Posts.ToList();
            return _posts;
        }

        public void UpdatePost(Post post)
        {
            Post? _post = _.Posts.FirstOrDefault(p=>p.PostsId==post.PostsId);
            if(_post!=null) post=_post;
            _.Posts.Update(post);
            _.SaveChanges();
        }
    }
}