using Common.Query;
using Shop.Domain.CommentAgg;

namespace Shop.Query.Comments.DTOs;
public class CommentDto : BaseDto
{
    public long ProductId { get; set; }
    public long UserId { get; set; }
    public string UserFullName { get; set; }

    public string ProductTitle { get; set; }
    public string Text { get; set; }
    public CommentStatus Status { get; set; }
}