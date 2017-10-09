using System.ComponentModel.DataAnnotations.Schema;

namespace AquaHobby.Models.Base
{
    [ComplexType]
    public class Size
    {
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
    }
}
