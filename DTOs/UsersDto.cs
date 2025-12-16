namespace lms_auth_be.DTOs;
public record UsersDtos(string Email, string FirstName, string LastName);
public record CreateUsersDtos(string Email, string FirstName, string LastName, string Password);
public record UpdateUsersDtos(string Email, string FirstName, string LastName, string Password);

