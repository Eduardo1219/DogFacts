using System.ComponentModel.DataAnnotations;

namespace Domain.Base.Entity
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
