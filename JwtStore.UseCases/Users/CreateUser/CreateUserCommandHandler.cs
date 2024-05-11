using JwtStore.Core.AccountContext;
using JwtStore.UseCases.Users.Contracts;

namespace JwtStore.UseCases.Users.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository)
    : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var email = new Email(request.Email);
        var password = new Password(request.Password);

        var user = new User(request.Name, email, password);

        await userRepository.AddAsync(user, cancellationToken);

        var response = new CreateUserResponse(user.Name);

        return response;
    }
}
