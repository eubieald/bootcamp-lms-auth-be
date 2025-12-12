namespace lms_auth_be.Data;

public class Teacher
{
    public int Id { get; set; }

    public DateTime DateTimeCreated { get; set; }

    public User? User { get; set; }
}
