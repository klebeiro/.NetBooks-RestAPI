using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetRest.Model.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
