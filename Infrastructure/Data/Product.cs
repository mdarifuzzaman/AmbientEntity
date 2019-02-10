using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    [Table("Product")]
    public class Product: IProduct
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string ProductId { get; set; }

        [StringLength(150)]
        public string ProductName { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        
        [StringLength(300)]
        public string Description { get; set; }
    }
}
