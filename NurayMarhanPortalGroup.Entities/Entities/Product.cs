using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Entities.Entities
{
    public class Product:BaseEntity
    {
        [Required(ErrorMessage = "Lütfen Ürün Adı Giriniz")]
        public string ProductName { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "Lütfen Fiyat Giriniz")]
        public decimal OldPrice { get; set; }


        [Required(ErrorMessage = "Lütfen Fiyat Giriniz")]
        public decimal Price { get; set; }


        //Navigation Property

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
