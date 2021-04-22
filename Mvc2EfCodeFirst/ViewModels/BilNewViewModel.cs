using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mvc2EfCodeFirst.ViewModels
{

    //PersonNummer   .    197208031111
    //RegNo AAA111
    //ValidOcr

    public class RegNoAttribute : ValidationAttribute, IClientModelValidator
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string viewModelRegNo = Convert.ToString(value);

            if (!Check(viewModelRegNo))
                return new ValidationResult(ErrorMessage);

            return ValidationResult.Success;

        }

        private bool Check(string viewModelRegNo)
        {
            if (!Char.IsLetter(viewModelRegNo[0])) return false;
            if (!Char.IsLetter(viewModelRegNo[1])) return false;
            if (!Char.IsLetter(viewModelRegNo[2])) return false;
            if (!Char.IsDigit(viewModelRegNo[3])) return false;
            if (!Char.IsDigit(viewModelRegNo[4])) return false;
            if (!Char.IsDigit(viewModelRegNo[5])) return false;

            return true;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            if(!context.Attributes.ContainsKey("data-val"))
                context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-validregno", ErrorMessage);
        }
    }

    public class BilNewViewModel
    {
        [MaxLength(6)]
        [Remote("RegNoDuplicateCheck","Bil")]
        public string RegNo { get; set; }


        [MaxLength(30)]
        public string Manufacturer { get; set; }

        [MaxLength(30)]
        public string Model { get; set; }

        [Range(1900,2030)]
        public int Year { get; set; }

        public decimal Price { get; set; }

        public IFormFile NyBild { get; set; }


        [Required]
        public string SelectedColorValue { get; set; }
        public List<SelectListItem> AllColors { get; set; }

    }
}