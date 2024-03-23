
using JwtStore.Core.AccountContext;
using JwtStore.UseCases.Extensions;

namespace JwtStore.UseCases.Users.CreateUser;

public sealed class CreateUserCommandHandler(IUserRepository userRepository, IEmailService emailService)
    : ICommandHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IEmailService _emailService = emailService;

    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var validationResult = CreateUserCommandValidation.Ensure(command);

        if (!validationResult.IsValid)
        {
            return Result.Failure<CreateUserResponse>(validationResult.AsErrors());
        }

        var email = new Email(command.Email);
        var emailInUse = await _userRepository.IsEmailUniqueAsync(email, cancellationToken);

        if (emailInUse)
        {
            return Result.Failure<CreateUserResponse>(new Error("User.DuplicateEmail", "O e-mail especificado já está em uso."));
        }

        var user = new CreateUserResponse(Guid.Empty, string.Empty);

        return user;
    }
}
