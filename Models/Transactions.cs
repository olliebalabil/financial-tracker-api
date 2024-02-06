namespace TrackerApi.Models;

public class Transaction
{
  public int Id {get;set;}
  public string? Reference {get;set;}
  public int account_id { get; set; }
  public DateTime Date { get; set; }
  public string? Category { get; set; }
  public decimal Amount { get; set; }
}