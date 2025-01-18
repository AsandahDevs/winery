namespace WineStore.Models;

public class Categories {
    public int Id {get;set;}
    public required string CategoryName {get;set;}
    public required ICollection<Products> Products {get;set;}
}