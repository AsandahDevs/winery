using System.ComponentModel.DataAnnotations.Schema;

namespace WineStore.Models;

public class Products {
    public int Id {get;set;}
    public required string ProductName {get;set;}
    public required double Price {get;set;}
    public double? Discount {get;set;}
    public required bool StockAvailability {get;set;}
    public required string ImageUrl {get;set;}
    [ForeignKey("CategoryId")]
    public required Categories Categories {get;set;}
    public int CategoryId {get;set;}
}

public class ProductsDto {
    public int Id {get;set;}
    public required string ProductName {get;set;}
    public required double Price {get;set;}
    public double? Discount {get;set;}
    public required bool StockAvailability {get;set;}
    public required string ImageUrl {get;set;}
    public required string  CategoryName {get;set;}
}

