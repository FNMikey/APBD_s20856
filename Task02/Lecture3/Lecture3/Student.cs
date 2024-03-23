namespace Lecture3;

public class Student
{
    public string firstName;
    public string lastName;

    public Student(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    public void DisplayInfo()
    {
        Console.WriteLine(firstName+" "+lastName);
    }

    public override bool Equals(object? obj)
    {
        Student s2 = (Student)obj;
        return lastName == s2.lastName;
    }
}

public class PhdStudent : Student
{
    public string specialty;
    
    public PhdStudent(string firstName, string lastName, string specialty)
        :base(firstName, lastName)
    {
        this.specialty = specialty;
    }
}