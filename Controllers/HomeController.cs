using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using cheftDishes.Models;


namespace cheftDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext dbContext;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Chef> AllChefs = dbContext.chef.Include(u=> u.Dishes).ToList();
            
            for (int i = 0; i< AllChefs.Count; i++){
                AllChefs[i].DateToAge(AllChefs[i].Age);
            }

            ViewBag.chef = AllChefs;

            return View();
        }

        [Route("dishes")]
        [HttpGet]
        public IActionResult Dishes()
        {
            List<Dish> AllDishes = dbContext.dishes.Include(u=> u.myChef).ToList();

            ViewBag.dish = AllDishes;
            return View();
        }

        [Route("dishes/new")]
        [HttpGet]
        public IActionResult DishesNew()
        {
            List<Chef> AllChefs = dbContext.chef.ToList();

            ViewBag.cheflist = AllChefs;


            return View();
        }

        [HttpPost("dishes/new")]
        public IActionResult DishesMake(Dish dish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Add(dish);
                dbContext.SaveChanges();
                return RedirectToAction("Dishes");
            }
            else
            {
                List<Chef> AllChefs = dbContext.chef.ToList();

                ViewBag.cheflist = AllChefs;
                
                return View("DishesNew");
            }
        }
        
        [Route("/new")]
        [HttpGet]
        public IActionResult ChefNew()
        {
            return View();
        }

        [HttpPost("/new")]
        public IActionResult AddChef(Chef chef){
            if (ModelState.IsValid)
            {
                dbContext.Add(chef);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("ChefNew");
            }

            
        }

        

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
