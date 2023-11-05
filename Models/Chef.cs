using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace cheftDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get; set;}

        [Required]
        [Display(Name = "First Name:")]
        public string FirstName {get; set;}
        [Required]
        [Display(Name = "Last Name:")]
        public string LastName {get; set;}
        [Required]
        [Age]
        [Display(Name = "Birth date:")]
        public DateTime Age{get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        public List<Dish> Dishes {get; set;}
        [NotMapped]
        public int year {get; set;}

        public void DateToAge(DateTime birth)
        {
            int year = DateTime.Now.Year - birth.Year;
            this.year = year; 
        }
       
    }

    public class AgeAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                DateTime birth = Convert.ToDateTime(value); 
                if (birth >= DateTime.Now)
                    return new ValidationResult("the Date is too ahead!");
                return ValidationResult.Success;
            }
        }
}