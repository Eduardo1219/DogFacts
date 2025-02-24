using Domain.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DogFacts.Entity
{
    public class DogFactsEntity : BaseEntity
    {
        public string Type { get; private set; } = string.Empty;
        public string BodyAttribute { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastChangeAt { get; private set; }


        public void ChangeType(string type)
        {
            this.Type = type;
            LastChangeAt = DateTime.UtcNow;
        }

        public void ChangeBodyAttribute(string bodyAttribute)
        {
            this.BodyAttribute = bodyAttribute;
            LastChangeAt = DateTime.UtcNow;
        }
    }
}
