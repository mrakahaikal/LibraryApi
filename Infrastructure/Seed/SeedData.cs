namespace Infrastructure.Seed
{
    using Domain.Entities;
    using Infrastructure.Persistence;

    public static class SeedData
    {
        public static void Initialize(LibraryDbContext context)
        {
            if (context.Books.Any())
                return; // Seeder sudah dijalankan sebelumnya

            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Novel"
            };

            var author = new Author
            {
                Id = Guid.NewGuid(),
                Name = "Tere Liye",
                Bio = "Penulis populer asal Indonesia."
            };

            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Hujan",
                AuthorId = author.Id,
                CategoryId = category.Id,
                Publisher = "Gramedia",
                Stock = 5,
                IsReferenceOnly = false
            };

            context.Categories.Add(category);
            context.Authors.Add(author);
            context.Books.Add(book);

            context.SaveChanges(); 
        }
    }
}