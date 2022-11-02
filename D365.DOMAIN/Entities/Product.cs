using D365.MODEL.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365.DOMAIN.Entities
{
    public class Product : EFTBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public int area { get; set; }
        [Column("ModificationDateUTC", TypeName = "datetime")]
        public DateTime ModificationDateUTC { get; set; }

        public Product()
        {
            this.Id = Guid.NewGuid();
            this.CreationDateUTC = DateTime.Now.ToUniversalTime();
            this.ModificationDateUTC = DateTime.Now.ToUniversalTime();
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.amount = 0;
            this.price = 0;  
            this.area = 0;
        }

        public Product(Guid id, DateTime modificationdate)
        {
            this.Id = id;
            this.ModificationDateUTC = modificationdate;
        }
    }
}
