using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Data;
using CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Models;

namespace CarModelInAspNetCoreWebAppWithEntityFrameWorkTest.Pages.Cars
{
    public class DetailsModel : PageModel
    {
        private readonly CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext _context;

        public DetailsModel(CarModelInAspNetCoreWebAppWithEntityFrameWorkTestContext context)
        {
            _context = context;
        }

      public Car Car { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            var car = await _context.Car.FirstOrDefaultAsync(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            else 
            {
                Car = car;
            }
            return Page();
        }
    }
}
