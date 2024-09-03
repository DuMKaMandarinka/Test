using ClassLibrary1;
using System;
using System.Reflection.Metadata;

public class InfoPerson 
{
	public int Id { get; set; } 

	public string Name { get; set; }

	public int Age { get; set; }

	public string Gender { get; set; }

    public ICollection<Balance> Balances { get; } = new List<Balance>();
}
