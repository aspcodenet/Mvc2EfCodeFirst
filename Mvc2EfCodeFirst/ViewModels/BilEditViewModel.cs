using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;

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


        public IFormFile NyBild { get; set; }



        [Required]
        public string SelectedColorValue { get; set; }
        public List<SelectListItem> AllColors { get; set; }


    }
}