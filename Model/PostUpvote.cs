using System;
using System.Collections.Generic;

namespace react_red.Model;

public partial class PostUpvote
{
    public int Id { get; set; }

    public Guid PostId { get; set; }

    public Guid UserId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
