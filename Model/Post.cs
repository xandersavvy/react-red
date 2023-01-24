using System;
using System.Collections.Generic;

namespace react_red.Model;

public partial class Post
{
    public Guid PostsId { get; set; }

    public string Header { get; set; } = null!;

    public string Slug { get; set; } = null!;

    public string Content { get; set; } = null!;

    public DateTime Published { get; set; }

    public Guid AuthorId { get; set; }

    public virtual User Author { get; set; } = null!;

    public virtual ICollection<PostDownvote> PostDownvotes { get; } = new List<PostDownvote>();

    public virtual ICollection<PostUpvote> PostUpvotes { get; } = new List<PostUpvote>();
}
