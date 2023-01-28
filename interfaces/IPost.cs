using react_red.Model;

namespace react_red.interfaces{

public interface IPost{
    void AddPost(Post post);
    
    IEnumerable<Post> GetPosts();
    
    IEnumerable<Post> GetPostByAuthor(Guid AuthorId);

    Post? GetPostById(Guid id);
    Post? GetPostBySlug(string slug);

    void UpdatePost(Post post);
    void Delete(Guid id);
    

}
}