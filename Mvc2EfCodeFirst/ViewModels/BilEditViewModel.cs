using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Mvc2EfCodeFirst.ViewModels
{
    public class BilEditViewModel
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Manufacturer { get; set; }

        [MaxLength(30)]
        public string Model { get; set; }


        [MaxLength(6)]
        public string RegNo { get; set; }

        [Range(1900,2030)]
        public int Year { get; set; }

        public decimal Price { get; set; }

        [MaxLength(30)]
        public string Color { get; set; }

        public IFormFile NyBild { get; set; }

    }
}