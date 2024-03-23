namespace Lecture3;

public interface ITeacher
{
    void CheckGrade(string subject);
}

public class Professor : ITeacher
{
    public void CheckGrade(string subject)
    {
        
    }
}