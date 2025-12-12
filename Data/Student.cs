namespace lms_auth_be.Data;

public class Student
{
    public int Id { get; set; }

    public DateTime DateTimeCreated { get; set; }

    public User? User { get; set; }
}
