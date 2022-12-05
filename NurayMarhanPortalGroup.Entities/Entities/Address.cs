using NurayMarhanPortalGroup.Entities.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Entities.Entities
{
    public class Address:BaseEntity
    {

        [Required(ErrorMessage = "Lütfen Adres Satırı Giriniz")]       
        public string AddressLine { get; set; }

        [Required(ErrorMessage = "Lütfen Ülke Adı Giriniz")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir Adı Giriniz")]
        public string City { get; set; }

    
        public string District { get; set; }


        [Required(ErrorMessage = "Lütfen Posta Kodu Giriniz")]
        public int ZipCode { get; set; }

        //Navigation Property       
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }       
        public List<Order> Orders { get; set; }
    }
}
