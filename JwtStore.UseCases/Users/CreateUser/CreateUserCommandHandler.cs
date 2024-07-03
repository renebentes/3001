using JwtStore.Core.AccountContext;
using JwtStore.Core.SharedContext.Primitives;
using JwtStore.UseCases.Users.Contracts;

namespace JwtStore.UseCases.Users.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository)
    : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = CreateUserCommandValidator.Ensure(request);

        if (!validator.IsValid)
        {
            return validator.ToResult<CreateUserResponse>();
        }

        var email = new Email(request.Email);
        var password = new Password(request.Password);

        var isEmailUnique = await userRepository.IsEmailUniqueAsync(email, cancellationToken);

        if (!isEmailUnique)
        {
            return Result.Conflict<CreateUserResponse>(new Error("User.DuplicateEmail", $"The specified email is already in use"));
        }

        var user = new User(request.Name, email, password);

        await userRepository.AddAsync(user, cancellationToken);

        var response = new CreateUserResponse(user.Name);

        return response;
    }
}
