using Common.Application;
using Shop.Domain.CommentAgg;

namespace Shop.Application.Comments.Create
{
    public class CreateCommentCommandHandler : IBaseCommandHandler<CreateCommentCommand>
    {
        private readonly ICommentRepository _commentRepository;

        public CreateCommentCommandHandler(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task<OperationResult> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new Comment(request.UserId, request.ProductId, request.Text);
            await _commentRepository.Add(comment);
            await _commentRepository.Save();
            return OperationResult.Success();
        }
    }
}
