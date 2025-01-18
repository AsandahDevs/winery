using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WineStore.Data;
using WineStore.Models;

namespace WineStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly WineStoreContext _context;

        public ProductsController(WineStoreContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<List<ProductsDto>?>> GetProducts()
        {
           var products = await _context.Products.Select(product=> new ProductsDto{
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Discount = product.Discount,
                StockAvailability = product.StockAvailability,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Categories.CategoryName
            }).ToListAsync();

            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProduct(int id)
        {
            var product = await _context.Products.Where(product=>product.Id == id).Select(product=> new ProductsDto{
                Id = product.Id,
                ProductName = product.ProductName,
                Price = product.Price,
                Discount = product.Discount,
                StockAvailability = product.StockAvailability,
                ImageUrl = product.ImageUrl,
                CategoryName = product.Categories.CategoryName
            }).ToListAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Products product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts([FromBody] ProductsDto products)
        {
           var category = await _context.Categories.FirstOrDefaultAsync(cat=> cat.CategoryName == products.CategoryName);

           if(category is null){
            category = new Categories { CategoryName = products.CategoryName};
           _context.Categories.Add(category);
           }

           var product = new Products{
                ProductName = products.ProductName,
                Price = products.Price,
                StockAvailability = products.StockAvailability,
                ImageUrl = products.ImageUrl,
                Categories = category
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducts(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
