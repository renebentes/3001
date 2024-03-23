namespace JwtStore.UseCases.Users.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        => throw new NotImplementedException();
}
