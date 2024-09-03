
using System;
using System.Text;

public class Person 
{
	public string Name { get; }

	public int Age { get; }

    public string Gender { get; }

    public List<Money> Moneys { get; set; }

    public Person(string name, int age, string gender, List<Money> moneys)
    {
        Name = name;
        Age = age;
        Gender = gender;
        Moneys = moneys;
    }

    public string GetInformation()
    {
        var information = new StringBuilder($"{Name} Возраст: {Age} Пол:{Gender}\n" +
            $"Имеет:\n");

        foreach( var money in Moneys )
        {
            information.Append($"{money.Currently} : {money.Amount}");
            information.AppendLine();
        }

        return information.ToString();
    }
}
