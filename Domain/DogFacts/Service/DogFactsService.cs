using Domain.DogFacts.Entity;
using Domain.DogFacts.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DogFacts.Service
{
    public class DogFactsService : IDogFactsService
    {
        private readonly IDogFactsRepository _repository;
        public DogFactsService(IDogFactsRepository repository)
        {
            _repository = repository;
        }


        public async Task AddNewDogFactAsync(DogFactsEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public async Task UpdateDogFactAsync(DogFactsEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }

        public async Task<DogFactsEntity> GetDogFactByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IList<DogFactsEntity>> GetDogFactPagedAsync(string search, int start, int take)
        {
            return await _repository.GetPagedAsync(s => 
            string.IsNullOrEmpty(search) ? true : s.BodyAttribute.ToLower().Contains(search.ToLower()) || s.Type.ToLower().Contains(search.ToLower()),
            take,
            start,
            o => o.Type);
        }

        public async Task<int> GetDogFactCountAsync(string search)
        {
            return await _repository.GetCountAsync(s =>
            string.IsNullOrEmpty(search) ? true : s.BodyAttribute.ToLower().Contains(search.ToLower()) || s.Type.ToLower().Contains(search.ToLower()));
        }
    }
}
