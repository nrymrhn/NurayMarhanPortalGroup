using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Entities.Entities
{
    public class Category:BaseEntity
    {
        [Required(ErrorMessage = "Lütfen Kategori Adı Giriniz")]
        public string CategoryName { get; set; }

        //Navigation Property
        public List<Product> Products { get; set; }

    }
}
