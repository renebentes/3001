namespace JwtAspNet;

public record User(int Id, string Email, string Password, string[] Roles);
