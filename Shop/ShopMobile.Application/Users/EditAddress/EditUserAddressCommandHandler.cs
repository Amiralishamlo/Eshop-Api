using Common.Application;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Repository;

namespace Shop.Application.Users.EditAddress;

public class EditUserAddressCommandHandler:IBaseCommandHandler<EditUserAddressCommand>
{
    private readonly IUserRepository _userRepository;

    public EditUserAddressCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(EditUserAddressCommand request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetTracking(request.UserId);
        if (users == null)
            return OperationResult.NotFound();

        var address = new UserAddress(request.Shire, request.City, request.PostalCode, request.PostalAddress,
            request.PhoneNumber, request.Name, request.Family, request.NationalCode);
        users.EditAddress(address, request.Id);
        await _userRepository.Save();
        return OperationResult.Success();
    }
}