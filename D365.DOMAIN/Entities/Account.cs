using D365.MODEL.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D365.MODEL.Entities
{
    public class Account : EFTBase<Guid>
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int City { get; set; }
        public int Type { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        [Column("ModificationDateUTC", TypeName = "datetime")]
        public DateTime ModificationDateUTC { get; set; }

        public Account()
        {
            this.Id = new Guid();
            this.CreationDateUTC = DateTime.Now.ToUniversalTime();
            this.ModificationDateUTC = DateTime.Now.ToUniversalTime();
            this.Name = string.Empty;
            this.LastName = string.Empty;
            this.Age = 0;
            this.City = 0;
            this.Type = 0;
            this.Email = string.Empty;
            this.Address = string.Empty;          
        }
        public Account(Guid id, DateTime modificationdate)
        {
            this.Id = id;
            this.ModificationDateUTC = modificationdate;
        }
    }
}
