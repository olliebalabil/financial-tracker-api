namespace TrackerApi.Models;

public class Account
{
  public int Id {get;set;}
  public string? Account_Name { get; set; }
  public decimal Initial_balance { get; set; }
  public decimal Current_balance { get; set; }
  public string? Currency { get; set; }
}