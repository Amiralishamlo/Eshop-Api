using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public EditCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _commentRepository.GetTracking(request.CommentId);
            if (comment == null || comment.UserId != request.UserId)
                return OperationResult.NotFound();
            comment.Edit(comment.Text);
            await _commentRepository.Save();
            return OperationResult.Success();
        }
    }
}
