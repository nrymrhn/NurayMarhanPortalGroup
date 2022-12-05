using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Entities.Entities
{
    public class Customer:BaseEntity
    {
        [Required(ErrorMessage = "Lütfen İsim Giriniz")]
        [RegularExpression(@"^[a-zA-Z\sşİıÜüÖöĞğÇçŞ]*$", ErrorMessage = "Sadece Harf Girişi Yapınız")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Lütfen Soyisim Giriniz")]
        [RegularExpression(@"^[a-zA-Z\sşİıÜüÖöĞğÇçŞ]*$", ErrorMessage = "Sadece Harf Girişi Yapınız")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Mail adresi boş bırakılamaz")]
        [MaxLength(50)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Mail Formatını Doğru Giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "TC Kimlik No Boş Bırakılamaz.")]
        public long TCID { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Required(ErrorMessage = "LütfenDoğum Tarihini Giriniz")]
        public DateTime BirthDate { get; set; }
        public string Gsm { get; set; }

        //Navigation Property
        public List<Order> Orders { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
