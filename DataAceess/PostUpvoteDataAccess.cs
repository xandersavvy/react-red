

using react_red.interfaces;
using react_red.Model;

namespace react_red.DataAccess{
    public class PostUpvoteDataAccess: IPostUpvote
{
    private readonly BlogContext _;
    public PostUpvoteDataAccess(BlogContext _)
    {
        this._=_;
    }

        public void AddUpvote(PostUpvote _postReaction)
        {
            _.PostUpvotes.Add(_postReaction);
        }

        public void DeleteUpvote(PostUpvote _postReaction)
        {
            _.PostUpvotes.Remove(_postReaction);

        }

        public int GetUpvoteCount(PostUpvote _postReaction)
        {
            return _.PostUpvotes.Where(p=>p.PostId==_postReaction.PostId).Count();
        }
    }
}