using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace D365.MODEL.Common
{
    public abstract class EFTBase<IDT>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public IDT Id { get; protected set; }
        public DateTime CreationDateUTC { get; set; }
    }
}
