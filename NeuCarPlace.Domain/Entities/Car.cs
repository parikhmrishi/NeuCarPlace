using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NeuCarPlace.Domain.Entities
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Make { get; set; }
        [ForeignKey("CarType")]
        public int? CarTypeId { get; set; }
        public CarType CarType { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime LaunchDate { get; set; }
        public bool IsAvailable { get; set; }
        public long Price { get; set; }
        public string Image { get; set; }

        public ICollection<Purchase> Purchases { get; set; }
        public CarSpec CarSpec { get; set; }

    }
}