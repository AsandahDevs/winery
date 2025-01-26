namespace WineStore.Models;

public class Cart {
    public int Id {get;set;}
    public required string Item {get;set;}
    public required int Quantity {get;set;}
}