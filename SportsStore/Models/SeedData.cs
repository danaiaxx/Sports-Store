using Microsoft.EntityFrameworkCore;
namespace SportsStore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDBContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<StoreDBContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Kayak", Description = "A boat for one person.", Category = "Watersports", Price = 499.95m },
                    new Product { Name = "Lifejacket", Description = "Protective and fashionable.", Category = "Watersports", Price = 249.95m },
                    new Product { Name = "Soccer Ball", Description = "FIFA-Approved size and weight", Category = "Soccer", Price = 399.95m },
                    new Product { Name = "Corner Flags", Description = "Give your playing field a professional touch", Category = "Soccer", Price = 999.95m },
                    new Product { Name = "Stadium", Description = "Flat-packed 35,000-seat stadium", Category = "Soccer", Price = 99499.95m },
                    new Product { Name = "Thinking Cap", Description = "Improve your brain efficiency by 75%", Category = "Chess", Price = 699.95m },
                    new Product { Name = "Unsteady Chair", Description = "Secretly giving your opponent a disadvantage", Category = "Chess", Price = 399.95m },
                    new Product { Name = "Chess board", Description = "A fun game to the family", Category = "Chess", Price = 299.95m },
                    new Product { Name = "Bling-bling King", Description = "Gold-plated sturdy King", Category = "Chess", Price = 199.95m }
                );
            }

            AddProductIfMissing(context, "Basketball", "Official NBA game ball", "Basketball", 499.95m);
            AddProductIfMissing(context, "Basketball Hoop", "Adjustable outdoor hoop", "Basketball", 1999.95m);
            AddProductIfMissing(context, "Mini Hoop", "Door-mounted mini basketball hoop", "Basketball", 299.95m);
            AddProductIfMissing(context, "Basketball Shoes", "High-grip basketball sneakers", "Basketball", 799.95m);
            AddProductIfMissing(context, "Basketball Net", "Durable chain net", "Basketball", 149.95m);
            AddProductIfMissing(context, "Basketball Backpack", "Fits ball, shoes, and gear", "Basketball", 399.95m);
            AddProductIfMissing(context, "Tennis Racket", "Lightweight graphite racket", "Tennis", 899.95m);
            AddProductIfMissing(context, "Tennis Balls (Pack of 3)", "Standard pressurized tennis balls", "Tennis", 199.95m);
            AddProductIfMissing(context, "Yoga Mat", "Non-slip and eco-friendly", "Fitness", 299.95m);
            AddProductIfMissing(context, "Dumbbell Set", "Adjustable weight dumbbells", "Fitness", 999.95m);
            AddProductIfMissing(context, "Jump Rope", "Adjustable speed rope", "Fitness", 149.95m);
            AddProductIfMissing(context, "Pull-Up Bar", "Doorway-mounted pull-up bar", "Fitness", 399.95m);
            AddProductIfMissing(context, "Ab Roller", "Strengthen your core", "Fitness", 299.95m);
            AddProductIfMissing(context, "Treadmill Mat", "Protects your floor and reduces noise", "Fitness", 349.95m);
            AddProductIfMissing(context, "Workout Gloves", "Grip-enhancing gloves", "Fitness", 129.95m);
            AddProductIfMissing(context, "Skateboard", "Pro-level street skateboard", "Skateboarding", 899.95m);
            AddProductIfMissing(context, "Helmet", "Safety helmet for skating or biking", "Protective Gear", 349.95m);
            AddProductIfMissing(context, "Boxing Gloves", "12 oz sparring gloves", "Boxing", 699.95m);
            AddProductIfMissing(context, "Punching Bag", "Heavy-duty hanging bag", "Boxing", 1499.95m);
            AddProductIfMissing(context, "Soccer Ball Bag", "Holds up to 10 balls", "Soccer", 399.95m);
            AddProductIfMissing(context, "Training Hurdles", "Set of 6 agility hurdles", "Soccer", 499.95m);
            AddProductIfMissing(context, "Soccer Cleats", "Lightweight boots for firm ground", "Soccer", 799.95m);
            AddProductIfMissing(context, "Goalkeeper Gloves", "High-grip gloves", "Soccer", 599.95m);
            AddProductIfMissing(context, "Cones Set", "Set of 20 training cones", "Soccer", 149.95m);
            AddProductIfMissing(context, "Whistle & Stopwatch", "Referee essentials", "Soccer", 99.95m);

            context.SaveChanges();
        }

        private static void AddProductIfMissing(StoreDBContext context, string name, string desc, string category, decimal price)
        {
            if (!context.Products.Any(p => p.Name == name))
            {
                context.Products.Add(new Product
                {
                    Name = name,
                    Description = desc,
                    Category = category,
                    Price = price
                });
            }
        }
    }
}