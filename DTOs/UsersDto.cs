namespace lms_auth_be.DTOs;
public record UsersDto(string Email, string FirstName, string LastName);
public record CreateUsersDtos(string Email, string FirstName, string LastName, string Password);

