using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Product
    {
        [Key]
        public string Barcode { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(100)]
        [Index]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        [Required]
        public Brand Brand { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
