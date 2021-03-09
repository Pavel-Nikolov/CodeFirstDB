using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Brand
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(40)]
        [Index]
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
