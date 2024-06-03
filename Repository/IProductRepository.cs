using earrings.Data;
using earrings.Models;
using Microsoft.EntityFrameworkCore;

namespace earrings.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Earrings>> GetEarrings();
        Task<Earrings> GetEarrings(Guid id);
        Task<Earrings> AddEarrings(Earrings earrings);
        Task<Earrings> UpdateEarrings(Earrings earrings);
        Task<Earrings> DeleteEarrings(Guid id);

    }

    public class ProductRepository : IProductRepository
    {
        private readonly EarringsDbContext _context;

        public ProductRepository(EarringsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Earrings>> GetEarrings()
        {
            return await _context.Earrings.ToListAsync();
        }

        public async Task<Earrings> GetEarrings(Guid id)
        {
            return await _context.Earrings.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Earrings> AddEarrings(Earrings earrings)
        {
            _context.Earrings.Add(earrings);
            await _context.SaveChangesAsync();
            return earrings;
        }

        public async Task<Earrings> UpdateEarrings(Earrings earrings)
        {
            _context.Entry(earrings).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return earrings;
        }

        public async Task<Earrings> DeleteEarrings(Guid id)
        {
            var earrings = await _context.Earrings.FirstOrDefaultAsync(e => e.Id == id);
            if (earrings != null)
            {
                _context.Earrings.Remove(earrings);
                await _context.SaveChangesAsync();
            }
            return earrings;
        }
    }
}
