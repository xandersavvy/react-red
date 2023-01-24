
using react_red.interfaces;
using react_red.Model;

namespace react_red.DataAccess{
    public class PostDownvoteDataAccess: IPostDownvote
{
    private readonly BlogContext _;
    public PostDownvoteDataAccess(BlogContext _)
    {
        this._=_;
    }

        public void AddDownvote(PostDownvote _postReaction)
        {
            _.PostDownvotes.Add(_postReaction);
        }

        public void DeleteDownvote(PostDownvote _postReaction)
        {
            _.PostDownvotes.Remove(_postReaction);

        }

        public int GetDownvoteCount(PostDownvote _postReaction)
        {
            return _.PostDownvotes.Where(p=>p.PostId==_postReaction.PostId).Count();
        }
    }
}