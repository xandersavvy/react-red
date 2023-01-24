using react_red.Model;

namespace react_red.interfaces{
    public interface IPostUpvote{
        int GetUpvoteCount(PostUpvote _postReaction);
        void AddUpvote(PostUpvote _postReaction);

        void DeleteUpvote(PostUpvote _postReaction);
    }
}