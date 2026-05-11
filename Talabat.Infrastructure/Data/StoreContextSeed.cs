using System.Text.Json;
using Talabat.Core.Entities;

namespace Talabat.Infrastructure.Data
{
    public static class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (context.Brands.Count()==0)
            {
                
                var brandsData = File.ReadAllText("../Talabat.Infrastructure/Data/DataSeeding/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                if (brands is not null)
                {
                    foreach (var brand in brands)
                    {
                        context.Brands.Add(brand);
                    }
                    await context.SaveChangesAsync(); 
                }
            }


            if (context.Categories.Count()==0)
            {
                var categoriesData = File.ReadAllText("../Talabat.Infrastructure/Data/DataSeeding/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesData);
                if (categories is not null)
                {
                    foreach (var category in categories)
                    {
                        context.Categories.Add(category);
                    }
                    await context.SaveChangesAsync();
                }
            }
            if (context.Products.Count()==0)
            {
                var productsData = File.ReadAllText("../Talabat.Infrastructure/Data/DataSeeding/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                if (products is not null)
                {
                    foreach (var product in products)
                    {
                        context.Products.Add(product);
                    }
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
