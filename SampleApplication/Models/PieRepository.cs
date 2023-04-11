using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class PieRepository: IPieRepository
    {
        private readonly BethanysPieDbContext _bethanysPieDbContext;
        
        public PieRepository(BethanysPieDbContext bethanysPieDbContext)
        {
            _bethanysPieDbContext = bethanysPieDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get { return _bethanysPieDbContext.Pies.Include(c => c.Category); }

        }

        public IEnumerable<Pie> PiesOfTheWeek =>  _bethanysPieDbContext.Pies.Include(c => c.Category).Where(p=>p.IsPieOfTheWeek);

        public Pie? GetPieById(int pieId)
        {
            return _bethanysPieDbContext.Pies.FirstOrDefault(p=>p.PieId==pieId);
        }

        public IEnumerable<Pie> searchPies(string searchQuery)
        {
            return _bethanysPieDbContext.Pies.Where(p=>p.Name.Contains(searchQuery));
        }
    }
}
