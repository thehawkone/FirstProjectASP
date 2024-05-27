namespace FirstProjectASP.Models;

public class User
{
    public int Age { get; set; }
    public string Name { get; set; }

    public User(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public User()
    {
        throw new NotImplementedException();
    }
}