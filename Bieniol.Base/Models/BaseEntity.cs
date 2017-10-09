using System.ComponentModel.DataAnnotations;

namespace Bieniol.Base.Models
{
    public class BaseEntity<Tkey>
    {
        [Key]
        public Tkey Id;
    }
}
