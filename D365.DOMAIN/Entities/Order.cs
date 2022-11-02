using D365.MODEL.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D365.DOMAIN.Enum;

namespace D365.DOMAIN.Entities
{
    public class Order : EFTBase<Guid>
    {
        public Guid? AccountId { get; set; }
        public List<Product> Products { get; set; }
        public int State { get; set; }
        [Required]
        [Column("ModificationDateUTC", TypeName = "datetime")]
        public DateTime ModificationDateUTC { get; set; }

        Order()
        {
            this.Id = Guid.NewGuid();
            this.CreationDateUTC = DateTime.Now.ToUniversalTime();
            this.ModificationDateUTC = DateTime.Now.ToUniversalTime();
            this.State = (int)ProductListState.Ingresado;
            Products = new List<Product>();
            AccountId = null;
        }
        public Order(Guid id, DateTime modificationdate, int state)
        {
            this.Id = id;
            this.ModificationDateUTC = modificationdate;
            this.State = state;
        }
    }
}
