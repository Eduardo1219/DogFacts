using Domain.Base.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.DogFacts.Entity
{
    [Table("DogFacts")]
    public class DogFactsEntity : BaseEntity
    {
        public string Type { get; private set; } = string.Empty;
        public string BodyAttribute { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastChangeAt { get; private set; }

        public DogFactsEntity(Guid id, string type, string bodyAttribute, DateTime createdAt, DateTime? lastChangeAt = null)
        {
            Type = type;
            BodyAttribute = bodyAttribute;
            CreatedAt = createdAt;
            LastChangeAt = lastChangeAt;
            SetId(id);
        }

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
