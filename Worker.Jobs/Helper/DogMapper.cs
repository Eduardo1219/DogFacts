using Domain.DogFacts.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Worker.Jobs.Dtos.DogFacts;

namespace Worker.Jobs.Helper
{
    public static class DogMapper
    {
        public static DogFactsEntity MapDog(this DogFactsGetDto dto)
        {
            var dogDto = dto.Data.FirstOrDefault();
            return new DogFactsEntity(dogDto.Id, dogDto.Type, dogDto.Attributes.Body, DateTime.UtcNow);
        }
    }
}
