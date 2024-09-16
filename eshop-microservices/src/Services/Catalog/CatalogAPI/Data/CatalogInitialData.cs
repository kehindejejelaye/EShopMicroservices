using Marten.Schema;

namespace CatalogAPI.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if (await session.Query<Product>().AnyAsync())
                return;

            // Marten UPSERT will cater for existing records
            session.Store<Product>(GetPreConfiguredProducts());
            await session.SaveChangesAsync();
        }

        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Wireless Headphones",
                    Category = new List<string> { "Electronics", "Audio" },
                    Description = "High-quality wireless headphones with noise cancellation.",
                    ImageFile = "wireless_headphones.jpg",
                    Price = 99.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartphone",
                    Category = new List<string> { "Electronics", "Mobile Phones" },
                    Description = "Latest smartphone with cutting-edge features.",
                    ImageFile = "smartphone.jpg",
                    Price = 699.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Gaming Laptop",
                    Category = new List<string> { "Computers", "Gaming" },
                    Description = "Powerful gaming laptop with high-end graphics.",
                    ImageFile = "gaming_laptop.jpg",
                    Price = 1299.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Running Shoes",
                    Category = new List<string> { "Footwear", "Sports" },
                    Description = "Comfortable and durable running shoes for all terrains.",
                    ImageFile = "running_shoes.jpg",
                    Price = 59.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Smartwatch",
                    Category = new List<string> { "Wearables", "Fitness" },
                    Description = "Stylish smartwatch with fitness tracking capabilities.",
                    ImageFile = "smartwatch.jpg",
                    Price = 199.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Bluetooth Speaker",
                    Category = new List<string> { "Electronics", "Audio" },
                    Description = "Portable Bluetooth speaker with powerful sound.",
                    ImageFile = "bluetooth_speaker.jpg",
                    Price = 49.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Electric Kettle",
                    Category = new List<string> { "Home Appliances", "Kitchen" },
                    Description = "Fast-boiling electric kettle with automatic shut-off.",
                    ImageFile = "electric_kettle.jpg",
                    Price = 29.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Yoga Mat",
                    Category = new List<string> { "Fitness", "Accessories" },
                    Description = "Non-slip yoga mat for all types of exercises.",
                    ImageFile = "yoga_mat.jpg",
                    Price = 19.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Digital Camera",
                    Category = new List<string> { "Electronics", "Cameras" },
                    Description = "High-resolution digital camera with 4K video recording.",
                    ImageFile = "digital_camera.jpg",
                    Price = 499.99m
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Coffee Maker",
                    Category = new List<string> { "Home Appliances", "Kitchen" },
                    Description = "Automatic coffee maker with customizable brew strength.",
                    ImageFile = "coffee_maker.jpg",
                    Price = 89.99m
                }
            };
            return products;
        }
    }
}
