namespace lms_auth_be.DTOs;

public record LoginAuthDtos(string Email, string Password);

public record RegisterAuthDtos(string Email, string FirstName, string LastName, string Password);
