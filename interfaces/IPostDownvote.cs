using react_red.Model;

namespace react_red.interfaces{
    public interface IPostDownvote{
        int GetDownvoteCount(PostDownvote _postReaction);
        void AddDownvote(PostDownvote _postReaction);

        void DeleteDownvote(PostDownvote _postReaction);
    }
}