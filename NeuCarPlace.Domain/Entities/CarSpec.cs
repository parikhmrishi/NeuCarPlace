using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuCarPlace.Domain.Entities
{
    public class CarSpec
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("CarId")]
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string Specs { get; set; }
    }
}
