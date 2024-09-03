using System;

public class Money
{
	public string Currently { get;}

	public decimal Amount { get; set; }

	public Money(string currently, decimal amount)
	{
		Currently = currently;
		Amount = amount;
	}
}
