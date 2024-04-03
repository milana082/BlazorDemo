using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudOperations.Models
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public int IsActive { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
