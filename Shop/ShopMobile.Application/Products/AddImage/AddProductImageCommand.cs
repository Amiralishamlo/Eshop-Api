using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.ProductAgg;
using Shop.Domain.ProductAgg.Repository;

namespace Shop.Application.Products.AddImage
{
    public class AddProductImageCommand:IBaseCommand
    {
        public AddProductImageCommand(IFormFile imageFile, long productId, int sequence)
        {
            ImageFile = imageFile;
            ProductId = productId;
            Sequence = sequence;
        }

        public IFormFile ImageFile { get; private set; }
        public long ProductId { get; private set; }
        public int Sequence { get; private set; }
    }
    public class AddProductImageCommandHandler : IBaseCommandHandler<AddProductImageCommand>
    {
        private readonly IProductRepository _repository;
        private readonly ILocalFileService _fileService;

        public AddProductImageCommandHandler(IProductRepository repository, ILocalFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(AddProductImageCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetTracking(request.ProductId);
            if (product == null)
                return OperationResult.NotFound();

            var imageName = await _fileService
                .SaveFileAndGenerateName(request.ImageFile, Directories.ProductGalleryImage);

            var productImage = new ProductImage(imageName, request.Sequence);
            product.AddImage(productImage);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
    public class AddProductImageCommandValidator:AbstractValidator<AddProductImageCommand>
    {
        public AddProductImageCommandValidator()
        {
            RuleFor(b => b.ImageFile)
                .NotNull().WithMessage(ValidationMessages.required("عکس"))
                .JustImageFile();

            RuleFor(b => b.Sequence)
                .GreaterThanOrEqualTo(0);
        }
    }
}
