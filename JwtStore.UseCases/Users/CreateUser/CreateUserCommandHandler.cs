using JwtStore.Core.AccountContext;
using JwtStore.UseCases.Users.Contracts;

namespace JwtStore.UseCases.Users.CreateUser;

public class CreateUserCommandHandler(IUserRepository userRepository)
    : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    public Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
