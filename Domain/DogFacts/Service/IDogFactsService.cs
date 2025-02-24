using Domain.DogFacts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DogFacts.Service
{
    public interface IDogFactsService
    {
        Task AddNewDogFactAsync(DogFactsEntity entity);
        Task UpdateDogFactAsync(DogFactsEntity entity);
        Task<DogFactsEntity> GetDogFactByIdAsync(Guid id);
        Task<IList<DogFactsEntity>> GetDogFactPagedAsync(string search, int start, int take);
        Task<int> GetDogFactCountAsync(string search);
    }
}
