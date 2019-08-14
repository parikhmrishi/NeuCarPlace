using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuCarPlace.Domain.Entities
{
   public class CarType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<Car> Cars { get; set; }
    }
}