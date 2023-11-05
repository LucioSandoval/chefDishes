using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using cheftDishes.Models;




    public class Dish
    {
        [Key]
        public int DishesId {get; set;}
        [Required]
        [Display(Name = "Name of the Dish:")]
        public string Name {get; set;}
        [Required]
        [Display(Name = "Rate of Tastiness:")]
        public int Tastiness {get; set;}
        [Required]
        [Display(Name = "Calories")]
        [Range(0, int.MaxValue)]
        public int Calories {get; set;}
        [Required]
        [Display(Name = "Description of the Dish:")]
        public string Description {get; set;}

        public DateTime CreatedAt {get; set;} = DateTime.Now;

        public DateTime UpdatedAt {get; set;} = DateTime.Now;

        [Display(Name = "Select Chef:")]
        public int ChefId {get; set;}
        public Chef myChef {get; set;}

    }