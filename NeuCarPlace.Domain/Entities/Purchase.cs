using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NeuCarPlace.Domain.Entities
{
     public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
        public Car Car { get; set; }
        public DateTime DateOfBooking { get; set; }
    }
}
