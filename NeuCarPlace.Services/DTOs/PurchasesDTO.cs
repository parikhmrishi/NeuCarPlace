using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeuCarPlace.Services.DTOs
{
    public class PurchasesDTO
    {
        public int CarId { get; set; }
        public string ModelName { get; set; }
        public long Price { get; set; }
        public string Image { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
