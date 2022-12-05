using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurayMarhanPortalGroup.Entities.Entities
{
    public class BaseEntity
    {
        public int ID { get; set; }

        public bool Status { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        public DateTime CreationDate { get; set; }
    }
}
