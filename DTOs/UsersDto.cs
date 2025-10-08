namespace lms_auth_be.DTOs;
public record UsersDtos(string UserName, string FirstName, string LastName);
public record CreateUsersDtos(string UserName, string FirstName, string LastName, string Password);
public record UpdateUsersDtos(string UserName, string FirstName, string LastName, string Password);

