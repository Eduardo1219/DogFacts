using Domain.DogFacts.Entity;
using Domain.DogFacts.Repository;
using Infraestructure.Context;
using Infraestructure.Repository.Base;

namespace Infraestructure.Repository.DogFacts
{
    public class DogFactsRepository : BaseRepository<DogFactsEntity>, IDogFactsRepository
    {
        private readonly DogFactsContext _context;

        public DogFactsRepository(DogFactsContext context) : base(context)
        {
            _context = context;
        }
    }
}
