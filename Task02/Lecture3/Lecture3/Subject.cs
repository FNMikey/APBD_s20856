namespace Lecture3;

public class Subject
{
    //Properties
    //Auto-property => Full propertu
    private string _name;
    
    public string Name
    {
        get => _name.ToLower();
        set
        {
            if (value == null)
            {
                throw new ArgumentException("Null value");
            }
            _name = value;
        }
    }
}