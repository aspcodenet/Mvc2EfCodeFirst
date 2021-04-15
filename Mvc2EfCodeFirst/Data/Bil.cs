using System.ComponentModel.DataAnnotations;

namespace Mvc2EfCodeFirst.Data
{
    public class Bil
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Manufacturer { get; set; }

        [MaxLength(30)]
        public string Model { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }
    }
}