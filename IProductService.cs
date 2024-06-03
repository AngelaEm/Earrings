using earrings.Data;
using earrings.Models;
using earrings.Repository;
using Microsoft.EntityFrameworkCore;

namespace earrings
{
    public interface IProductService
    {
        Task<IEnumerable<Earrings>> GetEarrings();
        Task<Earrings> GetEarrings(Guid id);
        Task<Earrings> AddEarrings(Earrings earrings);
        Task<Earrings> UpdateEarrings(Earrings earrings);
        Task<Earrings> DeleteEarrings(Guid id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Earrings>> GetEarrings()
        {
            return await _repository.GetEarrings();
        }

        public async Task<Earrings> GetEarrings(Guid id)
        {
            var earrings = await _repository.GetEarrings(id);
            
            return earrings;
        }

        public async Task<Earrings> AddEarrings(Earrings earrings)
        {
           
            await _repository.AddEarrings(earrings);
            return earrings;
        }

        public async Task<Earrings> UpdateEarrings(Earrings earrings)
        {
            
            await _repository.UpdateEarrings(earrings);
            return earrings;
        }

        public async Task<Earrings> DeleteEarrings(Guid id)
        {
            var earrings = await _repository.GetEarrings(id);
            if (earrings != null)
            {
                await _repository.DeleteEarrings(id);
            }
            return earrings;
        }
    }
}
