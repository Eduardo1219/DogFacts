using Domain.Base.Repository;
using Domain.DogFacts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DogFacts.Repository
{
    public interface IDogFactsRepository : IBaseRepository<DogFactsEntity>
    {
    }
}
