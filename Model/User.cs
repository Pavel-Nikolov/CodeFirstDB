using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(75)]
        [Index]
        public string Name { get; set; }
        public int? Age { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}