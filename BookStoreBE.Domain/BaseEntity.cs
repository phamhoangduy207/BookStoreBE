using System.ComponentModel.DataAnnotations;

namespace BookStoreBE.Domain
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
