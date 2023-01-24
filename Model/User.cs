using System;
using System.Collections.Generic;

namespace react_red.Model;

public partial class User
{
    public Guid UsersId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? Token { get; set; }

    public string? Bio { get; set; }

    public byte[]? Image { get; set; }

    public DateTime Registered { get; set; }

    public virtual ICollection<PostDownvote> PostDownvotes { get; } = new List<PostDownvote>();

    public virtual ICollection<PostUpvote> PostUpvotes { get; } = new List<PostUpvote>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();
}
