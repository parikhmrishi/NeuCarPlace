using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace NeuCarPlace.Domain.Entities
{
    public class User
    {
        [Key]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}