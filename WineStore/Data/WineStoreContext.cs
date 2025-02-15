using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WineStore.Models;

namespace WineStore.Data;
public class WineStoreContext:IdentityDbContext<IdentityUser>
 {
    public WineStoreContext(DbContextOptions<WineStoreContext> options):base(options)
    {
    }

    public DbSet<Products> Products {get;set;} = null!;
    public DbSet<Categories> Categories {get;set;} = null!;
    public DbSet<Cart> Cart {get;set;} = null!;
}