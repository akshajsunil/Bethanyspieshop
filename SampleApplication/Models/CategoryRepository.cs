namespace BethanysPieShop.Models
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly BethanysPieDbContext _bethanysPieDbContext;
        public CategoryRepository(BethanysPieDbContext bethanysPieDbContext)
        {
            _bethanysPieDbContext = bethanysPieDbContext;
        }

        public IEnumerable<Category> AllCategories => _bethanysPieDbContext.Categories.OrderBy(p => p.CategoryName);
    }
}
