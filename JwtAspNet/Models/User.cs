namespace JwtAspNet;

public record User(int Id, string Name, string Email, string Password, string Image, string[] Roles);
